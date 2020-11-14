using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class AccountVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
        public RoleVM Role { get; set; }
        public List<OrderVM> Orders { get; set; }
    }
}