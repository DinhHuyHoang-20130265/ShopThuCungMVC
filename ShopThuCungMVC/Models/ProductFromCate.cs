using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public class ProductFromCate
    {
        [Key]
        public string product_id { get; set; }
       
        public string cate_id { get; set;}

        public ProductFromCate(string product_id, string cate_id)
        {
            this.product_id = product_id;
            this.cate_id = cate_id;
        }
    }
}