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
        public static List<Orders> getListOrder()
        {
            return OrderDAO.getListOrder();
        }
        public static OrderDetail getOrderDetailById(string id)
        {
            return OrderDAO.getOrderDetailById(id);
        }
        public static void AddNewOrders(string id, ShoppingCart cart)
        {
            OrderDAO.AddNewOrders(id, cart);
        }
    }
}