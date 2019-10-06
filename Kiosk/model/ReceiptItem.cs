using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class ReceiptItem
    {
        public int num { set; get;}
        public string name { set; get;}
        public int price { set; get; }
        public int count { set; get; }
        public int cost { set; get; }


        public ReceiptItem()
        {
        }

    }
}
