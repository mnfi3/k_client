using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.api
{
    class Urls
    {
        public const string BASE_URL = "http://localhost:8080/kiosk/api";

        public const string DEVICE_LOGIN = BASE_URL + "/v1/kiosk/login";
        public const string DEVICE_LOGOUT = BASE_URL + "/v1/kiosk/logout";
        public const string DEVICE_LOGING_CHECK = BASE_URL + "/v1/kiosk/login/check";
        public const string DEVICE_RESTAURANTS = BASE_URL + "/v1/kiosk/users";


        public const string RESTAURANT_LOGIN = BASE_URL + "/v1/login";
        public const string RESTAURANT_LOGOUT = BASE_URL + "/v1/logout";


        public const string RESTAURANT_PRODUCTS = BASE_URL + "/v1/restaurant/products";

    }
}
