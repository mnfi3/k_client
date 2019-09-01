using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.db;
using Newtonsoft.Json.Linq;


namespace Kiosk.model
{
    public class Product
    {
      
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public int category_id { set; get; }
        public string name { set; get; }
        public int price { set; get; }
        public int d_price { set; get; }
        public string description { set; get; }
        public string image { set; get; }
        public List<Dessert> desserts { set; get; }


        public Product()
        {
            desserts = new List<Dessert>();
        }


        public static Product parse(JObject obj)
        {
            Product product = new Product();

            product.id = obj["id"].Value<Int32>();
            product.name = obj["name"].Value<string>();
            product.price = obj["price"].Value<Int32>();
            product.d_price = obj["d_price"].Value<Int32>();
            product.description = obj["description"].Value<string>();
            product.image = obj["image"].Value<string>();

            JArray d = obj["desserts"].Value<JArray>();
            for (int i = 0; i < d.Count; i++)
            {
                product.desserts.Add(Dessert.parse((JObject)d[i]));
            }

            return product;
        }
    }
}
