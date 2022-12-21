using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ShopThuCungMVC.DAO
{
    public class ProductCategoryDAO
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();
        public static List<ProductCategory> listProductCate()
        {
            return db.product_category.ToList();
        }

        public static List<Product> listProductbyCate(String id)
        {
            if (id == null)
            {
                return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id")
                .ToList();
            }
            else
            {
                var column = "pc.cate_id";
                return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id WHERE {column}= '{id}'")
                    .ToList();
            }
        }
    }
}