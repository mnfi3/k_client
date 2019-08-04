using Kiosk.model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Kiosk.control;

namespace Kiosk.api
{
    class RRestaurant
    {
        private EventHandler eventLogin = null;
        private EventHandler eventLogout = null;



        public void login(string user_name, string password, EventHandler handler)
        {
            Request request = new Request();
            eventLogin += handler;

            Dictionary<string, string> data = new Dictionary<string, string> { { "email", user_name }, { "password", password } };
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY } , {"k-token", G.device.token}};
            request.post(Urls.RESTAURANT_LOGIN, data, headers, loginCompleteCallBack);
        }

        private void loginCompleteCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            Restaurant restaurant;
            if (res.status == 1)
            {
                JObject data = res.data;
                JObject user = data["user"].Value<JObject>();
                restaurant = Restaurant.parse(user);
                string token = data["token"].Value<string>();
                restaurant.token = token;
            }
            else
            {
                restaurant = new Restaurant();
                MB.Show(res.message);
            }

            eventLogin(restaurant, new EventArgs());
        }







        public void logout(Restaurant rest, EventHandler handler)
        {
            Request request = new Request();
            eventLogout += handler;

            Dictionary<string, string> data = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, { "k-token", G.device.token }, { "Authorization", "Bearer " + rest.token } };
            request.post(Urls.RESTAURANT_LOGOUT, data, headers, logoutCompleteCallBack);
        }

        private void logoutCompleteCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            eventLogout(res, new EventArgs());
        }

    }
}
