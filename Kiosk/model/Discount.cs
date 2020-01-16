using Kiosk.system;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Discount
    {
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public string code { set; get; }
        public int discount_percent { set; get; }
        public int count { set; get; }
        public string started_at { set; get; }
        public string invoked_at { set; get; }

        public bool is_valid { set; get; }

        public Discount()
        {
            id = 0;
            discount_percent = 0;
        }


        public static Discount parse(JObject obj)
        {
            Discount d = new Discount();
            try
            {
                d.id = obj["id"].Value<Int32>();
                d.restaurant_id = obj["user_id"].Value<Int32>();
                d.code = obj["code"].Value<string>();
                d.discount_percent = obj["percent"].Value<int>();
                d.count = obj["count"].Value<int>();
                d.started_at = obj["started_at"].Value<string>();
                d.invoked_at = obj["invoked_at"].Value<string>();
            }
            catch (Exception e) 
            {
                Log.e("json parsing error. json_text=" + obj.ToString() + "\terror=" + e.ToString(), "Discount", "parse");
            }
            return d;
        }
    }
}
