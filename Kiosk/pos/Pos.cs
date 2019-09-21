using Kiosk.pos.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk.pos
{
    class Pos
    {
        EventHandler responseHandler;
        public Pos(EventHandler handler)
        {
            responseHandler += handler;
        }



        public void requestBuy(BuyRequest buy)
        {
            BuyResponse buy_response = new BuyResponse();
            string requestJosn = JsonConvert.SerializeObject(buy);
            string responseJson = socketRequest(requestJosn);
            //string responseJson = httpRequest(requestJosn).Result;
            if (responseJson.Contains("[error]"))
            {
                responseJson = responseJson.Replace("[error]", "");
                buy_response.error = responseJson;
            }
            else
            {
                buy_response = JsonConvert.DeserializeObject<BuyResponse>(responseJson);
                if (buy_response.ReturnCode != 100)
                {
                    PosMessage mes = new PosMessage(buy_response.ReturnCode, buy_response.ReasonCode);
                    buy_response.error = mes.getMessage();
                    buy_response.success = false;
                }
                else
                {
                    buy_response.error = "";
                    buy_response.success = true;
                }
            }

            responseHandler(buy_response, new EventArgs());
        }






        private string socketRequest(String str_comm)
        {
            System.Net.Sockets.TcpClient client = null;
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                byte[] resvCommand = new byte[10025];
                client = new System.Net.Sockets.TcpClient(PosConf.IP, PosConf.PORT); // Create a new connection  
                if (!client.Connected)
                {
                    return "[error] لطفا پورت سرویس را بررسی نمایید";
                }
                NetworkStream stream = client.GetStream();
                byte[] sendCommand = Encoding.ASCII.GetBytes(str_comm);
                stream.Write(sendCommand, 0, sendCommand.Length);
                stream.ReadTimeout = PosConf.READ_TIMEOUT;
                int recvSize = stream.Read(resvCommand, 0, resvCommand.Length);
                string jsonStr = Encoding.UTF8.GetString(resvCommand);
                client.Close();
                return jsonStr;
            }
            catch (Exception ex)
            {
                try
                {
                    client.Close();
                    return "[error] " + ex.Message.ToString();
                }
                catch
                {
                    return "[error] خطا در ارتباط سوکت";
                }
            }
        }




        private async Task<string> httpRequest(string str_json)
        {
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(str_json);
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            var content = new FormUrlEncodedContent(data);
            //client.Timeout = TimeSpan.FromMilliseconds(PosConf.READ_TIMEOUT);
            client.Timeout = TimeSpan.FromMilliseconds(5000);

            try
            {
                var response = await client.PostAsync(PosConf.URL, content);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responseString = await response.Content.ReadAsStringAsync();
                MessageBox.Show(responseString);
                return responseString;
            }
            catch (HttpRequestException e)
            {
                return "[error] خطا در ارتباط با کارتخوان";
            }
        }


       

    }
}
