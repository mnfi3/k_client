using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Dessert
    {
        public int  id { get; set; }
        public int  product_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int price_small { get; set; }
        public int price_medium { get; set; }
        public int price_large { get; set; }
        public string image { get; set; }


        public static Dessert parse(JObject obj)
        {
            Dessert dessert = new Dessert();
            dessert.id = obj["id"].Value<Int32>();
            dessert.name = obj["name"].Value<string>();
            dessert.type = obj["type"].Value<string>();
            dessert.price_small = obj["price_small"].Value<Int32>();
            dessert.price_medium = obj["price_medium"].Value<Int32>();
            dessert.price_large = obj["price_large"].Value<Int32>();
            dessert.image = obj["image"].Value<string>();

            return dessert;
        }
    }
}
