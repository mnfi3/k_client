using Kiosk.db_lite;
using Kiosk.system;
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
        public string address { set; get; }
        public string description { set; get; }
        public string token { set; get; }

        //kiosk info
        public int is_use_table_number { set; get; }
        public int table_count { set; get; }
        public int order_number_start { set; get; }
        public int order_number_step { set; get; }

        public AllProduct all_product { set; get; }

        public List<Printer> printers
        {
            get
            {
                DBRestaurant db_rest = new DBRestaurant();
                return db_rest.getPrinters(this);
            }
        }





        public Restaurant()
        {
            id = 0;
            user_name = "";
            name = "";
            image = "";
            description = "";
            token = "";
            is_use_table_number = 0;
            table_count = 0;
            order_number_start = 1;
            order_number_step = 1;
            all_product = new AllProduct();
        }

        public static Restaurant parse(JObject obj)
        {
            Restaurant restaurant = new Restaurant();
            try
            {
                restaurant.id = obj["id"].Value<Int32>();
                restaurant.name = obj["name"].Value<string>();
                restaurant.user_name = obj["email"].Value<string>();
                restaurant.address = obj["address"].Value<string>();
                restaurant.image = obj["image"].Value<string>();
                restaurant.description = obj["description"].Value<string>();
                //get kiosk info
                JObject kiosk_info = obj["kiosk_info"].Value<JObject>();
                restaurant.is_use_table_number = kiosk_info["is_use_table_number"].Value<Int32>();
                restaurant.table_count = kiosk_info["table_count"].Value<Int32>();
                restaurant.order_number_start = kiosk_info["order_number_start"].Value<Int32>();
                restaurant.order_number_step = kiosk_info["order_number_step"].Value<Int32>();
            }
            catch (Exception e)
            {
                Log.e("json parsing error. json_text=" + obj.ToString() + "\terror=" + e.ToString(), "Restaurant", "parse");
            }
            return restaurant;
        }
    }
}
