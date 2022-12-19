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
        public double PromotionalPrice { get; set; }
        public int Quantity { get; set; }
        public int Warranty { get; set; }
        public int New { get; set; }
        public string Desription { get; set; }
        public int Dital { get; set; }
        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string giong { get; set; }
        public string mausac { get; set; }
        public string cannang { get; set; }

        public Product(string productId, string ProductName, int status, string image, double price, double promotionalPrice, int quantity, int warranty, int @new, string desription, int dital, string createBy, DateTime createDate, string updateBy, DateTime updateDate, string giong, string mausac, string cannang)
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
        }
    }
}