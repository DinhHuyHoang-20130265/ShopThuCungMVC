using ShopThuCungMVC.DAO;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Services
{
    public class OrderService
    {
        public static List<Orders> getListOrderByIdUser(string id)
        {
            return OrderDAO.getListOrderByIdUser(id);
        }
    }
}