using Google.Protobuf.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public bool remove(string id)
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
    }
}
