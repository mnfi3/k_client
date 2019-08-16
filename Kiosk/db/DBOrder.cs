using Kiosk.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.db
{
    class DBOrder:DBModel
    {
        public int saveOrder(Restaurant restaurant, Cart cart, string payment_receipt)
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
                + " values"
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
                    values.Add("@order_content_id", order_content_id.ToString());
                    values.Add("@dessert_id", dessert.id.ToString());
                    switch (item.desserts_size)
                    {
                        case "small":
                            values.Add("@price", dessert.price_small.ToString());
                            break;
                        case "medium":
                            values.Add("@price", dessert.price_medium.ToString());
                            break;
                        case "large":
                            values.Add("@price", dessert.price_large.ToString());
                            break;
                    }

                    db.insert("insert into order_content_desserts (order_content_id, dessert_id, price)"
                    + " values"
                    + " (@order_content_id, @dessert_id, @price)", values);
                }
            }


            return 1;
        }





        public int getLastOrderId(int current_id=-2)
        {
            int top_id = -1;
            values.Clear();
            values.Add("@current_id", current_id.ToString());
            SqlDataReader dataReader = db.select("select top 1 * from orders where id > @current_id order by id asc", values);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    top_id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                    break;
                }
            }

            db.close();
            return top_id;
        }



        public Order getOrder(int order_id)
        {
            Order order = new Order();
            //get order
            values.Clear();
            values.Add("@id", order_id.ToString());
            SqlDataReader dataReader = db.select("select top 1 * from orders where id=@id", values);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    order.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                    order.restaurant_id = dataReader.GetInt32(dataReader.GetOrdinal("restaurant_id"));
                    order.cost = dataReader.GetInt32(dataReader.GetOrdinal("cost"));
                    order.d_cost = dataReader.GetInt32(dataReader.GetOrdinal("d_cost"));
                    order.discount_id = dataReader.GetInt32(dataReader.GetOrdinal("discount_id"));
                    order.payment_receipt = dataReader.GetString(dataReader.GetOrdinal("payment_receipt"));
                    order.time = dataReader.GetString(dataReader.GetOrdinal("time"));
                    break;
                }
            }
            db.close();


            if (order.id == -1) return order;


            //get order items
            values.Clear();
            values.Add("@order_id", order_id.ToString());
            dataReader = db.select("select  * from orders_content where order_id=@order_id", values);
            order.items = new List<OrderContent>();
            OrderContent content;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    content = new OrderContent();
                    content.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                    content.order_id = dataReader.GetInt32(dataReader.GetOrdinal("order_id"));
                    content.product_id = dataReader.GetInt32(dataReader.GetOrdinal("product_id"));
                    content.cost = dataReader.GetInt32(dataReader.GetOrdinal("cost"));
                    content.count = dataReader.GetInt32(dataReader.GetOrdinal("count"));
                    content.dessert_size = dataReader.GetString(dataReader.GetOrdinal("dessert_size"));
                    order.items.Add(content);
                }
            }
            db.close();


            foreach (OrderContent item in order.items)
            {
                //get order items desserts
                values.Clear();
                values.Add("@order_content_id", item.id.ToString());
                dataReader = db.select("select  * from order_content_desserts where order_content_id=@order_content_id", values);
                item.desserts = new List<OrderContentDessert>();
                OrderContentDessert dessert;
                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        dessert = new OrderContentDessert();
                        dessert.order_content_id = dataReader.GetInt32(dataReader.GetOrdinal("order_content_id"));
                        dessert.dessert_id = dataReader.GetInt32(dataReader.GetOrdinal("dessert_id"));
                        dessert.price = dataReader.GetInt32(dataReader.GetOrdinal("price"));
                        item.desserts.Add(dessert);
                    }
                }

                db.close();
            }

            //var dataTable = new DataTable();
            //dataTable.Load(dataReader);
            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(dataTable);
            //JObject obj = new JObject();
            //obj.Add("order", "");
            //db.close();
            //new DialogTest(JSONString).ShowDialog();
            //MessageBox.Show(JSONString);
            return order;
        }



        public void removeOrder(int id)
        {
            Order order = getOrder(id);
            foreach (OrderContent oc in order.items)
            {
                values.Clear();
                values.Add("@order_content_id", oc.id.ToString());
                db.delete("delete from order_content_desserts where order_content_id=@order_content_id", values);
            }

            values.Clear();
            values.Add("@order_id", id.ToString());
            db.delete("delete from orders_content where order_id=@order_id", values);

            values.Clear();
            values.Add("@id", id.ToString());
            db.delete("delete from orders where id=@id", values);
        }


    }
}
