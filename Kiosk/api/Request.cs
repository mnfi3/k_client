﻿using System;
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
using Kiosk.system;

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

            client.DefaultRequestHeaders.Add("Accept","application/json");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            foreach (KeyValuePair<string, string> header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
            //add kiosk version header
            client.DefaultRequestHeaders.Add("k-version", Config.VERSION);

            Response res = new Response();

            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);

            try
            {
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                res.full_response = responseString;
                if (response.IsSuccessStatusCode)
                {
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
                            Log.e("error in url:" + url + "\t" + e.ToString(), "Request", "get");
                        }
                    }
                    catch (JsonReaderException e)
                    {
                        res.message = "json parsing error";
                        res.status = -3;
                        res.data = new JObject();
                        Log.e("json parsing error in url:" + url + "\t" + e.ToString(), "Request", "get");
                    }


                }
                else
                {
                    res.message = "server internal error";
                    res.status = -1;
                    res.data = new JObject();
                    Log.e("server internal error in url:" + url + "\t" , "Request", "get");
                }
            }
            catch (HttpRequestException e)
            {
                res.message = "connection error";
                res.status = -2;
                res.data = new JObject();
                Log.e("connection error in url:" + url + "\t" + e.ToString(), "Request", "get");
            }

            dataReceivedHandler(res, new EventArgs());
        }




        public async void post(string url, Dictionary<string, string> data, Dictionary<string, string> headers, EventHandler eventHandler)
        {
            EventHandler dataReceivedHandler = null;
            dataReceivedHandler += eventHandler;

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            foreach (KeyValuePair<string, string> header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
            //add kiosk version header
            client.DefaultRequestHeaders.Add("k-version", Config.VERSION);

            var content = new FormUrlEncodedContent(data);

            Response res = new Response();

            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);

            try
            {
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                res.full_response = responseString;
                if (response.IsSuccessStatusCode)
                {
                    
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
                            Log.e("error in url:" + url + "\t" + e.ToString(), "Request", "post");
                        }
                    }
                    catch (JsonReaderException e)
                    {
                        res.message = "json parsing error";
                        res.status = -3;
                        res.data = new JObject();
                        Log.e("json parsing error in url:" + url + "\t" + e.ToString(), "Request", "post");
                    }
                }
                else
                {
                    res.message = "server internal error";
                    res.status = -1;
                    res.data = new JObject();
                    Log.e("server internal error in url:" + url + "\t", "Request", "post");
                }
            }
            catch (HttpRequestException e)
            {
                res.message = "connection error";
                res.status = -2;
                res.data = new JObject();
                Log.e("connection error in url:" + url + "\t" + e.ToString(), "Request", "post");
            }

            dataReceivedHandler(res, new EventArgs());
        }






        

    }
}
