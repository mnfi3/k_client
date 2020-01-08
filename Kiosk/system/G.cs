using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Kiosk.model;
using Kiosk.db;
using Kiosk.system;
using Kiosk.license;
using Kiosk.api;
using System.Threading;
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
        //public static System.Timers.Timer timer = new System.Timers.Timer();
        //public static System.Timers.Timer sync_products_timer;
        public static bool isLoggedIn = false;
        public const string PUBLIC_KEY = "kkkF19BEE2EF1yyy";
        public static string PRIVATE_KEY;

        //0c8z9sAo7anL6R5dzz3yeib0yHaWEyq4ktqrDaoLGv10JAxWvWh8b2QdCGH8lDV05MdvAyTpGULyPYfy0m42BQ==
        public static string X_API_KEY;

        //Display height & width
        public static double height{get;set;}
        public static double width{get;set;}




       
        
        //public static void setupTimer(ElapsedEventHandler handler, bool remove_old_timer = true)
        //{
        //    //remove old timer
        //    if(remove_old_timer) disableTimer();

        //    //config new timer
        //    timer = new System.Timers.Timer();
        //    timer.Interval = Config.STAND_BY_TIME;
        //    timer.Elapsed += new ElapsedEventHandler(handler);
        //    timer.AutoReset = false;
        //    timer.Enabled = true;
        //}

        //public static void disableTimer()
        //{
        //    timer.Stop();
        //    timer.Enabled = false;
        //    timer.Dispose();
        //    timer = null;
        //}





        public static Device getDevice(){
            //return new DBDevice().getDevice();
            return new STDevice().getDevice();
        }

        public static List<Restaurant> getRestaurants()
        {
            //DBRestaurant db_rest = new DBRestaurant();
            //return db_rest.getRestaurants();
            STRestaurant st_rest = new STRestaurant();
            return st_rest.getRestaurants();
        }






        //sync orders
        //private static Thread synThread = new Thread(() =>
        //    {
        //        Thread.CurrentThread.IsBackground = true;
        //        DBOrder db_order = new DBOrder();
        //        DBRestaurant db_rest = new DBRestaurant();
        //        ROrder r_order = new ROrder();
        //        Restaurant restaurant;
        //        int last_order_id = -2;
        //        while (last_order_id != -1)
        //        {
        //            last_order_id = db_order.getLastOrderId(last_order_id);
        //            if (last_order_id == -1) break;
        //            Order order = db_order.getOrder(last_order_id);
        //            if (order.id == -1) continue;
        //            restaurant = db_rest.getRestaurant(order.restaurant_id);
        //            r_order.syncOrder(restaurant, order, syncOrderCallBack);
        //            Thread.Sleep(1000);
        //        }
        //    });

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









        //sync products with server
        //public static void syncProducts()
        //{
        //    sync_products_timer = new System.Timers.Timer();
        //    sync_products_timer.Interval = Config.STAND_BY_TIME;
        //    sync_products_timer.Elapsed += on_sync_products_time_finished;
        //    sync_products_timer.AutoReset = true;
        //    sync_products_timer.Enabled = true;
        //}
        //private static void on_sync_products_time_finished(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    //Task.Run(() =>
        //    //{
        //        RRestaurant r_rest = new RRestaurant();
        //        r_rest.products(G.restaurant, productCallBack);
        //    //});
        //}
        //private static void productCallBack(object sender, EventArgs e)
        //{
        //     //Task.Run(() =>
        //     //{
        //         DBProducts db_products = new DBProducts();
        //         List<Category> categories = sender as List<Category>;
        //         if (categories.Count < 1) return;
        //         Restaurant restaurant = new Restaurant();
        //         restaurant.id = categories[0].restaurant_id;

        //         db_products.resetProducts(categories, restaurant);
        //     //});

        //}
       

        
    }

        
}
