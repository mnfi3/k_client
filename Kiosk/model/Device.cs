using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Device
    {
        public int id { set; get; }
        public string user_name { set; get; }
        public string name { set; get; }
        public string token { set; get; }
        public string client_key { set; get; }



        public Device()
        {
            id = 0;
            user_name = "";
            name = "";
            token = "";
            client_key = "";
        }

        public static Device parse(JObject kiosk){
            Device device = new Device();
            try
            {
                device.id = kiosk["id"].Value<Int32>();
                device.name = kiosk["name"].Value<string>();
                device.user_name = kiosk["user_name"].Value<string>();
                device.client_key = kiosk["client_key"].Value<string>();
            }
            catch (Exception e) { }
            return device;
        }
    }
}
