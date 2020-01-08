using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.model;
using Kiosk.license;
using System.Windows;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using Newtonsoft.Json;
using Kiosk.control;

namespace Kiosk.db
{
    class DBRestaurant:DBModel
    {
        public int setRestaurant(Restaurant restaurant)
        {
            values.Clear();
            values.Add("@id", restaurant.id.ToString());
            db.delete("delete from restaurants where id=@id", values);

            values.Clear();
            values.Add("@id", restaurant.id.ToString());
            values.Add("@user_name", restaurant.user_name);
            values.Add("@name", restaurant.name);
            values.Add("@image", restaurant.image);
            values.Add("@token", Crypt.EncryptString(restaurant.token, G.PRIVATE_KEY));
            return db.insert("insert into restaurants (id, user_name, name, image, token) values (@id, @user_name, @name, @image, @token)", values);
        }


        public int removeRestaurant(Restaurant restaurant)
        {
            values.Clear();
            values.Add("@id", restaurant.id.ToString());
            return db.delete("delete from restaurants where id=@id", values);
        }

        public List<Restaurant> getRestaurants(){
            List<Restaurant> restaurants = new List<Restaurant>();
            SqlDataReader dataReader = db.select("select * from restaurants");
             if (dataReader != null)
             {
                 Restaurant restaurant;
                 while (dataReader.Read())
                 {
                     restaurant = new Restaurant();
                     int columnIndex;
                     columnIndex = dataReader.GetOrdinal("id");
                     restaurant.id = dataReader.GetInt32(columnIndex);
                     columnIndex = dataReader.GetOrdinal("user_name");
                     restaurant.user_name = dataReader.GetString(columnIndex);
                     columnIndex = dataReader.GetOrdinal("name");
                     restaurant.name = dataReader.GetString(columnIndex);
                     columnIndex = dataReader.GetOrdinal("image");
                     restaurant.image = dataReader.GetString(columnIndex);
                     columnIndex = dataReader.GetOrdinal("token");
                     restaurant.token = Crypt.DecryptString(dataReader.GetString(columnIndex), G.PRIVATE_KEY);

                     restaurants.Add(restaurant);
                 }
             }

             db.close();

             return restaurants;
        }


        public int updateRestaurantInfo(Restaurant rest)
        {
            values.Clear();
            values.Add("@id", rest.id.ToString());
            values.Add("@name", rest.name);
            values.Add("@image", rest.image);
            return db.update("update restaurants set name=@name, image=@image where id=@id", values);
        }





        public List<Printer> getPrinters(Restaurant rest)
        {
            List<Printer> printers = new List<Printer>();
            Printer printer;
            values.Clear();
            values.Add("@id", rest.id.ToString());
            SqlDataReader dataReader = db.select("select * from printers where restaurant_id=@id", values);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    printer = new Printer();
                    printer.name = dataReader.GetString(dataReader.GetOrdinal("name"));
                    printers.Add(printer);
                }
            }

            db.close();
            return printers;
        }

        public void savePrinters(Restaurant rest, List<Printer> printers)
        {
            values.Clear();
            values.Add("@id", rest.id.ToString());
            db.delete("delete from printers where restaurant_id=@id", values);
            foreach (Printer p in printers)
            {
                values.Clear();
                values.Add("@id", rest.id.ToString());
                values.Add("@name", p.name);
                db.insert("insert into printers (restaurant_id, name) values (@id, @name)", values);
            }
        }




        public Restaurant getRestaurant(int id)
        {
            Restaurant restaurant = new Restaurant();
            values.Clear();
            values.Add("@id", id.ToString());
            SqlDataReader dataReader = db.select("select top 1 * from restaurants where id=@id", values);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    restaurant.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                    restaurant.user_name = dataReader.GetString(dataReader.GetOrdinal("user_name"));
                    restaurant.name = dataReader.GetString(dataReader.GetOrdinal("name"));
                    restaurant.image = dataReader.GetString(dataReader.GetOrdinal("image"));
                    restaurant.token = Crypt.DecryptString(dataReader.GetString(dataReader.GetOrdinal("token")), G.PRIVATE_KEY);
                    break;
                }
            }

            db.close();

            return restaurant;
        }




        public void updateDiscounts(Restaurant rest, List<Discount> discounts)
        {
            values.Clear();
            values.Add("@restaurant_id", rest.id.ToString());
            db.delete("delete from discounts where restaurant_id=@restaurant_id", values);
            foreach (Discount d in discounts)
            {
                values.Clear();
                values.Add("@id", d.id.ToString());
                values.Add("@restaurant_id", rest.id.ToString());
                values.Add("@code", d.code.ToString());
                values.Add("@discount_percent", d.discount_percent.ToString());
                values.Add("@count", d.count.ToString());
                values.Add("@started_at", d.started_at.ToString());
                values.Add("@invoked_at", d.invoked_at.ToString());

                //db.insert("insert into discounts (id, restaurant_id, code, discount_percent, count) values (@id, @restaurant_id, @code, @discount_percent, @count)", values);

                db.insert("insert into discounts (id, restaurant_id, code, discount_percent, count, started_at, invoked_at)" +
                   " values (@id, @restaurant_id, @code, @discount_percent, @count, @started_at, @invoked_at)", values);
            }
        }


        public void removeDiscounts(Restaurant rest){
            values.Clear();
            values.Add("@restaurant_id", rest.id.ToString());
            db.delete("delete from discounts where restaurant_id=@restaurant_id", values);
        }

        
    }

   
}
