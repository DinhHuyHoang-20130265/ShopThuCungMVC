using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class OrderDetail
    {
        [Key]
        public string OrderId { get; set; }
      
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public OrderDetail(string orderId, string productId, string productName, double price, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}