using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Cart
    {

        public List<CartItem> items { set; get; }

        public int cost
        {
            get
            {
                int s = 0;
                foreach (CartItem i in items)
                {
                    s += i.cost;
                }
                return s;
            }

        }

        public int d_cost
        {
            get
            {
                int s = 0;
                float c = cost;
                float p = discount.percent;
                s = (int)(c - ((c * p) / 100.0f));
                return s;
            }

        }

        public Discount discount { set; get; }






        public Cart(){
            items = new List<CartItem>();
            discount = new Discount();
            discount.id = 0;
            discount.percent = 0;
        }



        public void add(CartItem item)
        {
            items.Add(item);
        }

        public void remove(CartItem item)
        {
            for(int i=0 ; i<items.Count ; i++)
            {
                if (items[i].product.id == item.product.id)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
        }


        public void clear()
        {
            this.items.Clear();
            discount = new Discount(); 
        }


        
    }
}
