using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class Product
    {
        [Key]
        public string productId { get; set; }
        public string ProductName { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string PromotionalPrice { get; set; }
        public int Quantity { get; set; }
        public int Warranty { get; set; }
        public string New { get; set; }
        public string Desription { get; set; }
        public string Dital { get; set; }
        public string CreateBy { get; set; }

        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }

        public string UpdateDate { get; set; }

        public string giong { get; set; }
        public string mausac { get; set; }
        public string cannang { get; set; }
        public int QuantityCart { get; set; }

        public Product(string productId, string ProductName, int status, string image, double price, string promotionalPrice, int quantity, int warranty, string @new, string desription, string dital, string createBy, string createDate, string updateBy, string updateDate, string giong, string mausac, string cannang, int QuantityCart)
        {
            this.productId = productId;
            this.ProductName = ProductName;
            this.Status = status;
            this.Image = image;
            this.Price = price;
            this.PromotionalPrice = promotionalPrice;
            this.Quantity = quantity;
            this.Warranty = warranty;
            this.New = @new;
            this.Desription = desription;
            this.Dital = dital;
            this.CreateBy = createBy;
            this.CreateDate = createDate;
            this.UpdateBy = updateBy;
            this.UpdateDate = updateDate;
            this.giong = giong;
            this.mausac = mausac;
            this.cannang = cannang;
            this.QuantityCart = QuantityCart;
        }
    }
}