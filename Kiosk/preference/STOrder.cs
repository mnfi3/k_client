using Kiosk.license;
//using Kiosk.license;
//using Kiosk.license;
using Kiosk.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk.preference
{
    class STOrder
    {
        //public const string KEY_RESTAURANTS = "restaurants";



        private static string json_string = null;
        private const string FOLDER = @"C:\digiarta\";
        private const string FILE = @"C:\digiarta\order.ark";



        public STOrder()
        {
            if (json_string != null) return;
            else init();
        }

        private void init(){
            if (!Directory.Exists(FOLDER)) System.IO.Directory.CreateDirectory(FOLDER);
            if (File.Exists(FILE))
            {
                read();
            }
            else
            {
                Device device = new Device();
                string json = JsonConvert.SerializeObject(device);
                save(json);
            }
            
        }

        private string read()
        {
            string json = File.ReadAllText(FILE);
            json_string = Crypt.DecryptString(json, G.PUBLIC_KEY);
            if (json_string.Contains("#fail"))
            {
                List<OrderNumber> order_numbers = new List<OrderNumber>();
                json = JsonConvert.SerializeObject(order_numbers);
                save(json);
            }  

            return json_string;
        }

        private void save(string json)
        {
            try
            {
                json_string = json;
                json = Crypt.EncryptString(json, G.PUBLIC_KEY);
                File.WriteAllText(FILE, json);
            }
            catch (Exception e) { }
        }







        public void setOrderNumber(OrderNumber order_number)
        {
            List<OrderNumber> order_numbers = this.getOrderNumbers();
            foreach (OrderNumber num in order_numbers)
            {
                if (num.restaurant_id == order_number.restaurant_id)
                {
                    var rest2 = order_numbers.First(x => x.restaurant_id == order_number.restaurant_id);
                    if (rest2 != null) order_numbers.Remove(rest2);
                    break;
                }
            }
            order_numbers.Add(order_number);
            string json = JsonConvert.SerializeObject(order_numbers);
            save(json);
        }


       


        public List<OrderNumber> getOrderNumbers()
        {
            string json = read();
            List<OrderNumber> order_numbers = new List<OrderNumber>();
            try
            {
                order_numbers = JsonConvert.DeserializeObject<List<OrderNumber>>(json);
            }
            catch (JsonException e) { }
            return order_numbers;
        }


        public int generateOrderNumber(Restaurant restaurant)
        {
            List<OrderNumber> order_numbers = getOrderNumbers();
            string now = DateTime.Now.ToString("yyyyMMdd");
            foreach (OrderNumber num in order_numbers)
            {
                if (num.restaurant_id == restaurant.id)
                {
                    if (num.date == now)
                    {
                        if (num.start_number != restaurant.order_number_start)
                        {
                            num.start_number = restaurant.order_number_start;
                            num.last_number = restaurant.order_number_start;
                        }
                        else
                        {
                            num.last_number += restaurant.order_number_step;
                        }
                        
                        string json = JsonConvert.SerializeObject(order_numbers);
                        save(json);
                        return num.last_number;
                    }
                    else
                    {
                        num.date = now;
                        num.start_number = restaurant.order_number_start;
                        num.last_number = restaurant.order_number_start;
                        string json = JsonConvert.SerializeObject(order_numbers);
                        save(json);
                        return num.last_number;
                    }
                }
            }


            //first save
            OrderNumber order_number = new OrderNumber();
            order_number.restaurant_id = restaurant.id;
            order_number.date = now;
            order_number.start_number = restaurant.order_number_start;
            order_number.last_number = restaurant.order_number_start;
            setOrderNumber(order_number);


            return order_number.last_number;
        }

       



        

    }
}
