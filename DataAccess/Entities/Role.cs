using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Role : _BaseEntity
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }    
    }
}
