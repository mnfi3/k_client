using Kiosk.model;
using Kiosk.pos.model;
using Kiosk.system;
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
        public int saveOrder(Restaurant restaurant, Cart cart, BuyResponse response)
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
            values.Add("@is_out", cart.is_out.ToString());
            values.Add("@order_number", cart.order_number.ToString());
            values.Add("@cost", cart.cost.ToString());
            values.Add("@d_cost", cart.d_cost.ToString());
            values.Add("@discount_id", cart.discount.id.ToString());
            DateTime datetime = DateTime.Now;
            values.Add("@time", datetime.ToString("yyyyMMddHHmmss"));

            //payment details
            values.Add("@pan", response.PAN);
            values.Add("@req_id", response.ReqID);
            values.Add("@serial_transaction", response.SerialTransaction);
            values.Add("@terminal_no", response.TerminalNo);
            values.Add("@trace_number", response.TraceNumber);
            values.Add("@transaction_date", response.TransactionDate);
            values.Add("@transaction_time", response.TransactionTime);

            db.insert("insert into orders (id, restaurant_id, order_number, is_out, cost, d_cost, discount_id, time, pan, req_id, serial_transaction, terminal_no, trace_number, transaction_date, transaction_time)"
                + " values"
                + " (@id, @restaurant_id, @order_number, @is_out, @cost, @d_cost, @discount_id, @time, @pan, @req_id, @serial_transaction, @terminal_no, @trace_number, @transaction_date, @transaction_time)", values);


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
                db.insert("insert into orders_content (id, product_id, order_id, cost, count)"
                    + " values"
                    + " (@id, @product_id, @order_id, @cost, @count)", values);
                //save order_content_desserts
                values.Clear();
                foreach (Dessert dessert in item.desserts)
                {
                    values.Clear();
                    values.Add("@order_content_id", order_content_id.ToString());
                    values.Add("@dessert_id", dessert.id.ToString());
                    values.Add("@price", dessert.price.ToString());

                    db.insert("insert into order_content_desserts (order_content_id, dessert_id, price)"
                    + " values"
                    + " (@order_content_id, @dessert_id, @price)", values);
                }
            }


            return order_id;
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
                    order.order_number = dataReader.GetString(dataReader.GetOrdinal("order_number"));
                    order.is_out = dataReader.GetInt32(dataReader.GetOrdinal("is_out"));
                    order.cost = dataReader.GetInt32(dataReader.GetOrdinal("cost"));
                    order.d_cost = dataReader.GetInt32(dataReader.GetOrdinal("d_cost"));
                    order.discount_id = dataReader.GetInt32(dataReader.GetOrdinal("discount_id"));
                    order.time = dataReader.GetString(dataReader.GetOrdinal("time"));
                    order.pan = dataReader.GetString(dataReader.GetOrdinal("pan"));
                    order.req_id = dataReader.GetString(dataReader.GetOrdinal("req_id"));
                    order.serial_transaction = dataReader.GetString(dataReader.GetOrdinal("serial_transaction"));
                    order.terminal_no = dataReader.GetString(dataReader.GetOrdinal("terminal_no"));
                    order.trace_number = dataReader.GetString(dataReader.GetOrdinal("trace_number"));
                    order.transaction_date = dataReader.GetString(dataReader.GetOrdinal("transaction_date"));
                    order.transaction_time = dataReader.GetString(dataReader.GetOrdinal("transaction_time"));
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



        public void saveReceipt(Cart cart)
        {
            db.delete("truncate table receipt");
            int num = 1;
            foreach (CartItem item in cart.items)
            {
                values.Clear();
                values.Add("@num", Utils.toPersianNum(num));
                values.Add("@name", item.product.name);
                values.Add("@price", Utils.persian_split(item.product.d_price));
                values.Add("@count", Utils.toPersianNum(item.count));
                values.Add("@cost", Utils.persian_split((item.count * item.product.d_price)));
                db.insert("insert into receipt (num, name, price, count, cost) values (@num, @name, @price, @count, @cost)", values);
                num++;
                foreach (Dessert dessert in item.desserts)
                {
                    values.Clear();
                    values.Add("@num", Utils.toPersianNum(num));
                    values.Add("@name", dessert.name);
                    values.Add("@price", Utils.persian_split(dessert.price));
                    values.Add("@count", Utils.toPersianNum(item.count));
                    values.Add("@cost", Utils.persian_split((item.count * dessert.price)));
                    db.insert("insert into receipt (num, name, price, count, cost) values (@num, @name, @price, @count, @cost)", values);
                    num++;
                }
            }
        }



        public int getReceiptItemCount()
        {
            int i = 0;
            SqlDataReader dataReader = db.select("select * from receipt", values);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    i++;
                }
            }

            db.close();

            return i;
        }


        public void removeOrders()
        {
            db.delete("truncate table orders");
            db.delete("truncate table orders_content");
            db.delete("truncate table order_content_desserts");
        }

    }
}
