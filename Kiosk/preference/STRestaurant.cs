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
    class STRestaurant
    {
        //public const string KEY_RESTAURANTS = "restaurants";



        private static string json_string = null;
        private const string FOLDER = @"C:\digiarta\";
        private const string FILE = @"C:\digiarta\users.ark";



        public STRestaurant()
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
                List<Restaurant> rests = new List<Restaurant>();
                json = JsonConvert.SerializeObject(rests);
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








        public void setRestaurant(Restaurant restaurant)
        {
            if (restaurant.id == 0 || restaurant.token.Length < 5) return;

            List<Restaurant> restaurants = this.getRestaurants();
            foreach (Restaurant rest in restaurants)
            {
                if (rest.id == restaurant.id)
                {
                    var rest2 = restaurants.First(x => x.id == restaurant.id);
                    if (rest2 != null) restaurants.Remove(rest2);
                    break;
                }
            }
            restaurants.Add(restaurant);
            string json = JsonConvert.SerializeObject(restaurants);
            save(json);
        }


        public void removeRestaurant(Restaurant restaurant)
        {
            List<Restaurant> restaurants = this.getRestaurants();
            foreach (Restaurant rest in restaurants)
            {
                if (rest.id == restaurant.id)
                {
                    var rest2 = restaurants.First(x => x.id == restaurant.id);
                    if (rest2 != null) restaurants.Remove(rest2);
                    break;
                }
            }
            
            string json = JsonConvert.SerializeObject(restaurants);
            save(json);
        }


        public List<Restaurant> getRestaurants()
        {
            string json = read();
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            }
            catch (JsonException e) { }
            return restaurants;
        }

        public void updateRestaurantInfo(Restaurant restaurant)
        {
            List<Restaurant> restaurants = this.getRestaurants();
            int i = 0;
            foreach (Restaurant rest in restaurants)
            {
                if (rest.id == restaurant.id)
                {
                    Restaurant rest1 = restaurants[i];
                    restaurants.RemoveAt(i);
                    rest1.name = restaurant.name;
                    rest1.image = restaurant.image;
                    rest1.address = restaurant.address;
                    rest1.description = restaurant.description;
                    //update kiosk info
                    rest1.is_use_table_number = restaurant.is_use_table_number;
                    rest1.table_count = restaurant.table_count;
                    rest1.order_number_start = restaurant.order_number_start;
                    rest1.order_number_step = restaurant.order_number_step;

                    restaurants.Add(rest1);
                    break;
                    //var rest2 = restaurants.First(x => x.id == restaurant.id);
                    //if (rest2 != null) rest2 = restaurant;
                    //break;
                }
                i++;
            }
            
            string json = JsonConvert.SerializeObject(restaurants);
            save(json);
        }



        public void removeAll()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            string json = JsonConvert.SerializeObject(restaurants);
            save(json);
        }

    }
}
