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
        public Payment payment{ set; get; }
        public int cost { set; get; }
        public string discount_code { set; get; }
        public string time { set; get; }
        public List<OrderContent> content { set; get; }
    }
}
