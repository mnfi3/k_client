using Kiosk.license;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.preference 
{
    class Storage
    {

        //public static void upgrade()
        //{
        //    Properties.Settings.Default.Upgrade();
        //}

        public static void save(string setting_Name, string setting_Value)
        {
            Properties.Settings.Default[setting_Name] = Crypt.EncryptString(setting_Value, G.PRIVATE_KEY);
            Properties.Settings.Default.Save();
        }



        public static string get(string setting_Name)
        {
            string sResult = "";
            if (Properties.Settings.Default[setting_Name] != null)
            {
                sResult = Properties.Settings.Default[setting_Name].ToString();
            }
            if (sResult == "NaN" || sResult.Length < 1 || sResult == null)
            {
                sResult = "";
            }
            else
            {
                sResult = Crypt.DecryptString(sResult, G.PRIVATE_KEY);
                if (sResult == "#fail") sResult = "";
            }
            return sResult;
        }



        public static void remove(string key)
        {
            //save(key, "");
        }

    }
}
