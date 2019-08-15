using Kiosk.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.api
{
    class ROrder
    {
        private EventHandler eventOrder = null;


        public void syncOrder(Restaurant restaurant, Order order, EventHandler handler)
        {
            Request request = new Request();
            eventOrder += handler;

            Dictionary<string, string> data = new Dictionary<string, string> { { "order", JsonConvert.SerializeObject(order) }};
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, { "k-token", G.device.token }, { "Authorization", "Bearer " + restaurant.token } };
            request.post(Urls.RESTAURANT_LOGIN, data, headers, syncOrderCallBack);
        }

        private void syncOrderCallBack(object sender, EventArgs e)
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
            }

            eventOrder(restaurant, new EventArgs());
        }
    }
}
