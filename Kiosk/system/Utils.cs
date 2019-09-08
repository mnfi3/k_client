using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.system
{
    class Utils
    {
        public static string persian_split(int price)
        {
            string text = String.Format("{0:n0}", price);
            text = text.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            return text;
        }

        public static string persian_split(string s)
        {
            int price = Int32.Parse(s);
            string text = String.Format("{0:n0}", price);
            text = text.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            return text;
        }

        public static string toPersianNum(string text)
        {
            text = text.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            return text;
        }

        public static string toPersianNum(int num)
        {
            string text = num.ToString();
            text = text.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            return text;
        }
    }
}
