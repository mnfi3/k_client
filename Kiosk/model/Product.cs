using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.db;


namespace Kiosk.model
{
    public class Product
    {
        public Product()
        {
            id = 0;
            restaurant_id = 0;
            category_id = 0;
            name = "";
            image = "";
            price = 0;
            count = 0;
        }
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public int category_id { set; get; }
        public string name { set; get; }
        public string image { set; get; }
        public int price { set; get; }
        public int count { set; get; }
    }
}
