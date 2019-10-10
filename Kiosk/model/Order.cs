using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Order
    {
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public string order_number { set; get; }
        public int is_out { set; get; }
        public int cost { set; get; }
        public int d_cost { set; get; }
        public int discount_id { set; get; }
        public string time { set; get; }
        public List<OrderContent> items { set; get; }



        //payment details
        public string pan { set; get; }
        public string req_id { set; get; }
        public string serial_transaction { set; get; }
        public string terminal_no { set; get; }
        public string trace_number { set; get; }
        public string transaction_date { set; get; }
        public string transaction_time { set; get; }



        public Order()
        {
            id = -1;
        }
    }
}
