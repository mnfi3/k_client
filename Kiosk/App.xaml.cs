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
using Kiosk.db_lite;
using System.Timers;
using Kiosk.api;
using Kiosk.preference;
using System.IO;
using System.Data.SqlClient;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Exit(object sender, ExitEventArgs e) {}



        public App()
        {


            //configuration
            getDisplayHeightAndWidth();

            G.X_API_KEY = Crypt.DecryptString("0c8z9sAo7anL6R5dzz3yeib0yHaWEyq4ktqrDaoLGv10JAxWvWh8b2QdCGH8lDV05MdvAyTpGULyPYfy0m42BQ==", G.PUBLIC_KEY);
            G.client_key = Security.getClientKey();
            G.PRIVATE_KEY = "kkk" + G.client_key + "yyy";
            //DBDevice db_device = new DBDevice();
            //G.device = db_device.getDevice();
            STDevice st_device = new STDevice();
            G.device = st_device.getDevice();


            
            loginCheck();

            G.cart = new Cart();
            //G.restaurants = new DBRestaurant().getRestaurants();
            //G.isLoggedIn = db_device.isLoggedIn();
            STRestaurant st_restaurant = new STRestaurant();
            G.restaurants = st_restaurant.getRestaurants();

            G.isLoggedIn = st_device.isLoggedIn();

            syncRestaurants();


            DBCreator creator = new DBCreator();
            Log.removeOldLogs();

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
                //DBDevice db_device = new DBDevice();
                //db_device.logoutDevice();
                //G.isLoggedIn = false;
                //G.device = db_device.getDevice();

                STDevice st_device = new STDevice();
                st_device.logoutDevice();
                G.isLoggedIn = false;
                G.device = st_device.getDevice();
            }
        }



        private void syncRestaurants()
        {
            RDevice r_device = new RDevice();
            r_device.getRestaurants(restaurantCallBack);
        }

        private void restaurantCallBack(object sender, EventArgs e)
        {
            List<Restaurant> rests = sender as List<Restaurant>;
            //DBRestaurant db_rest = new DBRestaurant();
            STRestaurant st_rest = new STRestaurant();
            foreach (Restaurant rest in rests)
            {
                //db_rest.updateRestaurantInfo(rest);
                st_rest.updateRestaurantInfo(rest);
            }

            G.restaurants = st_rest.getRestaurants();
        }

        private void getDisplayHeightAndWidth()
        {
            G.height = SystemParameters.PrimaryScreenHeight;
            G.width = SystemParameters.PrimaryScreenWidth;
        }

       





       



       
       


    }
}
