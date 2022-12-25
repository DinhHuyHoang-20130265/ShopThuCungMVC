using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class InforAdmin
    {
        [Key]
        public string id_user { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string avt { get; set; }

        public InforAdmin(string id_user, string name, string email, string phone, string address, string avt)
        {
            this.id_user = id_user;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.avt = avt;
        }
    }
}