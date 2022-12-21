using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ShopThuCungMVC.DAO
{
    public class BlogsDAO
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
        
        


    }
}