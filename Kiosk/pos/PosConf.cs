using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.pos
{
    class PosConf
    {
        public const int READ_TIMEOUT = 180000;
        public const string IP = "127.0.0.1";
        public const int PORT = 1024;
        public static string URL = "http://localhost:" + PORT + "/bpmpospc/service";

    }
}
