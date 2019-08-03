using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Restaurant
    {
        public int id { set; get;}
        public string user_name { set; get; }
        public string name { set; get; }
        public string image { set; get; }
        public string token { set; get; }



        public Restaurant()
        {
            id = 0;
            user_name = null;
            name = "";
            image = "";
            token = null;
        }

        public static Restaurant parse(JObject user)
        {
            Restaurant restaurant = new Restaurant();
            try
            {
                restaurant.id = user["id"].Value<Int32>();
                restaurant.name = user["name"].Value<string>();
                restaurant.user_name = user["email"].Value<string>();
                restaurant.image = user["image"].Value<string>();
            }
            catch (ArgumentNullException e)
            {

            }
            return restaurant;
        }
    }
}
