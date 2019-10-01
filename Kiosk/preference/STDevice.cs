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
            if (device == "") return false;
            return true;
        }

        public Device getDevice()
        {
            Device device = new Device();
            string json = Properties.Settings.Default.device;
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
