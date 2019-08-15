using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class OrderContentDessert
    {
        public int order_content_id { set; get; }
        public int dessert_id { set; get; }
        public int price { set; get; }
    }
}
