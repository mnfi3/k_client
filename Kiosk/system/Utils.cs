using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static string toLatin(string text)
        {
            text = text.Replace("۰","0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
            return text;
        }

        //public static int toLatin(string text)
        //{
        //    text = text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        //    return Int32.Parse(text);
        //}


        public static string getPersianDateTimeString()
        {
            DateTime date_time = DateTime.Now;
            string time = date_time.ToString("HH:mm");
            var calendar = new PersianCalendar();
            string date = calendar.GetYear(date_time) + "/" + calendar.GetMonth(date_time) + "/" + calendar.GetDayOfMonth(date_time);
            time = date + "\n" + time;
            return time;
        }
    }
}
