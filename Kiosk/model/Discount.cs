using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class Discount
    {
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public string code { set; get; }
        public int percent { set; get; }
        public int count { set; get; }
        public string started_at { set; get; }
        public string invoked_at { set; get; }

        public bool is_valid { set; get; }

        public Discount()
        {
            id = 0;
            percent = 0;
        }
    }
}
