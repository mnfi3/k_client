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









        public int saveShop(Restaurant restaurant, Cart cart, string payment_receipt)
        {

            //find id to order
            values.Clear();
            SqlDataReader dataReader = db.select("select top 1 * from orders order by id desc");
            int order_id = 0;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    int columnIndex;
                    columnIndex = dataReader.GetOrdinal("id");
                    order_id = dataReader.GetInt32(columnIndex);
                }
            }
            db.close();

            //save order
            values.Clear();
            order_id++;
            values.Add("@id", order_id.ToString());
            values.Add("@restaurant_id", restaurant.id.ToString());
            values.Add("@cost", cart.cost.ToString());
            values.Add("@d_cost", cart.d_cost.ToString());
            values.Add("@discount_id", cart.discount.id.ToString());
            values.Add("@payment_receipt", payment_receipt);
            DateTime datetime = DateTime.Now;
            values.Add("@time", datetime.ToString("yyyyMMddHHmmss"));
            db.insert("insert into orders (id, restaurant_id, cost, d_cost, discount_id, payment_receipt, time)"
                +" values"
                + " (@id, @restaurant_id, @cost, @d_cost, @discount_id, @payment_receipt, @time)", values);


            //find id to order_content
            values.Clear();
            dataReader = db.select("select top 1 * from orders_content order by id desc");
            int order_content_id = 0;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    int columnIndex;
                    columnIndex = dataReader.GetOrdinal("id");
                    order_content_id = dataReader.GetInt32(columnIndex);
                }
            }
            db.close();

            //save orders_content
            values.Clear();
            foreach (CartItem item in cart.items)
            {
                order_content_id++;
                values.Add("@id", order_content_id.ToString());
                values.Add("@product_id", item.product.id.ToString());
                values.Add("@order_id", order_id.ToString());
                values.Add("@cost", item.cost.ToString());
                values.Add("@count", item.count.ToString());
                values.Add("@dessert_size", item.desserts_size);
                db.insert("insert into orders_content (id, product_id, order_id, cost, count, dessert_size)"
                    + " values"
                    + " (@id, @product_id, @order_id, @cost, @count, @dessert_size)", values);
                //save order_content_desserts
                values.Clear();
                foreach (Dessert dessert in item.desserts)
                {
                    values.Clear();
                    values.Add("@orders_content_id", order_content_id.ToString());
                    values.Add("@dessert_id", dessert.id.ToString());
                    switch(item.desserts_size)
                    {
                        case "small" :
                            values.Add("@price", dessert.price_small.ToString());
                            break;
                        case "medium":
                            values.Add("@price", dessert.price_medium.ToString());
                            break;
                        case "large" :
                            values.Add("@price", dessert.price_large.ToString());
                            break;
                    }

                    db.insert("insert into order_content_desserts (orders_content_id, dessert_id, price)"
                    + " values"
                    + " (@orders_content_id, @dessert_id, @price)", values);
                }
            }


            return 1;
        }


    }

   
}
