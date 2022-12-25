using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.DAO
{
    public class OrderDAO
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();
        public static List<Orders> getListOrderByIdUser(string id)
        {
            return db.orders.Where(n=>n.CustomerID==id).ToList();
        }
        public static List<Orders> getListOrder()
        {
            return db.orders.ToList();
        }
        public static OrderDetail getOrderDetailById(string id)
        {
            return db.orderdetail.Where(n => n.OrderId.Equals(id)).FirstOrDefault();
        }
    }
}