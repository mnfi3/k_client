using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.model;
using Kiosk.db;
using System.Timers;
using System.Windows;
using Kiosk.system;

namespace Kiosk
{
    class G
    {
        public static string client_key;
        public static Cart cart;
        public static Device device;
        public static List<Restaurant> restaurants;
        public static Timer timer = new System.Timers.Timer();
        public static bool isLoggedIn = false;







        public static void setupTimer()
        {
            timer.Interval = 5000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //MessageBox.Show("time finish");
        }

        
    }




        
}
