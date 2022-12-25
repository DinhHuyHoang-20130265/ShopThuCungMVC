using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class Orders
    {
        [Key]
        public string OrderID { get; set; }
        public string OrderDate { get; set; }
        public int status { get; set; }
        public int Delivered { get; set; }
        public string DeliveryDate { get; set; }
        public string CustomerID { get; set; }
        public int Discount { get; set; }

        public Orders(string orderID, string orderDate, int status, int delivered, string deliveryDate, string customerID, int discount)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            this.status = status;
            Delivered = delivered;
            DeliveryDate = deliveryDate;
            CustomerID = customerID;
            Discount = discount;
        }
    }
}