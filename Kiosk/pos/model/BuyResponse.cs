using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.pos.model
{
    public class BuyResponse
    {
        public string AccountNo { set; get; }
        public string DiscountAmount { set; get; }
        public string PAN { set; get; }
        public string PcID { set; get; }
        public string ReasonCode { set; get; }
        public string ReqID { set; get; }
        public int ReturnCode { set; get; }
        public string SerialTransaction { set; get; }
        public string TerminalNo { set; get; }
        public string TotalAmount { set; get; }
        public string TraceNumber { set; get; }
        public string TransactionDate { set; get; }
        public string TransactionTime { set; get; }
    }
}
