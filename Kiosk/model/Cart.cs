using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    class Cart
    {
        public Cart(){
            cost = 0;
            restaurant_id = 0;
            products = new List<Product>();
            discount_percent = 0;
        }



        public int discount_percent { set; get; }

        public int restaurant_id { set; get; }
        private int cost;


        public int getCost()
        {
            cost = 0;
            foreach (Product p in products)
            {
                cost += p.price * p.count;
            }
            cost = cost - ((cost * discount_percent) / 100);
            return cost;
        }





        public List<Product> products { set; get; }



        public bool add(Product product)
        {
            bool isExist = false;
            foreach (Product p in products)
            {
                if (product.id == p.id)
                {
                    isExist = true;
                    break;
                }
            }

            if (isExist == false)
            {
                products.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }


        public void clear()
        {
            this.products.Clear();
            this.cost = 0;
            this.restaurant_id = 0;
            this.discount_percent = 0;
        }



        
    }
}
