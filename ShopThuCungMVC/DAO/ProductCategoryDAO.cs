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

        public static List<Product> listAllProduct()
        {
            return db.product.FromSqlRaw($"select distinct pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id")

                .ToList();
        }
        public static List<Product> listProductbyCate(String id)
        {
            var column = "pc.cate_id";
            return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id WHERE {column} = {id}")
                .ToList();
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
<<<<<<< HEAD
                return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id")
=======
                return db.product.FromSqlRaw($"select distinct pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd inner join product_from_cate pc on pd.productId=pc.product_id where pc.cate_id = 3")
>>>>>>> 93e37e9fd386e73b6fcb4f753603c8e5333b55bc
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

<<<<<<< HEAD
        public static List<Product> Filter(string order_by, String cate_id
            , String price,String size, String search)
        {
            String query = $"select DISTINCT p.productId, p.productId, p.Price,p.Image,p.`Status`,p.UpdateBy,p.CreateBy,p.CreateDate,p.UpdateDate\r\nFROM product p JOIN product_from_cate pfc\r\non p.productId = pfc.product_id\r\nWHERE p.`Status`=1;\r\n";
            
            if (cate_id != null )
            {   
                if (!cate_id.Equals("all"))
                {
                    query += "AND pfc.cate_id = " + cate_id + "\r\n";
                }

            }
            if (price != null)
            {
                if (!!price.Equals("-1"))
                {
                    String[] splited = price.Split('-');
                    query += " AND p.price >= " + Double.Parse(splited[0]) +
                        "AND p.price <=" + Double.Parse(splited[1]);
                }
            }
            return db.product.FromSqlRaw(query).ToList();
=======
        public static List<Product> searchByName(string txt)
        {
            var column = "pd.ProductName";

            List<Product> list = db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price, pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription," +
                $"pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd WHERE {column} LIKE '%{txt}%'")
                    .ToList();
            return list;
        }

        public static List<Product> getTop8BestSelling()
        {
            List<Product> list = db.product.FromSqlRaw($"SELECT pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang FROM orderdetail o join product pd ON o.ProductID = pd.productId GROUP BY ProductName ORDER BY SUM(o.Quantity) DESC limit 8").ToList();
            return list;
        }

        public static List<Blog> get3Blog()
        {
            List<Blog> list = db.blogs.FromSqlRaw($"SELECT * from blogs LIMIT 3").ToList();
            return list;
>>>>>>> 93e37e9fd386e73b6fcb4f753603c8e5333b55bc
        }
    }
}