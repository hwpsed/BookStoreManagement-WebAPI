using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class OrderDetailVM
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
        public OrderVM Order { get; set; }
        public int? BookId { get; set; }
        public BookVM Book { get; set; }
    }
}