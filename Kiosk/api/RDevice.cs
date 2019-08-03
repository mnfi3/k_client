using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using Kiosk.model;

namespace Kiosk.api
{
    class RDevice
    {
        private EventHandler eventLogin = null;
        private EventHandler eventLogout = null;



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
            }
            else
            {
                MessageBox.Show(res.message);
                device = new Device();
            }

            eventLogin(device, new EventArgs());
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

    }
}
