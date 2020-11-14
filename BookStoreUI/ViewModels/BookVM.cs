using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public int? Stock { get; set; }
        public float? Price { get; set; }
        public string ImportDate { get; set; }
        public string Status { get; set; }
        public CategoryVM Category { get; set; }
        public List<OrderDetailVM> OrderDetails { get; set; }
    }

    public class BookInsertVM
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public int? Stock { get; set; }
        public float? Price { get; set; }
        //public CategoryVM Category { get; set; }
        public int? CategoryId { get; set; }
        public string ImportDate { get; set; }
        public int? Status { get; set; }
    }

    
}