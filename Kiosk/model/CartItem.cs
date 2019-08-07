using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class CartItem
    {
        public Product product { set; get; }
        public int count { set; get; }
        public List<Dessert> desserts { set; get; }
        public string desserts_size { set; get; }

        public CartItem()
        {
            desserts_size = "small";
            product = new Product();
            desserts = new List<Dessert>();
            count = 1;
        }


        //public int getCost(string size)
        //{
        //    desserts_size = size;
        //    int s = 0;
        //    foreach (Dessert d in desserts)
        //    {
        //        if (desserts_size == "small")
        //        {
        //            s += d.price_small;
        //        }
        //        else if (desserts_size == "medium")
        //        {
        //            s += d.price_medium;
        //        }
        //        else if (desserts_size == "large")
        //        {
        //            s += d.price_large;
        //        }
        //    }

        //    s += product.d_price;

        //    return s * count;
        //}



        public int cost
        {
            get
            {
                int s = 0;
                foreach (Dessert d in desserts)
                {
                    if(desserts_size == "small")
                    {
                        s += d.price_small;
                    }
                    else if (desserts_size == "medium")
                    {
                        s += d.price_medium;
                    }
                    else if(desserts_size == "large")
                    {
                        s += d.price_large;
                    }
                }

                s += product.d_price;

                return s * count;
            }
        }
    }
}
