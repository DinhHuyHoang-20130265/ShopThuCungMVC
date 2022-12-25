using Microsoft.EntityFrameworkCore;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ShopThuCungMVC.DAO
{
    public static class BlogsDAO
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();
        public static List<Blog> listBlog()
        {
            return db.blogs.ToList();
        }
        
        public static Blog BlogById(string id)
        {
            return db.blogs.Where(n => n.BlogId.Equals(id)).FirstOrDefault();
        }


        public static List<Blog> get3BlogNew()
        {
            List<Blog> list = db.blogs.FromSqlRaw($"SELECT * FROM blogs ORDER BY CreateDate DESC LIMIT 3").ToList();
            return list;
        }
        public static List<Blog> getBlog()
        {
            List<Blog> list = db.blogs.FromSqlRaw($"SELECT * from blogs").ToList();
            return list;
        }
        public static Blog DetailBlog(String id)
        {

            return db.blogs.FromSqlRaw($"select b.BlogId, b.BlogName, b.`Status`,b.Image,b.Desription,b.Dital,b.CreateBy,b.CreateDate,b.UpdateBy,b.UpdateDate from blogs b WHERE b.BlogId= '{id}' ").FirstOrDefault();
        }
        public static string generateIDBlog()
        {
            List<string> id = new List<string>();
            foreach (var p in db.blogs.ToList())
            {
                id.Add(p.BlogId);
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
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(alphaNumeric.Length);
                char randomChar = alphaNumeric.ElementAt(index);
                sb.Append(randomChar);
            }
            if (id.Contains(sb.ToString()))
                return generateIDBlog();
            else
                return sb.ToString();
        }
        internal static void AddNewBlog(string userid, string blogname, string _FileName, string desc)
        {
            string idProduct = generateIDBlog();
            Blog blog = new Blog(idProduct, blogname, 1, "https://localhost:44322/Content/img/products/" + _FileName, desc, null, userid, null, null, null);
            db.blogs.Add(blog);
            db.SaveChanges();
        }
        public static void DeleteBlog(string bid)
        {
            Blog blog = db.blogs.FromSqlRaw($"Select * from blogs where BlogId = '{bid}'").FirstOrDefault();

            db.blogs.Remove(blog);
            db.SaveChanges();
        }
        internal static void UpdateBlog(string blogid, string userid, string blogname, string fileName, string desc)
        {

            Blog blog = DetailBlog(blogid);
            db.SaveChanges();
            string url = "";
            if (!fileName.Equals(""))
            {
                url = "https://localhost:44322/Content/img/blog/" + fileName;
            }
            else
            {
                url = blog.Image;
            }
            blog.Desription = desc;
            blog.BlogName = blogname;
            blog.Image = url;
            DateTime check = DateTime.Now;
            blog.UpdateDate = check.Year + "/" + check.Month + "/" + check.Day;
            blog.CreateDate = check.Year + "/" + check.Month + "/" + check.Day;
            blog.UpdateBy = userid;
            ShopThuCungDBContext dbtest = new ShopThuCungDBContext();
            dbtest.Update(blog);
            dbtest.SaveChanges();
        }
    }
}