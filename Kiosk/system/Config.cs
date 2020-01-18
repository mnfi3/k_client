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
        //public const string DB_CONNECTION = "server=localhost;database=Kiosk;Integrated Security=true;";
        public const string SQLITE_DB_CONNECTION = "Data Source=kiosk_db.db;Version=3;UTF8Encoding=True;Compress=True;Password=" + G.PUBLIC_KEY + ";";
        public const double STAND_BY_TIME = 120000;//2 minute
        public const int SYNC_DATA_TIME = 120000;//2 minute
        public const string VERSION = "1.0.0.0";
        public const string APPLICATION_NAME = "KIOSK";
        public const string APPLICATION_SITE = "www.digiarta.com";
    }
}
