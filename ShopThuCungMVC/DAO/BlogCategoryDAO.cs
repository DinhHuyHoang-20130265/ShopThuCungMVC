using ShopThuCungMVC.Models;
using System;
using System.Web;

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

    public class BlogCategoryDAO : IHttpHandler
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();

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

        internal static void AddBlog(string userid, string BlogId, string BlogName, string desc)
        {
            string idBlog = generateIDBlog();
            Blog blog = new Blog(BlogId, BlogName, 1, "https://localhost:44322/Content/img/products/" + desc, null, null, null, userid, null);
            db.blogs.Add(blog);
            db.SaveChanges();
            db.blogs.Add(blog);
            db.SaveChanges();
        }

      
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
        }

        #endregion
    }
}
