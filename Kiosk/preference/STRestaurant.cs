//using Kiosk.license;
using Kiosk.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk.preference
{
    class STRestaurant
    {
        public const string KEY_RESTAURANTS = "restaurants";

        public void setRestaurant(Restaurant restaurant)
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
            //var rest = restaurants.First(x => x.id == restaurant.id);
            //if (rest != null) restaurants.Remove(rest);
            restaurants.Add(restaurant);
            string json = JsonConvert.SerializeObject(restaurants);
            //json = Crypt.EncryptString(json, G.PRIVATE_KEY);
            Properties.Settings.Default.restaurants = json;
            Properties.Settings.Default.Save();
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
            Properties.Settings.Default.restaurants = json;
            Properties.Settings.Default.Save();
        }


        public List<Restaurant> getRestaurants()
        {
            string json = Properties.Settings.Default.restaurants;
            List<Restaurant> restaurants = new List<Restaurant>();
            //json = Crypt.DecryptString(json, G.PRIVATE_KEY);
            try
            {
                if (JsonConvert.DeserializeObject<List<Restaurant>>(json) != null)
                {
                    restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
                }
            }
            catch (JsonException e) { }
            return restaurants;
        }

        public void updateRestaurantInfo(Restaurant restaurant)
        {
            List<Restaurant> restaurants = this.getRestaurants();
            //if (restaurants.Count == 0) return;
            foreach (Restaurant rest in restaurants)
            {
                if (rest.id == restaurant.id)
                {
                    var rest2 = restaurants.First(x => x.id == restaurant.id);
                    if (rest2 != null) rest2 = restaurant;
                    break;
                }
            }
            
            string json = JsonConvert.SerializeObject(restaurants);
            //json = Crypt.EncryptString(json, G.PRIVATE_KEY);
            Properties.Settings.Default.restaurants = json;
            Properties.Settings.Default.Save();
        }


    }
}
