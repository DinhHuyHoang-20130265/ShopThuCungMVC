using Google.Protobuf.Collections;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThuCungMVC.Models
{

    public class ShoppingCart
    {
        Dictionary<string, int> data;

        public ShoppingCart()
        {
            data = new Dictionary<string, int>();
        } 

        public int Put(string id, int quantity)
        {
            if (data.ContainsKey(id))
            {
                int temp = data[id];

                data[id] = temp + quantity;
            }
            else
            {
                data.Add(id, quantity);
            }
            return 0;
        }
        public bool Remove(string id)
        {
            return data.Remove(id);
        }
        public int getQuantityCart()
         {
            int count = 0;
            foreach (var id in data.Keys)
            {
                 count += data[id];   
            }
            return count;
        }
        public Dictionary<string, int> getData()
        {
            return data;
        }
        public double Sum(string id, int quantity)
        {
            double money = 0.0;
            if (data.ContainsKey(id))
            {
                Product p = Services.ProductCateService.ProductById(id);
                money = p.Price * quantity;
            }
            return money;
        }
        public double Total()
        {
            double money = 0.0;
            foreach (var key in data.Keys)
            {
                Product p = Services.ProductCateService.ProductById(key);
                money += p.Price * data[key];
            }
            return money;
        }
    }
}
