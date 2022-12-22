using Microsoft.EntityFrameworkCore;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}