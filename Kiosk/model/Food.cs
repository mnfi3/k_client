using System;
using System.Collections.Generic;
using Kiosk.db;
using Newtonsoft.Json.Linq;


namespace Kiosk.model
{
    public class Food
    {
      
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public int category_id { set; get; }
        public int is_side { set; get; }
        public string name { set; get; }
        public int price { set; get; }
        public int d_price { set; get; }
        public int discount_percent { set; get; }
        public string description { set; get; }
        public string image { set; get; }
        public int is_suggest { set; get; }
        public int is_available { set; get; }


        public Food()
        {
        }


        public static Food parse(JObject obj)
        {
            Food food = new Food();
            food.id = obj["id"].Value<Int32>();
            food.restaurant_id = obj["user_id"].Value<Int32>();
            food.category_id = obj["category_id"].Value<Int32>();
            food.is_side = obj["is_side"].Value<Int32>();
            food.name = obj["name"].Value<string>();
            food.price = obj["price"].Value<Int32>();
            food.discount_percent = obj["discount_percent"].Value<Int32>();
            food.d_price = food.price - ((food.price * food.discount_percent) / 100);
            food.description = obj["description"].Value<string>();
            food.image = obj["image"].Value<string>();
            food.is_available = obj["is_available"].Value<int>();
            food.is_suggest = obj["is_suggest"].Value<int>();
            return food;
        }
    }
}
