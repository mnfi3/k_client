using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.model;
using Kiosk.pos.model;
using Kiosk.system;

namespace Kiosk.db_lite
{
    class DBOrder : DBModel
    {
        public int saveOrder(Restaurant restaurant, Cart cart, BuyResponse response)
        {

            //find id to order
            values.Clear();
            SQLiteDataReader dataReader = db.select("select  * from orders order by id desc limit 1");
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
            values.Add("@table_number", cart.table_number.ToString());
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

            db.insert("insert into orders (id, restaurant_id, order_number, table_number, is_out, cost, d_cost, discount_id, time, pan, req_id, serial_transaction, terminal_no, trace_number, transaction_date, transaction_time)"
                + " values"
                + " (@id, @restaurant_id, @order_number, @table_number, @is_out, @cost, @d_cost, @discount_id, @time, @pan, @req_id, @serial_transaction, @terminal_no, @trace_number, @transaction_date, @transaction_time)", values);


            //find id to order_item
            values.Clear();
            dataReader = db.select("select * from order_items order by id desc limit 1");
            int order_item_id = 0;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    int columnIndex;
                    columnIndex = dataReader.GetOrdinal("id");
                    order_item_id = dataReader.GetInt32(columnIndex);
                }
            }
            db.close();

            //save order_item
            foreach (CartItem item in cart.items)
            {
                order_item_id++;
                values.Clear();
                values.Add("@id", order_item_id.ToString());
                values.Add("@food_id", item.food.id.ToString());
                values.Add("@order_id", order_id.ToString());
                values.Add("@cost", item.cost.ToString());
                values.Add("@count", item.count.ToString());
                db.insert("insert into order_items (id, food_id, order_id, cost, count)"
                    + " values"
                    + " (@id, @food_id, @order_id, @cost, @count)", values);

            }


            return order_id;
        }





        public int getLastOrderId(int current_id = -2)
        {
            int top_id = -1;
            values.Clear();
            values.Add("@current_id", current_id.ToString());
            SQLiteDataReader dataReader = db.select("select * from orders where id > @current_id order by id asc limit 1", values);
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
            SQLiteDataReader dataReader = db.select("select * from orders where id=@id limit 1", values);
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
            dataReader = db.select("select  * from order_items where order_id=@order_id", values);
            order.items = new List<OrderItem>();
            OrderItem order_item;
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    order_item = new OrderItem();
                    order_item.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                    order_item.order_id = dataReader.GetInt32(dataReader.GetOrdinal("order_id"));
                    order_item.food_id = dataReader.GetInt32(dataReader.GetOrdinal("food_id"));
                    order_item.cost = dataReader.GetInt32(dataReader.GetOrdinal("cost"));
                    order_item.count = dataReader.GetInt32(dataReader.GetOrdinal("count"));

                    order.items.Add(order_item);
                }
            }
            db.close();


            return order;
        }



        public void removeOrder(int id)
        {
            Order order = getOrder(id);

            values.Clear();
            values.Add("@order_id", id.ToString());
            db.delete("delete from order_items where order_id=@order_id", values);

            values.Clear();
            values.Add("@id", id.ToString());
            db.delete("delete from orders where id=@id", values);
        }



        public void saveReceipt(Cart cart)
        {
            db.delete("delete from receipt");
            int num = 1;
            foreach (CartItem item in cart.items)
            {
                values.Clear();
                values.Add("@num", Utils.toPersianNum(num));
                values.Add("@name", item.food.name);
                values.Add("@price", Utils.persian_split(item.food.d_price));
                values.Add("@count", Utils.toPersianNum(item.count));
                values.Add("@cost", Utils.persian_split((item.count * item.food.d_price)));
                db.insert("insert into receipt (num, name, price, count, cost) values (@num, @name, @price, @count, @cost)", values);
                num++;
            }
        }



        public int getReceiptItemCount()
        {
            int i = 0;
            SQLiteDataReader dataReader = db.select("select * from receipt", values);
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
            db.delete("delete from orders");
            db.delete("delete from order_items");
        }

    }
}
