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


        public DialogPaymentAccept()
        {
            InitializeComponent();
        }

        public DialogPaymentAccept(int p)
        {
            InitializeComponent();
            price = p;

            step = price / 100 + 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_price.Text = Utils.persian_split(0) + " تومان ";

            Thread t = new Thread(new ThreadStart(ThreadJob));
            t.IsBackground = true;
            t.Start();         
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }



        private void ThreadJob()
        {
            int counter = 0;
            for (int i = 0; i <= 1000; i+=1)
            {
                counter += step;   
                this.Dispatcher.Invoke((Action)(() =>
                {
                    if (counter < price)
                    {
                        txt_price.Text = Utils.persian_split(counter) + " تومان ";
                        Thread.Sleep(4);
                    }
                    else
                    {
                        txt_price.Text = Utils.persian_split(price) + " تومان ";
                        return;
                    }
                }));
            }
            

        }
       

      
      

      
        
    }
}
