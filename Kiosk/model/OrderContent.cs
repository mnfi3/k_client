using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class OrderContent
    {
        public int id { set; get; }
        public int order_id { set; get; }
        public int product_id { set; get; }
        public int cost { set; get; }
        public int count { set; get; }
        public List<OrderContentDessert> desserts { set; get; }
    }
}
