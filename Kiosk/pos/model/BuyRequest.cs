using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.pos.model
{
    public class BuyRequest
    {
        public string ServiceCode { set; get; }
        public string Amount { set; get; }
        public string PayerId { set; get; }
        public string MerchantMsg { set; get; }
        public string PcID { set; get; }

        public BuyRequest()
        {
            ServiceCode = "1";
            PayerId = "12345";
        }
    }
}
