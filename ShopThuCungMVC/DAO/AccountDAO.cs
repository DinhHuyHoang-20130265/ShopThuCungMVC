using Microsoft.Extensions.Primitives;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopThuCungMVC.DAO
{
    public static class AccountDAO
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();
        public static UserAccount loginSite(String username, String password)
        {
            foreach (var user in db.user_account.ToList())
            {
                if (user.user_name.Equals(username) && user.passMaHoa.Equals(MD5.CreateMD5(password)) && user.role == 0 && user.status == 0)
                {
                    return user;
                }
            }
            return null;
        }
        public static UserAccount loginAdmin(String username, String password)
        {
            foreach (var user in db.user_account.ToList())
            {
                if (user.user_name.Equals(username) && user.passMaHoa.Equals(MD5.CreateMD5(password)) && user.role == 1 && user.status == 1)
                {
                    return user;
                }
            }
            return null;
        }
        public static bool checkEmailExist(String email)
        {
            foreach (var user in db.infor_user.ToList())
            {
                if (user.email.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool checkUsernameExist(String username)
        {
            foreach (var user in db.user_account.ToList())
            {
                if (user.user_name.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
