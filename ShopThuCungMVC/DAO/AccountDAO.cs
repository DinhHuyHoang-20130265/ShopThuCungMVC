using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Org.BouncyCastle.Asn1.Cms;
using ShopThuCungMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ShopThuCungMVC.DAO
{
    public static class AccountDAO
    {
        static readonly ShopThuCungDBContext db = new ShopThuCungDBContext();
        public static UserAccount loginSite(string username, string password)
        {
            foreach (var user in db.user_account.ToList())
            {
                if (user.user_name.Equals(username) && user.passMaHoa.Equals(MD5.CreateMD5(password)) && user.role == 0 && user.status == 1)
                {
                    return user;
                }
            }
            return null;
        }
        public static UserAccount loginAdmin(string username, string password)
        {
            foreach (var user in db.user_account.ToList())
            {
                if (user.user_name.Equals(username) && user.passMaHoa.Equals(MD5.CreateMD5(password)) && user.role == 1 && user.status == 1)
                {
                    return user;
                }
            }
            return null;
        }
        public static bool checkEmailExist(string email)
        {
            foreach (var user in db.infor_user.ToList())
            {
                if (user.email.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool checkUsernameExist(string username)
        {
            foreach (var user in db.user_account.ToList())
            {
                if (user.user_name.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GenerateIDUser()
        {
            List<string> id = new List<string>();
            db.user_account.ToList().ForEach(user => id.Add(user.id));
            string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string alphaNumeric = upperAlphabet + lowerAlphabet + numbers;

            StringBuilder sb = new StringBuilder();

            // create an object of Random class
            Random random = new Random();
            // specify length of random string
            int length = 5;
            for (int i = 0; i<length; i++) {
                int index = random.Next(alphaNumeric.Length);
                char randomChar = alphaNumeric.ElementAt(index);
                sb.Append(randomChar);
            }
            if (id.Contains(sb.ToString())) 
                return GenerateIDUser();
            else 
                return sb.ToString();
        }
        public static void InsertUser(string name, string gender, string email, string phone, string username, string password)
        {
            string id = GenerateIDUser();
            var user = new UserAccount(id, username, MD5.CreateMD5(password), password, 1, 0);
            var info = new InforUser(id, name, email, phone, null, null);
            db.user_account.Add(user);
            db.SaveChanges();
            db.infor_user.Add(info);
            db.SaveChanges();
        }
        public static void RemoveUser(string id)
        {
            InforUser info = db.infor_user.Find(id);
            db.infor_user.Remove(info);
            db.SaveChanges();
            UserAccount account = db.user_account.Find(id);
            db.user_account.Remove(account);
            db.SaveChanges();
        }
        public static UserAccount getAccountByEmail(string email)
        {
            var column = "iu.email";
            return db.user_account.FromSqlRaw($"Select ua.id, ua.user_name, ua.passMaHoa, ua.pass, ua.status, ua.role from user_account ua INNER JOIN infor_user iu ON ua.id =iu.id_user WHERE {column}= '{email}'").FirstOrDefault();
        }
        public static bool checkStatusEmailAccount(string email)
        {
            if (getAccountByEmail(email).status == 0)
                return false;
            else 
                return true;
        }

        public static void UpdateUser(string passMaHoa, string pass, string name, string email, string phone, string address, string avt)
        {
            UserAccount account = getAccountByEmail(email);
            if (pass != null)
                account.pass = pass;
            if (passMaHoa != null)
                account.passMaHoa = passMaHoa;
            InforUser inforUser = db.infor_user.Find(account.id);
            if (name != null)
                inforUser.name = name;
            if (email != null)
                inforUser.email = email;
            if (phone != null)
                inforUser.phone = phone;
            if (address != null)
                inforUser.address = address;
            if (avt != null)
                inforUser.avt = avt;
            db.user_account.Update(account);
            db.SaveChanges();
            db.infor_user.Update(inforUser);
            db.SaveChanges();
        }

        public static InforUser getInforUserById(string id)
        {
            return db.infor_user.Where(n => n.id_user.Equals(id)).FirstOrDefault();
        }

        public static string generateIDUser()
        {
            List<string> id = new List<string>();
            foreach (var u in db.user_account.ToList())
            {
                id.Add(u.id);
            }
            String upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
            String numbers = "0123456789";
            String alphaNumeric = upperAlphabet + lowerAlphabet + numbers;

            StringBuilder sb = new StringBuilder("C");

            // create an object of Random class
            Random random = new Random();
            // specify length of random string
            int length = 3;
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(alphaNumeric.Length);
                char randomChar = alphaNumeric.ElementAt(index);
                sb.Append(randomChar);
            }
            if (id.Contains(sb.ToString()))
                return generateIDUser();
            else
                return sb.ToString();
        }

        public static void addUser(string username, string email, string address, string fullname, string passwd, string phone, int status)
        {
            String id = generateIDUser();
            UserAccount user = new UserAccount(id, username, MD5.CreateMD5(passwd), passwd, status, 0);
            InforUser inforUser = new InforUser(id, fullname, email, phone, address, null);
            db.user_account.Add(user);
            db.SaveChanges();
            db.infor_user.Add(inforUser);
            db.SaveChanges();
        }

        public static void addAdmin (string username,string email, string address, string fullname, string passwd, string phone, int status)
        {
            String id = generateIDUser();
            UserAccount user = new UserAccount(id, username, MD5.CreateMD5(passwd), passwd, status, 1);
            InforUser inforUser = new InforUser(id, fullname, email, phone, address, null);
            db.user_account.Add(user);
            db.SaveChanges();
            db.infor_user.Add(inforUser);
            db.SaveChanges();
        }

        public static List<UserAccount> getListUser()
        {
            return db.user_account.Where(n=>n.role == 0).ToList();
        }

        public static List<UserAccount> getListAdmin()
        {
            return db.user_account.Where(n=>n.role == 1).ToList();
        }

        public static void removeAccount(string id)
        {
            UserAccount user = db.user_account.Find(id);
            db.user_account.Remove(user);
            db.SaveChanges();
        }
        public static UserAccount getAdminById(string id)
        {
            return db.user_account.Find(id);
        }

        internal static void UpdateAdmin(string userid, string username, string email, string address, string fullname, string passwd, string phone, int status)
        {
            UserAccount admin = getAdminById(userid);
            db.SaveChanges();
            admin.user_name = username;
            admin.pass = passwd;
            admin.passMaHoa = MD5.CreateMD5(passwd);
            admin.status = status;
            ShopThuCungDBContext dbtest = new ShopThuCungDBContext();
            dbtest.Update(admin);
            dbtest.SaveChanges();
            InforUser infor = getInforUserById(userid);
            infor.name = fullname;
            infor.email = email;
            infor.address = address;
            infor.phone = phone;
            ShopThuCungDBContext dbtest2 = new ShopThuCungDBContext();
            dbtest2.Update(infor);
            dbtest2.SaveChanges();
        }

        internal static UserAccount getUserById(string id)
        {
            return db.user_account.Where(p => p.id.Equals(id)).FirstOrDefault();
        }

        internal static void UpdateUser(string userid, string username, string email, string address, string fullname, string passwd, string phone, int status)
        {
            UserAccount user = getUserById(userid);
            db.SaveChanges();
            user.user_name = username;
            user.pass = passwd;
            user.passMaHoa = MD5.CreateMD5(passwd);
            user.status = status;
            ShopThuCungDBContext dbtest = new ShopThuCungDBContext();
            dbtest.Update(user);
            dbtest.SaveChanges();
            InforUser infor = getInforUserById(userid);
            infor.name = fullname;
            infor.email = email;
            infor.address = address;
            infor.phone = phone;
            ShopThuCungDBContext dbtest2 = new ShopThuCungDBContext();
            dbtest2.Update(infor);
            dbtest2.SaveChanges();
        }
    }
}
