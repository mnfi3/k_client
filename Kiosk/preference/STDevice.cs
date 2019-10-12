using Kiosk.license;
//using Kiosk.license;
using Kiosk.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.preference
{
    class STDevice
    {
        //public const string KEY_DEVICE = "device";

        public bool isLoggedIn()
        {
            string device = Properties.Settings.Default.device;
            if (device.Length < 5) return false;
            return true;
        }

        public Device getDevice()
        {
            Device device = new Device();
            string json = Properties.Settings.Default.device;
            //json = Crypt.DecryptString(json, G.PRIVATE_KEY);
            try
            {
                if (JsonConvert.DeserializeObject<Device>(json) != null)
                {
                    device = JsonConvert.DeserializeObject<Device>(json);
                    device.token = Crypt.DecryptString(device.token, G.PRIVATE_KEY);
                }
            }
            catch (JsonException e)
            {}
            return device;
        }

        public void saveDevice(Device device)
        {
            device.token = Crypt.EncryptString(device.token, G.PRIVATE_KEY);
            string json = JsonConvert.SerializeObject(device);
            //json = Crypt.EncryptString(json, G.PRIVATE_KEY);
            Properties.Settings.Default.device = json;
            Properties.Settings.Default.Save();
        }

        public void logoutDevice()
        {
            Properties.Settings.Default.device = "";
            Properties.Settings.Default.Save();
        }
    }
}
