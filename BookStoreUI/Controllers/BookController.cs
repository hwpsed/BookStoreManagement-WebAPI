using BookStoreUI.ViewModels;
using BusinessLogic.Define;
using BusinessLogic.Implement;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Linq;

namespace BookStoreUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : _BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }



        [HttpGet]
        [Route("books")]
        public IActionResult GetAllBook()
        {
            try
            {
                var list = _bookService.GetAll(_ => _.Category).ToList();
                var result = ModelMapper.ConvertToViewModels(list);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("active books")]
        public IActionResult GetActiveBook()
        {
            try
            {
                var activeBooks = _bookService.GetAll(b => b.Category).Where(b => b.Status == BookStatus.Active).ToList();
                var result = ModelMapper.ConvertToViewModels(activeBooks);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        


        [HttpGet]
        [Route("search")]
        public IActionResult SearchBookByTitle(string name)
        {
            try
            {
                var list = _bookService.GetAll(b => b.Category).Where(b => b.Title.Contains(name)).ToList();
                var result = ModelMapper.ConvertToViewModels(list);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("book/add")]
        public IActionResult AddBook(BookInsertVM book)
        {
            try
            {
                Book b = ModelMapper.ConverToModel(book);
                _bookService.Create(b);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpDelete]
        [Route("book/delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var book = _bookService.Get(_ => _.Id == id);
                _bookService.Delete(book);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("searchId")]
        public IActionResult SearchBookByTitle(int id)
        {
            try
            {
                var list = _bookService.GetAll(b => b.Category).Where(b => b.Id == id).ToList();
                Book book = _bookService.Get(_ => _.Id == id);
                var result = ModelMapper.ConvertToViewModel(book);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        [Route("book/update")]
        public IActionResult UpdateBook(BookInsertVM book, int id)
        {
            try
            {
                Book tmpBook = _bookService.Get(b => b.Id == id);
                var model = ModelMapper.ConverToModel(book);

                tmpBook.Title = model.Title;
                tmpBook.Image = model.Image;
                tmpBook.Price = model.Price;
                tmpBook.Stock = model.Stock;
                tmpBook.CategoryId = model.CategoryId;

                _bookService.Update(tmpBook);
                return Ok();
            }
            catch (Exception e)  
            {

                return StatusCode(500, e);
            }
        }
    }
}