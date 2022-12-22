using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace ShopThuCungMVC.DAO
{
    public static class ProductCategoryDAO
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
                 return db.product.FromSqlRaw($"select distinct pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id")

                .ToList(); 
            }
            else
            {
                var column = "pc.cate_id";
                return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id WHERE {column}= '{id}'")
                    .ToList();
            }
        }
        public static List<Product> listProductDogAndCatbyCate(String id)
        {
            if (id == null)
            {
                return db.product.FromSqlRaw($"select distinct pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id where pc.cate_id = 1 or pc.cate_id = 2")
                .ToList();
            }
            else
            {
                var column = "pc.cate_id";
                return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id WHERE {column}= '{id}'")
                    .ToList();
            }
        }
        public static List<Product> listProductAccessorybyCate(String id)
        {
            if (id == null)
            {
                return db.product.FromSqlRaw($"select distinct pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id where pc.cate_id = 3")
                .ToList();
            }
            else
            {
                var column = "pc.cate_id";
                return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id WHERE {column}= '{id}'")
                    .ToList();
            }
        }

        public static Product Detail(String id)
        {
            return db.product.FromSqlRaw($"select distinct pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd WHERE pd.productId= '{id}' ").FirstOrDefault();
        }

        public static List<Product> searchByName(string txt)
        {
            var column = "pd.ProductName";
            
            List<Product> list = db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price, pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription," +
                $"pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd WHERE {column} LIKE '%{txt}%'")
                    .ToList();
            return list;
        }
    }
}