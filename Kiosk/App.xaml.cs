using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kiosk.system;
using Kiosk.license;
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
            G.X_API_KEY = Crypt.DecryptString("0c8z9sAo7anL6R5dzz3yeib0yHaWEyq4ktqrDaoLGv10JAxWvWh8b2QdCGH8lDV05MdvAyTpGULyPYfy0m42BQ==", G.PUBLIC_KEY);
        }

        

        
    }
}
