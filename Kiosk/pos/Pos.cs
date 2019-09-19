using Kiosk.pos.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk.pos
{
    class Pos
    {
        EventHandler responseHandler;
        public Pos(EventHandler res)
        {
            responseHandler += res;
        }



        public void requestBuy(BuyRequest buy)
        {
            string requestJosn = JsonConvert.SerializeObject(buy);
            string responseJson = request(requestJosn);
        }




        private string request(String str_comm)
        {
            System.Net.Sockets.TcpClient client = null;
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                byte[] resvCommand = new byte[10025];
                client = new System.Net.Sockets.TcpClient(PosConf.IP, PosConf.PORT); // Create a new connection  
                if (!client.Connected)
                {
                    return "[error] please check Service Port";
                }
                NetworkStream stream = client.GetStream();

                byte[] sendCommand = System.Text.Encoding.ASCII.GetBytes(str_comm);
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
                    return "[error] socket connection error";
                }
            }
        }
    }
}
