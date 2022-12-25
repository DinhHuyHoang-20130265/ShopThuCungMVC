using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static string GenerateOrderUser()
        {
            List<string> id = new List<string>();
            db.orders.ToList().ForEach(o => id.Add(o.OrderID));
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string alphaNumeric = upperAlphabet + lowerAlphabet + numbers;

            StringBuilder sb = new StringBuilder();

            // create an object of Random class
            Random random = new Random();
            // specify length of random string
            int length = 10;
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(alphaNumeric.Length);
                char randomChar = alphaNumeric.ElementAt(index);
                sb.Append(randomChar);
            }
            if (id.Contains(sb.ToString()))
                return GenerateOrderUser();
            else
                return sb.ToString();
        }
        public static void AddNewOrders(string id, ShoppingCart cart)
        {
            String orderId = GenerateOrderUser();
            string orderDate = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            Orders order = new Orders(orderId, orderDate, 1, 0, null, id, 0);
            ShopThuCungDBContext dbmain = new ShopThuCungDBContext();
            dbmain.Add(order);
            dbmain.SaveChanges();
            foreach (var key in cart.getData().Keys)
            {
                ShopThuCungDBContext db = new ShopThuCungDBContext();
                Product p = db.product.Where(d => d.productId.Equals(key)).FirstOrDefault();
                OrderDetail detail = new OrderDetail(orderId, p.productId, p.ProductName, p.Price * cart.getData()[key], cart.getData()[key]);
                db.Add(detail);
                db.SaveChanges();
            }
        }
    }
}