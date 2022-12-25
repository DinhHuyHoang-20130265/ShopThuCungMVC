﻿using ShopThuCungMVC.DAO;
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
        public static void InsertUser(RegisterModel registerModel)
        {
            AccountDAO.InsertUser(registerModel.name, registerModel.birthday, registerModel.gender, registerModel.email, registerModel.phone, registerModel.user_name, registerModel.pass);
        }

        public static bool checkStatusEmailAccount(string email)
        {
            return AccountDAO.checkStatusEmailAccount(email);
        }

        public static void UpdateUser(string passMaHoa, string pass, string name, string email, string phone, string address, string avt)
        {
            AccountDAO.UpdateUser(passMaHoa, pass, name, email, phone, address, avt);
        }

        public static InforUser getInforUserById(string id)
        {
            return AccountDAO.getInforUserById(id);
        }

        public static void addUser(string username, string email, string address, string fullname, string passwd, string phone, int status)
        {
            AccountDAO.addUser(username, email, address, fullname, passwd, phone, status);
        }

        public static List<UserAccount> getListUser()
        {
            return AccountDAO.getListUser();
        }
    }
}
