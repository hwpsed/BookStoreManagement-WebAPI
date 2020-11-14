using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderDetail  : _BaseEntity
    {
        public int Quantity { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
        

    }
}
