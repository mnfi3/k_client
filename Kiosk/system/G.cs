using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Kiosk.model;
using Kiosk.db_lite;
using Kiosk.system;
using Kiosk.license;
using Kiosk.api;
using Kiosk.preference;

namespace Kiosk
{
    class G
    {
        public static string client_key;
        public static Cart cart;
        public static Device device;
        public static Restaurant restaurant;
        public static List<Restaurant> restaurants;
        public static bool isLoggedIn = false;
        public const string PUBLIC_KEY = "kkkF19BEE2EF1yyy";
        public static string PRIVATE_KEY;

        //0c8z9sAo7anL6R5dzz3yeib0yHaWEyq4ktqrDaoLGv10JAxWvWh8b2QdCGH8lDV05MdvAyTpGULyPYfy0m42BQ==
        public static string X_API_KEY;

        //Display height & width
        public static double height{get;set;}
        public static double width{get;set;}




        public static System.Timers.Timer getTimer(EventHandler handler, double time = Config.STAND_BY_TIME)
        {
            Timer timer = new Timer();
            timer.Interval = time;
            timer.Elapsed += new ElapsedEventHandler(handler);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
            return timer;
        }



        





        public static Device getDevice(){
            return new STDevice().getDevice();
        }

        public static List<Restaurant> getRestaurants()
        {
            STRestaurant st_rest = new STRestaurant();
            return st_rest.getRestaurants();
        }






      

        public static void syncOrders()
        {
            DBOrder db_order = new DBOrder();
            DBRestaurant db_rest = new DBRestaurant();
            ROrder r_order = new ROrder();
            List<Order> orders = new List<Order>();
            Order order;
            int last_order_id = -2;
            while (last_order_id != -1)
            {
                last_order_id = db_order.getLastOrderId(last_order_id);
                if (last_order_id == -1) break;
                order = db_order.getOrder(last_order_id);
                if (order.id == -1) continue;
                orders.Add(order);
            }

            if (orders.Count == 0) return;
            r_order.syncOrders(orders, syncOrdersCallBack);
        }


        private static void syncOrdersCallBack(object sender, EventArgs e)
        {
            int status = (int)sender;
            if (status == 1)
            {
                DBOrder db_order = new DBOrder();
                db_order.removeOrders();
            }
        }





        
        
    }

        
}
