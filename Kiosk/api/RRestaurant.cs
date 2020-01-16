using Kiosk.model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Kiosk.control;
using Kiosk.system;

namespace Kiosk.api
{
    class RRestaurant
    {
        private EventHandler eventLogin = null;
        private EventHandler eventLogout = null;
        private EventHandler eventProducts = null;
        private EventHandler eventDiscounts = null;
        private EventHandler eventDiscountValidate = null;



        public void login(string user_name, string password, EventHandler handler)
        {
            Request request = new Request();
            eventLogin += handler;

            Dictionary<string, string> data = new Dictionary<string, string> { { "email", user_name }, { "password", password } };
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY } , {"k-token", G.device.token}};
            request.post(Urls.RESTAURANT_LOGIN, data, headers, loginCompleteCallBack);
        }

        private void loginCompleteCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            Restaurant restaurant;
            if (res.status == 1)
            {
                JObject data = res.data;
                JObject user = data["user"].Value<JObject>();
                restaurant = Restaurant.parse(user);
                string token = data["token"].Value<string>();
                restaurant.token = token;
            }
            else
            {
                Log.e("error in restaurant login\t" + res.full_response, "RRestaurant", "login");
                MessageBox.Show(res.message);
                restaurant = new Restaurant();
            }

            eventLogin(restaurant, new EventArgs());
        }



        public void logout(Restaurant rest, EventHandler handler)
        {
            Request request = new Request();
            eventLogout += handler;

            Dictionary<string, string> data = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, { "k-token", G.device.token }, { "Authorization", "Bearer " + rest.token } };
            request.post(Urls.RESTAURANT_LOGOUT, data, headers, logoutCompleteCallBack);
        }

        private void logoutCompleteCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            eventLogout(res, new EventArgs());
        }







        public void products(Restaurant restaurant, EventHandler handler)
        {
            Request request = new Request();
            eventProducts += handler;

            Dictionary<string, string> data = new Dictionary<string, string> ();
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, { "k-token", G.device.token }, { "Authorization", "Bearer " + restaurant.token} };
            request.get(Urls.RESTAURANT_PRODUCTS, data, headers, productsCallBack);
        }


        private void productsCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            AllProduct all_products = new AllProduct();
            List<Category> categories = new List<Category>();
            Category category;

            List<Food> sides = new List<Food>();
            Food side;
            if (res.status == 1)
            {
                JObject data = res.data;
                JArray categories1 = data["categories"].Value<JArray>();
                for (int i = 0; i < categories1.Count; i++)
                {
                    category = Category.parse((JObject)categories1[i]);
                    categories.Add(category);
                }



                JArray sides1 = data["sides"].Value<JArray>();
                for (int i = 0; i < sides1.Count; i++)
                {
                    side = Food.parse((JObject)sides1[i]);
                    sides.Add(side);
                }


                all_products.categories = categories;
                all_products.sides = sides;

            }
            else
            {
                Log.e("error in restaurant produc sync\t" + res.full_response, "RRestaurant", "products");
            }

            //eventProducts(categories, new EventArgs());
            eventProducts(all_products, new EventArgs());
        }






        public void discounts(Restaurant restaurant, EventHandler handler)
        {
            Request request = new Request();
            eventDiscounts += handler;

            Dictionary<string, string> data = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, { "k-token", G.device.token }, { "Authorization", "Bearer " + restaurant.token } };
            request.get(Urls.RESTAURANT_DISCOUNTS, data, headers, discountsCallBack);
        }
        private void discountsCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            List<Discount> discounts = new List<Discount>();
            Discount d;
            if (res.status == 1)
            {
                JObject data = res.data;
                JArray discounts_obj = data["discounts"].Value<JArray>();
                for (int i = 0; i < discounts_obj.Count; i++)
                {
                    d = Discount.parse((JObject)discounts_obj[i]);
                    discounts.Add(d);
                }
            }
            else
            {
                discounts.Add(new Discount());
            }
            eventDiscounts(discounts, new EventArgs());
        }








        //public void checkDiscount(Restaurant restaurant, string discount_code, EventHandler handler)
        //{
        //    Request request = new Request();
        //    eventDiscountValidate += handler;

        //    Dictionary<string, string> data = new Dictionary<string, string> { { "discount_code", discount_code } };
        //    Dictionary<string, string> headers = new Dictionary<string, string> { { "x-api-key", G.X_API_KEY }, { "k-token", G.device.token }, { "Authorization", "Bearer " + restaurant.token } };
        //    request.post(Urls.RESTAURANT_DISCOUNT_VALIDATE, data, headers, discountCheckComplete);
        //}

        //private void discountCheckComplete(object sender, EventArgs e)
        //{
        //    Response res = sender as Response;
        //    Discount discount = new Discount();
        //    if (res.status == 1)
        //    {
        //        JObject data = res.data;
        //        discount.id = data["id"].Value<int>();
        //        discount.discount_percent = data["percent"].Value<int>();
        //        discount.code = data["code"].Value<string>();
        //        discount.is_valid = true;
        //    }
        //    else
        //    {
        //        discount.is_valid = false;
        //        discount.id = 0;
        //    }

        //    eventDiscountValidate(discount, new EventArgs());
        //}


    }
}
