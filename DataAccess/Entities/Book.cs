using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Book : _BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public int? Stock { get; set; }
        public float? Price { get; set; }
        public string ImportDate { get; set; }
        public int? CategoryId { get; set; }
        public BookStatus Status { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }


    public enum BookStatus
    {
        Active = 1,
        Deactive = 0
    }
}
