using Kiosk.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk.db
{
    class DBProducts:DBModel
    {



        public void  resetProducts(AllProduct all_product, Restaurant restaurant )
        {
            //remove old data
            clearRestaurantFoods(restaurant);

            List<Category> categories = all_product.categories;
            //save new data
            foreach (Category c in categories)
            {
                values.Clear();
                values.Add("@id", c.id.ToString());
                values.Add("@restaurant_id", restaurant.id.ToString());
                values.Add("@name", c.name);
                values.Add("@image", c.image);
                db.insert("insert into categories (id, restaurant_id, name, image) values (@id, @restaurant_id, @name, @image)", values);
                foreach (Food f in c.foods)
                {
                    values.Clear();
                    values.Add("@id", f.id.ToString());
                    values.Add("@restaurant_id", restaurant.id.ToString());
                    values.Add("@category_id", c.id.ToString());
                    values.Add("@is_side", 0.ToString());
                    values.Add("@name", f.name);
                    values.Add("@price", f.price.ToString());
                    values.Add("@discount_percent", f.discount_percent.ToString());
                    values.Add("@d_price", f.d_price.ToString());
                    values.Add("@description", f.description);
                    values.Add("@image", f.image);
                    values.Add("@is_suggest", f.is_suggest.ToString());
                    values.Add("@is_available", f.is_available.ToString());

                    db.insert("insert into foods (id, restaurant_id, category_id, is_side, name, price, discount_percent, d_price, description, image, is_suggest, is_available) "
                    + "values (@id, @restaurant_id, @category_id, @is_side, @name, @price, @discount_percent, @d_price, @description, @image, @is_suggest, @is_available)", values);
                }
            }

            foreach(Food f in all_product.sides){
                values.Clear();
                values.Add("@id", f.id.ToString());
                values.Add("@restaurant_id", restaurant.id.ToString());
                values.Add("@category_id", 0.ToString());
                values.Add("@is_side", 1.ToString());
                values.Add("@name", f.name);
                values.Add("@price", f.price.ToString());
                values.Add("@discount_percent", f.discount_percent.ToString());
                values.Add("@d_price", f.d_price.ToString());
                values.Add("@description", f.description);
                values.Add("@image", f.image);
                values.Add("@is_suggest", 0.ToString());
                values.Add("@is_available", f.is_available.ToString());

                db.insert("insert into foods (id, restaurant_id, category_id, is_side, name, price, discount_percent, d_price, description, image, is_suggest, is_available) "
                + "values (@id, @restaurant_id, @category_id, @is_side, @name, @price, @discount_percent, @d_price, @description, @image, @is_suggest, @is_available)", values);
            }

        }

        private void clearRestaurantFoods(Restaurant rest)
        {
            values.Clear();
            values.Add("@restaurant_id", rest.id.ToString());
            db.delete("delete from foods where restaurant_id=@restaurant_id", values);
            db.delete("delete from categories where restaurant_id=@restaurant_id", values);
            db.close();
        }








        public AllProduct getProducts(Restaurant rest)
        {
            AllProduct all_product = new AllProduct();
            List<Category> categories = new List<Category>();
            Category category;
            List<Food> sides = new List<Food>();
            Food side;

            values.Clear();
            values.Add("@rest_id", rest.id.ToString());
            SqlDataReader dataReader = db.select("select * from categories where restaurant_id = @rest_id", values);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    category = new Category();
                    category.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                    category.restaurant_id = dataReader.GetInt32(dataReader.GetOrdinal("restaurant_id"));
                    category.name = dataReader.GetString(dataReader.GetOrdinal("name"));
                    category.image = dataReader.GetString(dataReader.GetOrdinal("image"));
                    categories.Add(category);
                }
            }

            db.close();

            foreach (Category c in categories)
            {
                Food food;
                values.Clear();
                values.Add("@category_id", c.id.ToString());
                dataReader = db.select("select * from foods where category_id = @category_id and is_side = 0", values);
                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        food = new Food();
                        food.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        food.restaurant_id = dataReader.GetInt32(dataReader.GetOrdinal("restaurant_id"));
                        food.category_id = dataReader.GetInt32(dataReader.GetOrdinal("category_id"));
                        food.is_side = dataReader.GetInt32(dataReader.GetOrdinal("is_side"));
                        food.name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        food.price = dataReader.GetInt32(dataReader.GetOrdinal("price"));
                        food.discount_percent = dataReader.GetInt32(dataReader.GetOrdinal("discount_percent"));
                        food.d_price = dataReader.GetInt32(dataReader.GetOrdinal("d_price"));
                        food.description = dataReader.GetString(dataReader.GetOrdinal("description"));
                        food.image = dataReader.GetString(dataReader.GetOrdinal("image"));
                        food.is_suggest = dataReader.GetInt32(dataReader.GetOrdinal("is_suggest"));
                        food.is_available = dataReader.GetInt32(dataReader.GetOrdinal("is_available"));

                        c.foods.Add(food);
                    }
                }

                db.close();
            }




            values.Clear();
            values.Add("@rest_id", rest.id.ToString());
            dataReader = db.select("select * from foods where restaurant_id = @rest_id and is_side = 1", values);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    side = new Food();
                    side.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                    side.restaurant_id = dataReader.GetInt32(dataReader.GetOrdinal("restaurant_id"));
                    side.category_id = dataReader.GetInt32(dataReader.GetOrdinal("category_id"));
                    side.is_side = dataReader.GetInt32(dataReader.GetOrdinal("is_side"));
                    side.name = dataReader.GetString(dataReader.GetOrdinal("name"));
                    side.price = dataReader.GetInt32(dataReader.GetOrdinal("price"));
                    side.discount_percent = dataReader.GetInt32(dataReader.GetOrdinal("discount_percent"));
                    side.d_price = dataReader.GetInt32(dataReader.GetOrdinal("d_price"));
                    side.description = dataReader.GetString(dataReader.GetOrdinal("description"));
                    side.image = dataReader.GetString(dataReader.GetOrdinal("image"));
                    side.is_suggest = dataReader.GetInt32(dataReader.GetOrdinal("is_suggest"));
                    side.is_available = dataReader.GetInt32(dataReader.GetOrdinal("is_available"));

                    sides.Add(side);
                }
            }

            db.close();

            all_product.categories = categories;
            all_product.sides = sides;

            return all_product;
        }
    }
}
