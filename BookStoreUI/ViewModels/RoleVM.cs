using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class RoleVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccountVM> Accounts { get; set; }
    }
}