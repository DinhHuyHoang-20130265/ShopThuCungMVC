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

        public static List<Product> getTop8BestSelling()
        {
            List<Product> list = db.product.FromSqlRaw($"SELECT pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang FROM orderdetail o join product pd ON o.ProductID = pd.productId GROUP BY ProductName ORDER BY SUM(o.Quantity) DESC limit 8").ToList();
            return list;
        }
        public static List<Blog> get3Blog()
        {
            List<Blog> list = db.blogs.FromSqlRaw($"SELECT * from blogs LIMIT 3").ToList();
            return list;
        }

        public static List<Product> Filter(String price, String category, String size)
        {
            String query = $"SELECT DISTINCT p.* FROM product p INNER JOIN product_from_cate pc ON p.productId = pc.product_id WHERE p.`Status`=1 ";
            if(price != null)
            {
                if (!price.Equals("-1"))
                {
                    String[] splited = price.Split('-');
                    query += $" AND p.price >= {Double.Parse(splited[0])} AND p.price <= {Double.Parse(splited[1])} ";
                }
            }
            if (category != null)
            {
                if (!category.Equals("AllProduct"))
                {
                    query += $" AND pc.cate_id = '{category}'";
                }
            }

            if (size != null)
            {
                    String[] splited = size.Split('-');
                    query += $" AND p.cannang >= {Double.Parse(splited[0])} AND p.cannang <= {Double.Parse(splited[1])} ";
            }
            string final = query;
            List<Product> list = db.product.FromSqlRaw(final).ToList();
            return list;
        }
    }
}