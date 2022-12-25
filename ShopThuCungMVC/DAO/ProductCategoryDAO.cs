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
using System.Text;

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
        public static string generateIDProduct()
        {
            List<string> id = new List<string>();
            foreach (var p in db.product.ToList())
            {
                id.Add(p.productId);
            }
            String upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            String numbers = "0123456789";
            String alphaNumeric = upperAlphabet + lowerAlphabet + numbers;

            StringBuilder sb = new StringBuilder();

            // create an object of Random class
            Random random = new Random();
            // specify length of random string
            int length = 10;
            for (int i = 0; i<length; i++) {
                int index = random.Next(alphaNumeric.Length);
                char randomChar = alphaNumeric.ElementAt(index);
                sb.Append(randomChar);
            }
            if (id.Contains(sb.ToString())) 
                    return generateIDProduct();
            else 
                    return sb.ToString();
        }
        internal static void AddNewProduct(string userid, string productname, string _FileName, string desc, string price, string promoPrice, string quantity, string cannang, string mausac, string date, string giong, string size)
        {
            string idProduct = generateIDProduct();
            Product product = new Product(idProduct, productname, 1, "https://localhost:44322/Content/img/products/" + _FileName, Double.Parse(price), promoPrice, Int32.Parse(quantity), 1, null, desc, null, userid, date, null, null, giong, mausac, cannang);
            ProductCategory cate = db.product_category.FromSqlRaw($"select * from product_category where CatName = '{giong}'").FirstOrDefault(); 
            ProductFromCate productFromCate = new ProductFromCate(idProduct, cate.CatId);
            db.product.Add(product);
            db.SaveChanges();
            db.product_from_cate.Add(productFromCate);
            db.SaveChanges();
        }
        internal static void AddNewAccessory(string userid, string productname, string _FileName, string desc, string price, string promoPrice, string quantity, string date, string giong, string size)
        {
            string idProduct = generateIDProduct();
            Product product = new Product(idProduct, productname, 1, "https://localhost:44322/Content/img/products/" + _FileName, Double.Parse(price), promoPrice, Int32.Parse(quantity), 1, null, desc, null, userid, date, null, null, giong, null, null);
            ProductCategory cate = db.product_category.FromSqlRaw($"select * from product_category where CatName = '{giong}'").FirstOrDefault();
            ProductFromCate productFromCate = new ProductFromCate(idProduct, cate.CatId);
            db.product.Add(product);
            db.SaveChanges();
            db.product_from_cate.Add(productFromCate);
            db.SaveChanges();
        }
    }
}