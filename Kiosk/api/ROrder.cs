using Kiosk.control;
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
            request.post(Urls.RESTAURANT_ORDER, data, headers, syncOrderCallBack);
        }

        private void syncOrderCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            int order_id = -1;
            if (res.status == 1)
            {
                JObject data = res.data;
                order_id = data["order_id"].Value<int>();
                //new DialogTest(res.full_response).ShowDialog();
            }
            else
            {
                //new DialogTest(res.full_response).ShowDialog();
            }

            eventOrder(order_id, new EventArgs());
        }
    }
}
