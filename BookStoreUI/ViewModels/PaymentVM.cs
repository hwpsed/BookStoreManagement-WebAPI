using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class PaymentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderVM> Orders { get; set; }
    }
}