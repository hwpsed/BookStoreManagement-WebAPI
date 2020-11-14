using BookStoreUI.ViewModels;
using BusinessLogic.Define;
using BusinessLogic.Implement;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : _BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBookService _bookService;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, IBookService bookService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult GetAllOrder()
        {
            try
            {
                var list = _orderService.GetAll(od => od.OrderDetails, od => od.Payment, _ => _.Account.Role).ToList();

                var orderDetails = new List<OrderDetail>();

                foreach (var od in list)
                {
                    orderDetails = od.OrderDetails.Select(_ => new OrderDetail
                    {
                        Id = _.Id,
                        BookId = _.BookId,
                        OrderId = _.OrderId,
                        Quantity = _.Quantity,
                        Book = _bookService.Get(b => b.Id == _.BookId, b => b.Category)

                    }).ToList();

                    od.OrderDetails = orderDetails;

                }



                var result = ModelMapper.ConvertToViewModels(list);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("account/orders")]
        public IActionResult GetAllOrderOfAccount(string username)
        {
            try
            {
                var list = _orderService.GetAll(od => od.OrderDetails, od => od.Payment, _ => _.Account.Role).Where(_ => _.Username == username).ToList();

                var orderDetails = new List<OrderDetail>();

                foreach (var od in list)
                {
                    orderDetails = od.OrderDetails.Select(_ => new OrderDetail
                    {
                        Id = _.Id,
                        BookId = _.BookId,
                        OrderId = _.OrderId,
                        Quantity = _.Quantity,
                        Book = _bookService.Get(b => b.Id == _.BookId, b => b.Category)

                    }).ToList();

                    od.OrderDetails = orderDetails;

                }
                var result = ModelMapper.ConvertToViewModels(list);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("account/order/{id}")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _orderService.Get(_ => _.Id == id, _ => _.Payment, _ => _.Account, _ => _.OrderDetails);
                order.OrderDetails.Select(_ => new OrderDetail
                {
                    Id = _.Id,
                    BookId = _.BookId,
                    OrderId = _.OrderId,
                    Quantity = _.Quantity,
                    Book = _bookService.Get(b => b.Id == _.BookId, b => b.Category)
                });

                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        

    }
}
