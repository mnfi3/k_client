using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kiosk.control;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using System.Windows.Media.Effects;
using Kiosk.model;
using Kiosk.system;
using Kiosk.api;
using Kiosk.db;
using Newtonsoft.Json;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using Stimulsoft.Report;
using Kiosk.pos.model;
using System.Windows.Media.Animation;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class CartView : Window
    {



        public CartView()
        {
            InitializeComponent();

            this.Height = G.height;
            this.Width = G.width;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadCartView();

            slideInRight();
        }

        




        private async void loadCartView()
        {
            ItemCart _item;
            lst_cart.Items.Clear();
            foreach (CartItem i in G.cart.items)
            {
                _item = new ItemCart(i, refreshCartViewEvent);
                lst_cart.Items.Add(_item);
                await Task.Delay(200);
            }

            txt_cost.Text = Utils.persian_split(G.cart.cost) + " تومان ";
            txt_d_cost.Text = Utils.persian_split(G.cart.d_cost) + " تومان ";
        }




       

        private void lst_cart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

       
        private void btn_back_to_restaurants_Click(object sender, RoutedEventArgs e)
        {
            //slideOutLeft();
            ListProducts _list = new ListProducts();
            _list.Show();
            this.Close();
        }


        private void txt_discount_code_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //BlurEffect blur = new BlurEffect();
            //grd_products.Effect = blur;
            //grd_pay.Effect = blur;

            VKeyboard _keyboard = new VKeyboard(ref txt_discount_code);
            if (_keyboard.ShowDialog() == true)
            {
                //grd_products.Effect = null;
                //grd_pay.Effect = null;
            }
        }

        private void btn_discount_Click(object sender, RoutedEventArgs e)
        {
            string discount_code = txt_discount_code.Text.ToString();
            RRestaurant r_rest = new RRestaurant();
            r_rest.checkDiscount(G.restaurant, discount_code, checkDiscountCodeComplete);
        }

        private void checkDiscountCodeComplete(object sender, EventArgs e)
        {
            Discount d = sender as Discount;
            if (d.is_valid)
            {
                G.cart.discount = d;
                txt_d_cost.Text = Utils.persian_split(G.cart.d_cost) + " تومان ";
                Toast.success("کد تخفیف با موفقیت اعمال شد");
            }
            else
            {
                Toast.error("کد تخفیف معتبر نمی باشد");
            }
        }




        private void btn_pay_Click(object sender, RoutedEventArgs e) 
        {
            if (G.cart.items.Count == 0)
            {
                Toast.error("هیچ محصولی در سبد خرید شما وجود ندارد");
                return;
            }


            BlurEffect blur = new BlurEffect();
            grd_main.Effect = blur;
            grd_pay.Effect = blur;
            Task.Delay(100);
            DialogPaymentAccept dialog = new DialogPaymentAccept(G.cart.d_cost);
            //dialog.ShowDialog();
            if (dialog.ShowDialog() == true)
            {
                DialogCartSwipe dialog2 = new DialogCartSwipe(G.cart.d_cost, paymentCallBack);
                dialog2.ShowDialog();
            }
            else
            {
                grd_main.Effect = null;
                grd_pay.Effect = null;
            }
        }


        private void paymentCallBack(object sender, EventArgs e)
        {
            //grd_main.Effect = null;
            //grd_pay.Effect = null;

            BuyResponse response = sender as BuyResponse;
            if (!response.success)
            {
                Toast.error(response.error, 5);
            }
            else
            {
                handleShop(response);
                Toast.success("پرداخت با موفقیت انجام شد.لطفا رسیدهای خود را دریافت نمایید", 4);

                ListRestaurant window = new ListRestaurant(true);
                window.Show();
                this.Close();
            }
            
           
        }





        private void refreshCartViewEvent(object sender, EventArgs e)
        {
            txt_cost.Text = Utils.persian_split(G.cart.cost) + " تومان ";
            txt_d_cost.Text = Utils.persian_split(G.cart.d_cost) + " تومان ";
        }




        public void handleShop(BuyResponse response)
        {
            DBOrder db_order = new DBOrder();
            db_order.saveOrder(G.restaurant, G.cart, "pay_receipt");
            db_order.saveReceipt(G.cart);
            printReceipt();
            G.cart.clear();
            loadCartView();
            G.syncOrders();
        }






        //private void syncOrders()
        //{
        //    DBOrder db_order = new DBOrder();
        //    DBRestaurant db_rest = new DBRestaurant();
        //    ROrder r_order = new ROrder();
        //    List<Order> orders = new List<Order>();
        //    Order order;
        //    int last_order_id = -2;
        //    while (last_order_id != -1)
        //    {
        //        last_order_id = db_order.getLastOrderId(last_order_id);
        //        if (last_order_id == -1) break;
        //        order = db_order.getOrder(last_order_id);
        //        if (order.id == -1) continue;
        //        orders.Add(order);
        //    }

        //    r_order.syncOrders(orders, syncOrdersCallBack);
        //}

        //private static void syncOrdersCallBack(object sender, EventArgs e)
        //{
        //    int status = (int)sender;
        //    if (status == 1)
        //    {
        //        DBOrder db_order = new DBOrder();
        //        db_order.removeOrders();
        //    }
        //}







        private void printReceipt()
        {
            //print test
            PrinterSettings setting;
            StiReport report = new StiReport();
            report.Load("Report.mrt");
            report.Compile();
            report["restaurant"] = G.restaurant.name;
            report["cost"] = Utils.persian_split(G.cart.cost) + " تومان ";
            report["d_cost"] = Utils.persian_split(G.cart.d_cost) + " تومان ";
            DateTime datetime = DateTime.Now;
            report["order_number"] = Utils.toPersianNum(G.restaurant.id.ToString() + datetime.ToString("HHmms"));
            //report.Printed += Report_Printed;
            //report.Printing += Report_Printing;
            foreach (Printer printer in G.restaurant.printers)
            {
                try
                {
                    setting = new PrinterSettings();
                    setting.PrinterName = printer.name;
                    report.Print(false, setting);
                }
                catch (Exception e)
                {

                }
            }
        }

        //private void Report_Printing(object sender, EventArgs e)
        //{
        //    //when printing
        //    //MessageBox.Show("printing");
        //}

        //private void Report_Printed(object sender, EventArgs e)
        //{
        //    //when printed
        //    //MessageBox.Show("printed");
        //}



        private void slideInRight()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(slideInFinished);
            slide.From = G.width;
            slide.To = 0;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            slide.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slide);
        }

        private void slideInFinished(object sender, EventArgs e)
        {
        }

        private void slideOutLeft()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(slideOutFinished);
            slide.From = 0;
            slide.To = -G.width;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            slide.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slide);
        }
        private void slideOutFinished(object sender, EventArgs e)
        {
            ListProducts _list = new ListProducts();
            _list.Show();
            this.Close();
        }

        
       


       
            
    }
}
