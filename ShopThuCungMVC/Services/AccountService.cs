using Microsoft.Extensions.Primitives;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopThuCungMVC.Services
{
    public class AccountService
    {
        ShopThuCungDBContext db = new ShopThuCungDBContext();
        public List<CustomerUser> Users { get; set; }
        public AccountService() {
            Users = db.customer_user.ToList();
        }

        public CustomerUser login(StringValues username, StringValues password)
        {
            foreach (var user in Users)
            {
                if (user.user_name.Equals(username) && user.pass.Equals(password))
                    return user;
            }
            return null;
        }
    }
}
