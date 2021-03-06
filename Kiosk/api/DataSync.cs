﻿using Kiosk.db_lite;
using Kiosk.model;
using Kiosk.preference;
using Kiosk.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk.api
{
    class DataSync
    {
        RRestaurant r_restaurant;
        RDevice r_device;

        EventHandler onSyncFinishedHandler;
        int restaurant_counter = 0;


        public DataSync()
        {
            r_device = new RDevice();
            r_restaurant = new RRestaurant();
        }



        public void syncAllData(EventHandler handler)
        {
            onSyncFinishedHandler += handler;
            restaurant_counter = 0;


            G.restaurants = new STRestaurant().getRestaurants();

            //sync orders
            syncOrders();
            Thread.Sleep(1000);

            //sync restaurants data
            r_device.getRestaurants(restaurantCallBack);

           

            
        }

        private void restaurantCallBack(object sender, EventArgs e)
        {
            List<Restaurant> rests = sender as List<Restaurant>;
            if (rests.Count == 0) return;
            STRestaurant st_rest = new STRestaurant();
            foreach (Restaurant rest in rests)
            {
                st_rest.updateRestaurantInfo(rest);
            }

            G.restaurants = st_rest.getRestaurants();




            //sync products
            foreach (Restaurant rest in G.restaurants)
            {
                //sync discounts
                r_restaurant.discounts(rest, discountsCallBack);
                Thread.Sleep(200);

                //sync products
                r_restaurant.products(rest, syncProductsCallBack);
                Thread.Sleep(1000);
            }


        }


        private void syncProductsCallBack(object sender, EventArgs e)
        {
            DBProducts db_products = new DBProducts();
            AllProduct all_product = sender as AllProduct;
            List<Category> categories = all_product.categories;
            List<Food> sides = sender as List<Food>;

            //if connection was success
            if (categories.Count != 0)
            {
                //find restaurant from products
                int restaurant_id = categories[0].restaurant_id;
                //save new products to local db
                if(findResturantWithId(restaurant_id) != null)
                    db_products.resetProducts(all_product, findResturantWithId(restaurant_id));
            }


            //sync data finished
            restaurant_counter++;
            if (G.restaurants.Count == restaurant_counter)
            {
                onSyncFinishedHandler(new object(), new EventArgs());
            }
        }


        private void discountsCallBack(object sender, EventArgs e)
        {
            List<Discount> discounts = sender as List<Discount>;
            DBRestaurant db_rest = new DBRestaurant();
            int restaurant_id;
            //no discount for restaurant
            if (discounts.Count == 0)
            {
                restaurant_id = discounts[0].restaurant_id;
                if (findResturantWithId(restaurant_id) != null)
                    db_rest.removeDiscounts(findResturantWithId(restaurant_id));
                return;
            }

            if (discounts.Count == 1)
            {
                //connection error
                if (discounts[0].id == 0)
                    return;
            }

            restaurant_id = discounts[0].restaurant_id;
            if (findResturantWithId(restaurant_id) != null)
            {
                db_rest.updateDiscounts(findResturantWithId(restaurant_id), discounts);
            }

        }









        public void syncOrders()
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
        

        private void syncOrdersCallBack(object sender, EventArgs e)
        {
            int status = (int)sender;
            if (status == 1)
            {
                DBOrder db_order = new DBOrder();
                db_order.removeOrders();
            }
        }








        private Restaurant findResturantWithId(int id)
        {
            foreach(Restaurant rest in G.restaurants)
            {
                if (rest.id == id) return rest;
            }
            return null;
        }

    }
}
