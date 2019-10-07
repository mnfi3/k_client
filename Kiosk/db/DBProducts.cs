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



        public void  resetProducts(List<Category> categories, Restaurant restaurant )
        {
            //remove old data
            clearRestaurantProducts(restaurant);

            //save new data
            foreach (Category c in categories)
            {

                values.Clear();
                values.Add("@id", c.id.ToString());
                values.Add("@restaurant_id", restaurant.id.ToString());
                values.Add("@name", c.name);
                values.Add("@image", c.image);
                db.insert("insert into categories (id, restaurant_id, name, image) values (@id, @restaurant_id, @name, @image)", values);
                foreach (Product p in c.products)
                {
                    values.Clear();
                    values.Add("@id", p.id.ToString());
                    values.Add("@restaurant_id", restaurant.id.ToString());
                    values.Add("@category_id", c.id.ToString());
                    values.Add("@name", p.name);
                    values.Add("@price", p.price.ToString());
                    values.Add("@discount_percent", p.discount_percent.ToString());
                    values.Add("@d_price", p.d_price.ToString());
                    values.Add("@description", p.description);
                    values.Add("@image", p.image);
                    db.insert("insert into products (id, restaurant_id, category_id, name, price, discount_percent, d_price, description, image) "
                        + "values (@id, @restaurant_id, @category_id, @name, @price, @discount_percent, @d_price, @description, @image)", values);

                    foreach (Dessert d in p.desserts)
                    {
                        values.Clear();
                        values.Add("@id", d.id.ToString());
                        values.Add("@product_id", p.id.ToString());
                        values.Add("@name", d.name.ToString());
                        values.Add("@type", d.type.ToString());
                        values.Add("@price", d.price.ToString());
                        values.Add("@image", d.image.ToString());
                        db.insert("insert into desserts (id, product_id, name, type, price, image) "
                            + "values (@id, @product_id, @name, @type, @price, @image)", values);
                    }
                }
            }

        }

        private void clearRestaurantProducts(Restaurant rest)
        {
            List<Category> categories = getProducts(rest);
            foreach (Category c in categories)
            {
                foreach (Product p in c.products)
                {
                    values.Clear();
                    values.Add("@product_id", p.id.ToString());
                    db.delete("delete from desserts where product_id=@product_id", values);
                }
                break;

            }

            values.Clear();
            values.Add("@restaurant_id", rest.id.ToString());
            db.delete("delete from products where restaurant_id=@restaurant_id", values);
            db.delete("delete from categories where restaurant_id=@restaurant_id", values);
        }








        public List<Category> getProducts(Restaurant rest)
        {
            List<Category> categories = new List<Category>();
            Category category;
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
                Product product;
                values.Clear();
                values.Add("@category_id", c.id.ToString());
                dataReader = db.select("select * from products where category_id = @category_id", values);
                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        product = new Product();
                        product.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        product.restaurant_id = dataReader.GetInt32(dataReader.GetOrdinal("restaurant_id"));
                        product.category_id = dataReader.GetInt32(dataReader.GetOrdinal("category_id"));
                        product.name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        product.price = dataReader.GetInt32(dataReader.GetOrdinal("price"));
                        product.discount_percent = dataReader.GetInt32(dataReader.GetOrdinal("discount_percent"));
                        product.d_price = dataReader.GetInt32(dataReader.GetOrdinal("d_price"));
                        product.description = dataReader.GetString(dataReader.GetOrdinal("description"));
                        product.image = dataReader.GetString(dataReader.GetOrdinal("image"));

                        c.products.Add(product);
                    }
                }

                db.close();



                foreach (Product p in c.products)
                {
                    Dessert dessert;
                    values.Clear();
                    values.Add("@product_id", p.id.ToString());
                    dataReader = db.select("select * from desserts where product_id = @product_id", values);
                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            dessert = new Dessert();
                            dessert.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                            dessert.product_id = dataReader.GetInt32(dataReader.GetOrdinal("product_id"));
                            dessert.name = dataReader.GetString(dataReader.GetOrdinal("name"));
                            dessert.type = dataReader.GetString(dataReader.GetOrdinal("type"));
                            dessert.price = dataReader.GetInt32(dataReader.GetOrdinal("price"));
                            dessert.image = dataReader.GetString(dataReader.GetOrdinal("image"));

                            p.desserts.Add(dessert);
                        }
                    }

                    db.close();
                }


            }
            return categories;
        }
    }
}
