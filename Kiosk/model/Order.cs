using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Order
    {
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public int cost { set; get; }
        public int d_cost { set; get; }
        public int discount_id { set; get; }
        public string payment_receipt{ set; get; }
        public string time { set; get; }
        public List<OrderContent> items { set; get; }

        public Order()
        {
            id = -1;
        }
    }
}
