﻿using System;
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

        public const string RESTAURANT_LOGIN = BASE_URL + "/v1/login";
        public const string RESTAURANT_LOGOUT = BASE_URL + "/v1/logout";
    }
}
