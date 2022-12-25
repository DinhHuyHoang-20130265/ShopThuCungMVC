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
using Org.BouncyCastle.Math.Field;

namespace ShopThuCungMVC.DAO
{
    public static class ProductCategoryDAO
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();
        public static List<ProductCategory> listProductCate()
        {
            return db.product_category.ToList();
        }

        public static List<ProductCategory> listProCateClassify (String id)
        {
            String query = $"\tSELECT DISTINCT pc.* \r\n\tFROM  product_category pc join product_from_cate pfc on pfc.cate_id = pc.CatId\r\n\tJOIN product p on p.productId = pfc.product_id \r\n\tWhere p.`Status` =1 ";
            if (id != null)
            {
                switch (id)
                {
                    case "AllProduct": query += $"and pc.ParentID IS NOT NULL";
                        break;
                    case "1":
                        query += $"and pc.ParentID = 1";
                        break;
                    case"2":
                        query += $"and pc.ParentID = 2";
                        break;
                    case "3":
                        query += $"and pc.ParentID = 3";
                        break;
                }
            }
            List<ProductCategory> list = db.product_category.FromSqlRaw(query).ToList();
            return list;
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

            return db.product.FromSqlRaw($"select pd.productId, pd.ProductName, pd.`Status`,pd.Image,pd.Price,pd.PromotionalPrice,pd.Quantity,pd.Warranty,pd.New,pd.Desription,pd.Dital,pd.CreateBy,pd.CreateDate,pd.UpdateBy,pd.UpdateDate,pd.giong,pd.mausac,pd.cannang from product pd WHERE pd.productId= '{id}' ").FirstOrDefault();
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

        public static List<Product> Filter(String price, String category, String size, String order_by)
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
            if (order_by != null)
            {
                switch (order_by)
                {
                    case "0": query += "";
                        break;
                    case "1":
                        query += "ORDER BY p.ProductName ASC";
                        break;
                    case "2":
                        query += "ORDER BY p.view_count DESC";
                        break;
                    case "3":
                        query += "ORDER BY p.price ASC";
                        break;
                    case "4":
                        query += "ORDER BY p.price DESC";
                        break;

                }
            }
            
            String final = query;
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
            string url = "";
            if (!_FileName.Equals(""))
            {
                url = "https://localhost:44322/Content/img/products/" + _FileName;
            }
            Product product = new Product(idProduct, productname, 1, url, Double.Parse(price), promoPrice, Int32.Parse(quantity), 1, null, desc, null, userid, date, null, null, giong, mausac, cannang);
            ProductCategory cate = db.product_category.FromSqlRaw($"select * from product_category where CatName = '{giong}'").FirstOrDefault(); 
            ProductFromCate productFromCate = new ProductFromCate(idProduct, cate.CatId);
            db.product.Add(product);
            db.SaveChanges();
            db.product_from_cate.Add(productFromCate);
            db.SaveChanges();
        }
        public static void DeleteProduct(string id)
        {
            Product product = db.product.FromSqlRaw($"Select * from product where productId = '{id}'").FirstOrDefault();
            
            db.product.Remove(product);
            db.SaveChanges();
        }

        internal static void UpdateProduct(string productid, string userid, string productname, string fileName, string desc, string price, string promoPrice, string quantity, string cannang, string mausac, string date, string giong, string size)
        {
            
            Product product = Detail(productid);
            db.SaveChanges();
            string url = "";
            if (!fileName.Equals(""))
            {
                url = "https://localhost:44322/Content/img/products/" + fileName;
            }
            else
            {
                url = product.Image;
            }
            product.cannang = cannang;
            product.mausac = mausac;
            product.Desription = desc;
            product.giong = giong;
            product.Price = double.Parse(price);
            product.PromotionalPrice = promoPrice;
            product.ProductName = productname;
            product.Image = url;
            product.Quantity = int.Parse(quantity);
            DateTime check = DateTime.Now;
            product.UpdateDate = check.Year + "/" + check.Month + "/" + check.Day;
            product.CreateDate = check.Year + "/" + check.Month + "/" + check.Day;
            product.UpdateBy = userid;
            ShopThuCungDBContext dbtest = new ShopThuCungDBContext();
            dbtest.Update(product);
            dbtest.SaveChanges();
            ProductCategory cate = db.product_category.Where(p => p.CatName.Equals(giong)).FirstOrDefault();
            ProductFromCate productFromCate = db.product_from_cate.Where(p => p.product_id.Equals(product.productId)).FirstOrDefault();
            productFromCate.cate_id = cate.CatId;
            ShopThuCungDBContext dbtest2 = new ShopThuCungDBContext();
            dbtest2.Update(productFromCate);
            dbtest2.SaveChanges();
        }
        /*public static List<ProductCategory> listCate(String category)
        {
            string query = $"SELECT DISTINCT p.* FROM product p join product_from_cate pfc ON p.productId = pfc.product_id \r\nWHERE p.`Status` =1";
            if (category != null)
            {
                switch (category)
                {
                    case "AllProduct": query +=$" ";
                        break;
                    case "1": query += $"AND  pfc.cate_id = 1 ";
                        break;
                    case "2":
                        query += $"AND  pfc.cate_id = 2 ";
                        break;
                    case "3":
                        query += $"AND  pfc.cate_id = 3 ";
                        break;
                }
            }
            List<Product> list = db.product.FromSqlRaw(query).ToList();
            return list;
        }*/
    }
}