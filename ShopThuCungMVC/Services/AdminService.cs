using Microsoft.Extensions.Primitives;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopThuCungMVC.Services
{
    public class AdminService
    {
        ShopThuCungDBContext db = new ShopThuCungDBContext();
        public List<AdminUser> Users { get; set; }
        public AdminService()
        {
            Users = db.admin_user.ToList();
        }

        public AdminUser login(StringValues username, StringValues password)
        {
            foreach (var user in Users)
            {
                if (user.username.Equals(username) && user.pass.Equals(password))
                    return user;
            }
            return null;
        }
    }
}
