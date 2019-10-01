using Kiosk.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.preference
{
    class STRestaurant
    {
        public const string KEY_RESTAURANTS = "restaurants";

        public void setRestaurant(Restaurant restaurant)
        {
            List<Restaurant> restaurants = this.getRestaurants();
            var rest = restaurants.First(x => x.id == restaurant.id);
            if (rest != null) restaurants.Remove(rest);
            restaurants.Add(restaurant);
            string json = JsonConvert.SerializeObject(restaurants);
            Properties.Settings.Default.restaurants = json;
            Properties.Settings.Default.Save();
        }


        public void removeRestaurant(Restaurant restaurant)
        {
            List<Restaurant> restaurants = this.getRestaurants();
            var rest = restaurants.First(x => x.id == restaurant.id);
            if (rest != null) restaurants.Remove(rest);
            string json = JsonConvert.SerializeObject(restaurants);
            Properties.Settings.Default.restaurants = json;
            Properties.Settings.Default.Save();
        }


        public List<Restaurant> getRestaurants()
        {
            string json = Properties.Settings.Default.restaurants;
            List<Restaurant> restaurants = new List<Restaurant>();
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
            var rest = restaurants.First(x => x.id == restaurant.id);
            if (rest != null) rest = restaurant;
            string json = JsonConvert.SerializeObject(restaurants);
            Properties.Settings.Default.restaurants = json;
            Properties.Settings.Default.Save();
        }


    }
}
