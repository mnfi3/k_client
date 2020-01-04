using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class CartItem
    {
        public Food food { set; get; }
        public int count { set; get; }

        public CartItem(Food f)
        {
            food = f;
            count = 1;
        }

        public CartItem()
        {
            food = new Food();
            count = 1;
        }


        public int cost
        {
            get
            {
                return food.d_price * count;
            }
        }
    }
}
