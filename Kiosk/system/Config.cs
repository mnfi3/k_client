using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.system
{
    class Config
    {
        public const bool DEBUG = true;
        public const string DB_CONNECTION = "server=localhost;database=Kiosk;Integrated Security=true;";
        public const double STAND_BY_TIME = 20000;
    }
}
