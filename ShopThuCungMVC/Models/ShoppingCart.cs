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
        Dictionary<string, Product> data;

        public ShoppingCart(Dictionary<string, Product> data)
        {
            this.data = data;
        } 

        public int Put(string id, Product p)
        {
            if (data.ContainsKey(id))
            {
                Product temp = data[id];
                temp.QuantityCart = temp.QuantityCart + p.QuantityCart;
                Put(id, p);
            }
            else
            {
                Put(id, p);
            }
            return 0;
        }
        public bool remove(string id)
        {
            return data.Remove(id);
        }
       //public int getQuantityCart()
       // {
       //    List<string> keyid = new List<string>(this.data.Keys);
       //    int count = 0
       //    for(string id: keyid)
       //    {
       //         count += data[id].QuantityCart;   
       //    }
       //}
    }


}
