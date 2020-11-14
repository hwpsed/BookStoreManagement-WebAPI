using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order : _BaseEntity
    {
        public DateTimeOffset CreateDate { get; set; } 
        public float? TotalAmount { get; set; }
        public string Username { get; set; }
        public Account Account { get; set; }
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }

}
