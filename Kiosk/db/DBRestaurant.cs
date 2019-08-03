using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.model;
using Kiosk.license;
using System.Windows;
using System.Data.SqlClient;

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
            values.Add("@token", Crypt.EncryptString(restaurant.token, G.PUBLIC_KEY));
            return db.insert("insert into restaurants (id, user_name, name, image, token) values (@id, @user_name, @name, @image, @token)", values);
        }


        public int removeRestaurant(Restaurant restaurant)
        {
            values.Clear();
            values.Add("@id", restaurant.id.ToString());
            return db.delete("delete from restaurants where id = @id");
        }

        public List<Restaurant> getRestaurants(){
            List<Restaurant> restaurants = new List<Restaurant>();
            SqlDataReader dataReader = db.select("select * from restaurants");
             if (dataReader != null)
             {
                 Restaurant restaurant = new Restaurant();
                 while (dataReader.Read())
                 {
                     int columnIndex;
                     columnIndex = dataReader.GetOrdinal("id");
                     restaurant.id = dataReader.GetInt32(columnIndex);
                     columnIndex = dataReader.GetOrdinal("user_name");
                     restaurant.user_name = dataReader.GetString(columnIndex);
                     columnIndex = dataReader.GetOrdinal("name");
                     restaurant.name = dataReader.GetString(columnIndex);
                     columnIndex = dataReader.GetOrdinal("image");
                     restaurant.name = dataReader.GetString(columnIndex);
                     columnIndex = dataReader.GetOrdinal("token");
                     restaurant.token = Crypt.EncryptString(dataReader.GetString(columnIndex), G.PUBLIC_KEY);

                     restaurants.Add(restaurant);
                 }
             }

             db.close();

             return restaurants;
        }
    }
}
