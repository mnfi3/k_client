using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kiosk.system;
using Kiosk.model;
using Kiosk.db;
using System.Timers;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            //configuration
            G.client_key = Security.getClientKey();
            DBDevice db_device = new DBDevice();
            G.cart = new Cart();
            G.device = db_device.getDevice();
            G.restaurants = new DBRestaurant().getRestaurants();
            G.setupTimer();
            G.isLoggedIn = db_device.isLoggedIn();
        }

        

        
    }
}
