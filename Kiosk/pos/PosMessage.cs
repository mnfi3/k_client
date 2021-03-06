﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.pos
{
    public class PosMessage
    {
        private Dictionary<string, string> returns = new Dictionary<string, string>();
        private Dictionary<string, string> reasons = new Dictionary<string, string>();
        private string message;


        public PosMessage(int ReturnCode, string ReasonCode)
        {
            string return_code = ReturnCode.ToString();
            string reason_code = ReasonCode.ToString();
            initReturnCodeMessages();

            if (ReturnCode == 109)
            {
                initReasonCodeMessages();
                if (reasons.ContainsKey(reason_code))
                {
                    this.message = reasons[reason_code];
                }
                else
                {
                    this.message = "خطا در پرداخت";
                }
            }
            else
            {
                if (returns.ContainsKey(return_code))
                {
                    this.message = returns[return_code];
                }
                else
                {
                    this.message = "خطا در پرداخت";
                }
            }
        }


        public string getMessage()
        {
            return this.message;
        }


        private void initReturnCodeMessages()
        {
            returns.Add("100", "فرآیند ارسال و دریافت اطلاعات با موفقیت انجام شد");
            returns.Add("101", "سایز پیام دریافتی از پوز نامعتبر است");
            returns.Add("102", "(پیام دریافتی از پی سی نامعتبراست(سایز پیام، نوع تراکنش");
            returns.Add("103", "نوع تراکنش دریافتی از پوز در پاسخ نامعتبر است");
            returns.Add("104", "مبلغ وارد شده یا مبلغ دریافتی از پوز در پاسخ نامعتبر است");
            returns.Add("105", "شناسه پرداخت وارد شده نامعتبر است");
            returns.Add("106", "زمان انتظار برای دریافت پاسخ از پوز در پورت سریال نا معتبر است");
            returns.Add("107", "زمان انتظار برای دریافت داده ها از پوز در پورت سریال به پایان رسید");
            returns.Add("108", "(تراکنش ناموفق:پاسخی از سرور دریافت نشد(زمان انتظار به پایان به پایان رسیده یا اتصال ناموفق بوده");
            returns.Add("109", "تراکنش ناموفق:موجودی کافی نیست یا مشکلی در سرور وجود دارد");
            returns.Add("110", "تراکنش ناموفق: خطای پرینتر");
            returns.Add("111", "تراکنش ناموفق: خطای ارتباط");
            returns.Add("112", "تراکنش ناموفق: خطا در ارسال تسویه، ریورسال یا ایجاد تراکنش");
            returns.Add("113", "نام پورت سریال وارد شده نامعتبر است");
            returns.Add("114", "تراکنش ناموفق: توسط کاربر لغو شد");
            returns.Add("115", "شناسه قبض وارد شده نامعتبر است");
            returns.Add("116", "شناسه پرداخت وارد شده نامعتبر است");
            returns.Add("117", "خطا در بازکردن پورت سریال");
            returns.Add("118", "خطای امنیتی: خطا در ارسال اطلاعات روی پورت سریال");
            returns.Add("119", "پورت انتخاب شده، پورت سریال نمی باشد");
            returns.Add("120", "یک یا چند مشخصه پورت سریال نامعتبر است");
            returns.Add("121", "آرگومان های متد نامعتبر است: نام پورت سریال نامعتبر است");
            returns.Add("122", "خطا در ارسال اطلاعات روی پوز: ورودی خالی است");
            returns.Add("123", "خطای پایان زمان در ارسال اطلاعات روی پورت سریال");
            returns.Add("124", "کارت روی پوز کشیده نشده است");
            returns.Add("125", "شناسه حساب نامعتبر است");
            returns.Add("126", "شناسه حساب دریافتی از دستگاه برای تراکنش پرداخت نامعتبر است");
            returns.Add("127", "شناسه حساب دریافتی از پوز برای تراکنش پرداخت نامعتبر است");
            returns.Add("128", "مبلغ دریافتی از دستگاه نامعتبر است");
            returns.Add("129", "شماره پیگیری دریافتی از پوز نامعتبر است");
            returns.Add("130", "شناسه قبض دریافتی از دستگاه نامعتبر است");
            returns.Add("131", "شناسه پرداخت دریافتی از دستگاه نامعتبر");
            returns.Add("132", "داده های اضافی دریافتی از دستگاه نامعتبر است");
            returns.Add("133", "مبلغ کل دریافتی از دستگاه در تراکنش پرداخت چندوجهی نامعتبر است");
            returns.Add("134", "داده های دریافتی از دستگاه تایید نشد");
            returns.Add("161", "داده های پرداخت چندوجهی نامعتبراست");
            returns.Add("162", "مبلغ وارد شده در پرداخت چندحسابی نامعتبر است");
            returns.Add("163", "شماره پیگیری وارد شده نامعتبر است");
            returns.Add("164", "داده های رسیده به پوز یا دستگاه نامعتبر است");
            returns.Add("165", "نوع اتصال وارد شده نامعتبر است");
            returns.Add("166", "پورت بستر tcp/ip وارد شده نامعتبر");
            returns.Add("167", "زمان وارد شده برای دریافت اطلاعات از پوز روی بستر tcp/ip نامعتبر است");
            returns.Add("169", "خطا در ارسال اطلاعات از پوز روی بستر tcp/ip");
            returns.Add("170", "خطا در دریافت اطلاعات از پوز روی بستر tcp/ip");
            returns.Add("171", "خطا در فرمت پیام پذیرنده");
            returns.Add("172", "خطا در آماده سازی اطلاعات برای ارسال");
            returns.Add("173", "خطا در دریافت اطلاعات از پوز");
            returns.Add("174", "خطا در دریافت اطلاعات از پوز(دریافت خالی)");
            returns.Add("175", "خطا در محاسبه CRC");
            returns.Add("176", "داده های اضافی پذیرنده نامعتبر است");
            returns.Add("200", "خطا در سیستم");
        }


        private void initReasonCodeMessages()
        {
            reasons.Add("0", "تراکنش با موفقیت انجام شد");
            reasons.Add("1", "به صادر کننده کارت ارجاع گردد");
            reasons.Add("2", "تراکنش اصلاحیه قبلي با موفقیت انجام شد");
            reasons.Add("3", "پذيرنده کارت نامعتبر است");
            reasons.Add("4", "پذيرنده کارت نامعتبر است");
            reasons.Add("5", "تراکنش نامعتبر است");
            reasons.Add("6", "خطای داخلي سويیچ صادر کننده کارت");
            reasons.Add("7", "شناسه قبض نادرست است");
            reasons.Add("8", "شناسه پرداخت نادرست است");
            reasons.Add("9", "درخواست قبلي در حال انجام است");
            reasons.Add("10", "تراکنش اصلي در سیستم موجود نمي باشد");
            reasons.Add("11", "کد پردازش تراکنش اصلي معتبر نمي باشد");
            reasons.Add("12", "رمز مورد نیاز است");
            reasons.Add("13", "مبلغ نامعتبر است");
            reasons.Add("14", "شماره کارت نامعتبر است");
            reasons.Add("15", "سرويس درخواستي موجود نمي باشد");
            reasons.Add("16", "شماره کارت با شماره کارت تراکنش اصلي يكسان نمي باشد");
            reasons.Add("17", "انجام تراکنش توسط کاربر لغو شد");
            reasons.Add("18", "در حال حاضر ارائه سرويس امكان پذير نمي باشد");
            reasons.Add("19", "تراکنش را دوباره انجام دهید");
            reasons.Add("20", "سیستم دچار اشكال شده است");
            reasons.Add("21", "عملي انجام نشد");
            reasons.Add("22", "خطای امنیتي رخ داده است");
            reasons.Add("23", "مبلغ کارمزد نامعتبر است");
            reasons.Add("24", "امكان اجرای تراکنش برگشت وجود ندارد تراکنش اصلي به صورت سیستمي برگشت خورده است");
            reasons.Add("25", "تراکنش مرجع موجود نیست");
            reasons.Add("26", "جمع مبلغ تراکنشهای برگشتي از تراکنش اصلي بیشتر ميباشد");
            reasons.Add("27", "مبلغ تراکنش اصلاحیه با تراکنش اصلي يكسان نمي باشد");
            reasons.Add("28", "تراکنش اصلي قبلا به صورت سیستمي برگشت خورده است");
            reasons.Add("29", "امكان انجام تراکنش اصلاحیه وجود ندارد");
            reasons.Add("30", "زمان درخواست خارج از بازه زماني اجرای عملیات مي باشد");
            reasons.Add("31", "صادر کننده کارت نامعتبر است");
            reasons.Add("32", "تراکنشي با اين شماره تسويه و شماره مشتری پیدا نشد");
            reasons.Add("33", "تاريخ انقضای کارت گذشته است");
            reasons.Add("34", "مشتری تراکنش برگشت با مشتری تراکنش اصلي يكسان نمي باشد");
            reasons.Add("35", "پذيرنده با بانک تماس بگیريد");
            reasons.Add("36", "کارت محدود شده است");
            reasons.Add("37", "نیازی به شناسه واريزنمي باشد");
            reasons.Add("38", "تعداد دفعات وارد کردن رمز بیش از حد مجاز است");
            reasons.Add("39", "حساب نامعتبر است");
            reasons.Add("40", "شناسه واريزتراکنش اصلي موجود نمي باشد");
            reasons.Add("41", "کارت نامعتبر است");
            reasons.Add("42", "برای اين hash code از طرف دارنده کارت تراکنش صورت نگرفت");
            reasons.Add("43", "زمان ارسال تراکنش از سمت پذيرنده همگون نیست");
            reasons.Add("44", "مشتری در سامانه متمرکز معتبر نمي باشد");
            reasons.Add("45", "شناسه واريزاجباری است و مقدار ندارد");
            reasons.Add("46", "حساب فروشنده مجوز برداشت غیر حضوری ندارد");
            reasons.Add("47", "نوع حساب مجوز واريز و يا برداشت ندارد");
            reasons.Add("48", "حساب مجوز واريز و يا برداشت ندارد");
            reasons.Add("49", "حساب فروشنده معتبر نمي باشد");
            reasons.Add("50", "تاريخ تراکنش اصلاحیه باتاريخ تراکنش اصلي متفاوت است");
            reasons.Add("51", "موجودی حساب کافي نیست");
            reasons.Add("52", "فرمت تاريخ تسويه اشتباه مي باشد");
            reasons.Add("53", "مشتری تراکنش اصلاحیه با مشتری تراکنش اصلي يكسان نمي باشد");
            reasons.Add("54", "مبلغ واريز از مینیمم مبلغ افتتاح حساب کمتر است");
            reasons.Add("55", "رمز نادرست است");
            reasons.Add("56", "امكان حذف اطلاعات مشتری وجود ندارد");
            reasons.Add("57", "دارنده کارت مجاز به انجام اين تراکنش نیست");
            reasons.Add("58", "پايانه مجاز به انجام اين تراکنش نیست");
            reasons.Add("59", "رمز شارژ با مبلغ مورد نظر موجود نیست");
            reasons.Add("60", "خطای داخلي در استخراج رمز شارژ");
            reasons.Add("61", "مبلغ برداشت وجه بیش از حد مجاز است");
            reasons.Add("62", "کد کالا نامعتبر است");
            reasons.Add("63", "خطای داخلي");
            reasons.Add("64", "اطلاعات تماس مشتری تعريف نشده است");
            reasons.Add("65", "دفعات برداشت وجه بیش از حد مجاز است");
            reasons.Add("66", "شعبه مشتری تعريف نشده است");
            reasons.Add("67", "حواله ای موجود نمي باشد");
            reasons.Add("68", "پاسخي از صادر کننده کارت دريافت نشد");
            reasons.Add("69", "شماره حساب/کارت مقصد نامعتبر است");
            reasons.Add("70", "کد کاربری يا رمز عبور نامعتبر است.");
            reasons.Add("71", "فرمت پیام اشتباه مي باشد.");
            reasons.Add("72", "مبلغ تراکنش از مبلغ کارمزد کوچكتراست");
            reasons.Add("73", "نوع مشتری حقیقي يا حقوقي نمي باشد");
            reasons.Add("74", "شرايط حساب فروشنده معتبر نمي باشد");
            reasons.Add("75", "کد رزرو تكراری است");
            reasons.Add("76", "شمار پیگیری تكراری است");
            reasons.Add("77", "تاريخ روزکاری نامعتبر است");
            reasons.Add("78", "شماره حساب/کارت مبداء با مقصد يكسان است");
            reasons.Add("79", "کارت غیر فعال است");
            reasons.Add("80", "حساب پذيرنده تعريف نشده است");
            reasons.Add("81", "اصلاحیه انتقال وجه قابل انجام نمي باشد");
            reasons.Add("82", "حساب اصلي کارت، حساب متصل به پايانه نمي باشد");
            reasons.Add("83", "صادر کننده کارت غیر فعال است");
            reasons.Add("84", "شناسه واريز صحیح نمي باشد");
            reasons.Add("85", "تراکنش صادر کننده نامعتبر است");
            reasons.Add("86", "سازمان صادر کننده قبض نامعتبر است");
            reasons.Add("87", "با بانک صادرکننده تماس بگیريد");
            reasons.Add("88", "پايانه نامعتبر است");
            reasons.Add("89", "بانک پذيرنده نامعتبر است");
            reasons.Add("90", "سیستم در حال انجام عملیات پايان روز کاری است ، بعدا سعي نمايید.");
            reasons.Add("91", "صادر کننده کارت در وضعیت عملیاتي نمي باشد");
            reasons.Add("92", "MAC نادرست است");
            reasons.Add("93", "خطا در تطابق MAC");
            reasons.Add("94", "تراکنش تكراری است");
            reasons.Add("95", "خطا در تطابق اطلاعات");
            reasons.Add("96", "کلیدهای ارتباطي موجود نمي باشد");
            reasons.Add("97", "خطا در تطابق کلیدهای رمزگذاری");
            reasons.Add("98", "خطای سیستمي ، دوباره سعي کنید");
            reasons.Add("99", "با پشتیباني تماس بگیريد");
        }


        
    }
}
