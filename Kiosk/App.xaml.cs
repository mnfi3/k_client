﻿using System;
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
using Kiosk.api;

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
            G.X_API_KEY = Crypt.DecryptString("0c8z9sAo7anL6R5dzz3yeib0yHaWEyq4ktqrDaoLGv10JAxWvWh8b2QdCGH8lDV05MdvAyTpGULyPYfy0m42BQ==", G.PUBLIC_KEY);
            G.client_key = Security.getClientKey();
            DBDevice db_device = new DBDevice();
            G.device = db_device.getDevice();
            loginCheck();

            G.cart = new Cart();
            G.restaurants = new DBRestaurant().getRestaurants();
            G.setupTimer();
            G.isLoggedIn = db_device.isLoggedIn();


        }




        private void loginCheck()
        {
            RDevice r_device = new RDevice();
            r_device.loginCheck(loginCheckCallBack);
        }
        private void loginCheckCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            if (res.status == 0)
            {
                DBDevice db_device = new DBDevice();
                db_device.logoutDevice();
                G.isLoggedIn = false;
                G.device = db_device.getDevice();
            }
        }



        private void syncRestaurants()
        {
            foreach (Restaurant res in G.restaurants)
            {

            }
        }

        
    }
}
