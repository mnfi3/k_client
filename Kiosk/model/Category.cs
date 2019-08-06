using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Category
    {
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public string name { set; get; }
        public string image { set; get; }
        public List<Product> products { set; get; }


        public Category()
        {
            products = new List<Product>();
        }

        public static Category parse(JObject obj)
        {
            Category category = new Category();
            category.id = obj["id"].Value<Int32>();
            category.name = obj["name"].Value<string>();
            category.image = obj["image"].Value<string>();

            JArray p = obj["products"].Value<JArray>();
            for (int i = 0; i < p.Count; i++)
            {
                category.products.Add(Product.parse((JObject)p[i]));
            }

            return category;
        }
    }
}
