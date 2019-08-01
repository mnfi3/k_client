using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.api
{
    interface ISetOnDataReceived
    {
        void onReceived(int status, string message, string data);
    }
}
