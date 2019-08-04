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


        private HttpClient client;

        public Request()
        {
            client = new HttpClient();
        }


        public async void get(string url, Dictionary<string, string> data, Dictionary<string, string> headers, EventHandler eventHandler)
        {
            EventHandler dataReceivedHandler = null;
            dataReceivedHandler += eventHandler;

            url += "?";
            foreach (KeyValuePair<string, string> d in data)
            {
                url += d.Key + "=" + d.Value + "&";
            }

            foreach (KeyValuePair<string, string> header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            Response res = new Response();

            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var json = (JObject)JsonConvert.DeserializeObject(responseString);
                        try
                        {
                            res.status = json["status"].Value<Int32>();
                            res.message = json["message"].Value<string>();
                            res.data = json["data"].Value<JObject>();
                        }
                        catch (InvalidCastException e)
                        {

                        }
                    }
                    catch (JsonReaderException e)
                    {
                        res.message = "json parsing error";
                        res.status = -3;
                        res.data = new JObject();
                    }


                }
                else
                {
                    res.message = "server internal error";
                    res.status = -1;
                    res.data = new JObject();
                }
            }
            catch (HttpRequestException e)
            {
                res.message = "connection error";
                res.status = -2;
                res.data = new JObject();
            }

            dataReceivedHandler(res, new EventArgs());
        }




        public async void post(string url, Dictionary<string, string> data, Dictionary<string, string> headers, EventHandler eventHandler)
        {
            EventHandler dataReceivedHandler = null;
            dataReceivedHandler += eventHandler;

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
                    try
                    {
                        var json = (JObject)JsonConvert.DeserializeObject(responseString);
                        try
                        {
                            res.status = json["status"].Value<Int32>();
                            res.message = json["message"].Value<string>();
                            res.data = json["data"].Value<JObject>();
                        }
                        catch(InvalidCastException e)
                        {

                        }
                    }
                    catch (JsonReaderException e)
                    {
                        res.message = "json parsing error";
                        res.status = -3;
                        res.data = new JObject();
                    }
                }
                else
                {
                    res.message = "server internal error";
                    res.status = -1;
                    res.data = new JObject();
                }
            }
            catch (HttpRequestException e)
            {
                res.message = "connection error";
                res.status = -2;
                res.data = new JObject();
            }

            dataReceivedHandler(res, new EventArgs());
        }






        

    }
}
