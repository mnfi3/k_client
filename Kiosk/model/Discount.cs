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
        public int percent { set; get; }
        public string code { set; get; }

        public bool is_valid { set; get; }

        public Discount()
        {
            percent = 0;
        }
    }
}
