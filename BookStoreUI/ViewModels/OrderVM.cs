using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public float? TotalAmount { get; set; }
        public string Username { get; set; }
        public AccountVM Account { get; set; }
        public int? PaymentId { get; set; }
        public PaymentVM Payment { get; set; }
        public List<OrderDetailVM> OrderDetails { get; set; }

    }
}