using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using Kiosk.model;
using Kiosk.control;
using Kiosk.system;

namespace Kiosk.api
{
    class RDevice
    {
        private EventHandler eventLogin = null;
        private EventHandler eventLoginCheck = null;
        private EventHandler eventLogout = null;
        private EventHandler eventRestaurants = null;



        public void login(string user_name, string password, EventHandler handler)
        {
            Request request = new Request();
            eventLogin += handler;

            Dictionary<string,string> data = new Dictionary<string,string>{{"user_name", user_name}, {"client_key", G.client_key}, {"password", password}};
            Dictionary<string,string> headers = new Dictionary<string,string>{{"x-api-key", G.X_API_KEY}};
            request.post(Urls.DEVICE_LOGIN, data, headers, loginCompleteCallBack);
        }

        private void loginCompleteCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            Device device;
            if (res.status == 1)
            {
                JObject data = res.data;
                JObject kiosk = data["kiosk"].Value<JObject>();
                device = Device.parse(kiosk);
                string token = data["token"].Value<string>();
                device.token = token;
                Log.i("kiosk login was successfull", "RDevice" , "login");
            }
            else
            {
                MessageBox.Show(res.full_response);
                device = new Device();
                Log.e(res.full_response, "RDevice", "login");
            }

            eventLogin(device, new EventArgs());
        }



        public void loginCheck(EventHandler handler)
        {
            Request req = new Request();
            eventLoginCheck += handler;
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, { "k-token", G.getDevice().token } };
            req.get(Urls.DEVICE_LOGING_CHECK, new Dictionary<string, string>(), headers, loginCheckCallBack);
        }

        private void loginCheckCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            eventLoginCheck(res, new EventArgs());
            Log.i(res.full_response, "RDevice", "loginCheck");
        }






        public void logout(EventHandler handler)
        {
            Request request = new Request();
            eventLogout += handler;

            Dictionary<string, string> data = new Dictionary<string, string> ();
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, {"k-token", G.getDevice().token} };
            request.post(Urls.DEVICE_LOGOUT, data, headers, logoutCompleteCallBack);
        }

        private void logoutCompleteCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            eventLogout(res, new EventArgs());
        }








        public void getRestaurants( EventHandler handler)
        {
            Request request = new Request();
            eventRestaurants += handler;

            Dictionary<string, string> data = new Dictionary<string, string> ();
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, {"k-token", G.device.token} };
            request.get(Urls.DEVICE_RESTAURANTS, data, headers, restaurantsCallBack);
        }

        private void restaurantsCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            List<Restaurant> restaurants = new List<Restaurant>();
            Restaurant restaurant;
            if (res.status == 1)
            {
                JObject data = res.data;
                JArray kiosks = data["users"].Value<JArray>();
                for(int i=0 ; i<kiosks.Count ; i++)
                {
                    restaurant = Restaurant.parse((JObject)kiosks[i]);
                    restaurants.Add(restaurant);
                }

                Log.i("restaurants received", "RDevice", "getRestaurants");
            }
            else
            {
                Log.e(res.full_response, "RDevice", "getRestaurants");
            }

            eventRestaurants(restaurants, new EventArgs());
        }
    }
}
