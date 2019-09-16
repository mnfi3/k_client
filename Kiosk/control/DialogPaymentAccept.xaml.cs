using Kiosk.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for DialogPaymentAccept.xaml
    /// </summary>
    public partial class DialogPaymentAccept : Window
    {
        private int price = 0;
        private int step = 0;
        bool result;


        public DialogPaymentAccept()
        {
            InitializeComponent();
        }

        public DialogPaymentAccept(int p)
        {
            InitializeComponent();
            price = p;

            step = price / 70 + 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_price.Text = Utils.persian_split(0) + " تومان ";
            slideInBottom();
        }




        private void slideInBottom()
        {
            DoubleAnimation slideAnim = new DoubleAnimation();
            slideAnim.From = G.height;
            slideAnim.To = G.height / 2 - 150;
            slideAnim.Completed += new EventHandler(slideInFinished);
            slideAnim.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            slideAnim.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slideAnim);
        }
        private void slideInFinished(object sender, EventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(ThreadJob));
            //t.IsBackground = true;
            //t.Start();         

            priceCounter();
        }


        private void slideOutBottom()
        {
            DoubleAnimation slideAnim = new DoubleAnimation();
            slideAnim.Completed += new EventHandler(slideOutFinished);

            slideAnim.From = G.height / 2 - 150;
            slideAnim.To = G.height;
            slideAnim.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            slideAnim.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slideAnim);
        }
        private void slideOutFinished(object sender, EventArgs e)
        {
            DialogResult = result;
        }



        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            result = true;
            slideOutBottom();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            result = false;
            slideOutBottom();
        }



        //private  void ThreadJob()
        //{
        //    int counter = 0;
        //    for (int i = 0; i <= 10000; i+=1)
        //    {
        //        counter += step;   
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            if (counter < price)
        //            {
        //                txt_price.Text = Utils.persian_split(counter) + " تومان ";
        //                Thread.Sleep(6);
        //            }
        //            else
        //            {
        //                txt_price.Text = Utils.persian_split(price) + " تومان ";
        //                return;
        //            }
        //        }));
        //    }
        //}

        private async void priceCounter()
        {
            int counter = 0;
            for (int i = 0; i <= 10000; i += 1)
            {
                counter += step;
                if (counter < price)
                {
                    txt_price.Text = Utils.persian_split(counter) + " تومان ";
                    await Task.Delay(6);
                }
                else
                {
                    txt_price.Text = Utils.persian_split(price) + " تومان ";
                    return;
                }
            }
        }
       

      
      

      
        
    }
}
