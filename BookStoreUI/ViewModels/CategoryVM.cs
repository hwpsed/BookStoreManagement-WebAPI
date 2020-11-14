using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookVM> Books { get; set; }
    }
}