using ShopThuCungMVC.DAO;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopThuCungMVC.Services
{
    public static class AccountService
    {
        public static UserAccount loginSite(String username, String password)
        {
            return AccountDAO.loginSite(username, password);
        }
        public static UserAccount loginAdmin(String username, String password)
        {
            return AccountDAO.loginAdmin(username, password);
        }
        public static bool checkEmailExist(String email)
        {
            return AccountDAO.checkEmailExist(email);
        }
        public static bool checkUsernameExist(String username)
        {
            return AccountDAO.checkUsernameExist(username);
        }
    }
}
