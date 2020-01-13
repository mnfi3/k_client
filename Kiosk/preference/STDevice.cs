using Kiosk.license;
//using Kiosk.license;
using Kiosk.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.preference
{
    class STDevice
    {
        //public const string KEY_DEVICE = "device";

        private static string json_string = null;
        private const string FOLDER = @"C:\digiarta\";
        private const string FILE = @"C:\digiarta\device.ark";



        public STDevice()
        {
            if (json_string != null) return;
            else init();
        }

        private void init(){
            if (!Directory.Exists(FOLDER)) System.IO.Directory.CreateDirectory(FOLDER);
            if (File.Exists(FILE))
            {
                read();
            }
            else
            {
                Device device = new Device();
                string json = JsonConvert.SerializeObject(device);
                save(json);
            }
            
        }

        private string read()
        {
            try
            {
                string json = File.ReadAllText(FILE);
                json_string = Crypt.DecryptString(json, G.PUBLIC_KEY);
                if (json_string.Contains("#fail"))
                {
                    Device device = new Device();
                    json = JsonConvert.SerializeObject(device);
                    save(json);
                }
                
            }
            catch (Exception e)
            {
            //    Device device = new Device();
            //    string json = JsonConvert.SerializeObject(device);
            //    save(json);
            }
            return json_string;
        }

        private void save(string json)
        {
            try
            {
                json_string = json;
                json = Crypt.EncryptString(json, G.PUBLIC_KEY);
                File.WriteAllText(FILE, json);
            }
            catch (Exception e) { }
        }





        public bool isLoggedIn()
        {
            read();
            Device device = JsonConvert.DeserializeObject<Device>(json_string);
            if (device.id == 0) return false;
            return true;
        }



        public Device getDevice()
        {
            string json = read();
            Device device = new Device();
            try
            {
                if (JsonConvert.DeserializeObject<Device>(json) != null)
                {
                    device = JsonConvert.DeserializeObject<Device>(json);
                }
            }
            catch (JsonException e)
            {}
            return device;
        }

        public void saveDevice(Device device)
        {
            string json = JsonConvert.SerializeObject(device);
            save(json);
        }

        public void logoutDevice()
        {
            Device device = new Device();
            save(JsonConvert.SerializeObject(device));
        }
    }
}
