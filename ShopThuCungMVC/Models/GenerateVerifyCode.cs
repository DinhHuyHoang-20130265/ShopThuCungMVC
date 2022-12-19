using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThuCungMVC.Models
{
    public static class GenerateVerifyCode
    {
        public static string GenerateNewRandom()
        {
            Random generator = new Random();
            string r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateNewRandom();
            }
            return r;
        }
    }
}