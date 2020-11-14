using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Category : _BaseEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
