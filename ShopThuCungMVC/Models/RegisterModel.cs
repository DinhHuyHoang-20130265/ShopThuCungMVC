using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class RegisterModel
    {
        public string user_name { get; set; }
        public string pass { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }

        public RegisterModel(string user_name, string pass, string name, string email, string phone, string gender)
        {
            this.user_name = user_name;
            this.pass = pass;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
        }
    }
}