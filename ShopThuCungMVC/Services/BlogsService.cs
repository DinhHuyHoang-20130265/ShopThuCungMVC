using ShopThuCungMVC.DAO;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
namespace ShopThuCungMVC.Services
{
    public class BlogsService
    {
        public static List<Blog> listBlog()
        {
            return BlogsDAO.listBlog();
        }

        public static Blog BlogById(string id)
        {
            return BlogsDAO.BlogById(id);
        }

        public static List<Blog> get3BlogNew()
        {
            return BlogsDAO.get3BlogNew();
        }
        public static List<Blog> getBlog()
        {
            return BlogsDAO.getBlog();
        }
        public static Blog DetailBlog(String id)
        {
            return BlogsDAO.DetailBlog(id);
        }
        internal static void AddNewBlog(string userid, string blogname, string _FileName, string desc)
        {
            BlogsDAO.AddNewBlog(userid, blogname, _FileName, desc);
        }
        public static void DeleteBlog(string bid)
        {
            BlogsDAO.DeleteBlog(bid);
        }
        internal static void UpdateBlog(string bid, string userid, string blogname, string fileName, string desc)
        {
            BlogsDAO.UpdateBlog(bid, userid, blogname, fileName, desc);
        }
    }
}