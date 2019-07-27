using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    class Category
    {
        public int id { set; get; }
        public int restaurant_id { set; get; }
        public string name { set; get; }
        public string image { set; get; }
    }
}
