using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Kiosk.api
{

    class Request 
    {

        public event EventHandler DataReceivedHandler = null;

        private HttpClient client;

        public Request()
        {
            client = new HttpClient();
        }


        public async void post(string url, Dictionary<string, string> data, Dictionary<string, string> headers)
        {
           
            foreach (KeyValuePair<string, string> header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var content = new FormUrlEncodedContent(data);

            Response res = new Response();

            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);

            try
            {
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    res.data = responseString;
                    //DataReceivedHandler(res, new EventArgs());

                    try
                    {
                        var json = (JObject)JsonConvert.DeserializeObject(responseString);
                        res.status = json["status"].Value<Int32>();
                        MessageBox.Show(res.status.ToString());

                        res.message = json["message"].Value<string>();
                        res.data = json["data"].Value<string>();
                    }
                    catch (JsonReaderException e)
                    {
                        MessageBox.Show(e.ToString());
                    }

                   
                }
                else
                {
                    res.message = "error from server";
                    res.status = -1;
                    res.data = "no data";
                }
            }
            catch (HttpRequestException e)
            {
                res.message = "connection error";
                res.status = -2;
                res.data = "no data";
            }

            Response res2 = new Response() { status = 50, message = "message from local", data = "data from local"};

            DataReceivedHandler(res2, new EventArgs());
        }

        

    }
}
