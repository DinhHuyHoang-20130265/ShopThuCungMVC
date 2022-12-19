using ShopThuCungMVC.DAO;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopThuCungMVC.Services
{
    public static class AccountService
    {
        public static UserAccount loginSite(string username, string password)
        {
            return AccountDAO.loginSite(username, password);
        }
        public static UserAccount loginAdmin(string username, string password)
        {
            return AccountDAO.loginAdmin(username, password);
        }
        public static bool checkEmailExist(string email)
        {
            return AccountDAO.checkEmailExist(email);
        }
        public static bool checkUsernameExist(string username)
        {
            return AccountDAO.checkUsernameExist(username);
        }
    }
}
