using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.system
{
    class Config
    {
        public const bool DEBUG = false;
        public const string DB_CONNECTION = "server=localhost;database=Kiosk;Integrated Security=true;";
        public const double STAND_BY_TIME = 20000;
        public const double SYNC_PRODUCTS_TIME = 2000;
    }
}
