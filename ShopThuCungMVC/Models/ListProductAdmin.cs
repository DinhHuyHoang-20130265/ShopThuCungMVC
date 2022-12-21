using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class ListProductAdmin
    {
        public List<Product> ListProductDogCatAdmin { get; set; }
        public List<Product> ListProductAccessoryAdmin { get; set; }

        public ListProductAdmin(List<Product> listProductDogCatAdmin, List<Product> listProductAccessoryAdmin)
        {
            ListProductDogCatAdmin = listProductDogCatAdmin;
            ListProductAccessoryAdmin = listProductAccessoryAdmin;
        }

    }
}