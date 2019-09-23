using Kiosk.pos;
using Kiosk.pos.model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for DialogCartSwipe.xaml
    /// </summary>
    public partial class DialogCartSwipe : Window
    {
        private int amount;
        private EventHandler paymentHandler;
        public DialogCartSwipe(int amount, EventHandler handler)
        {
            InitializeComponent();

            this.amount = amount;
            paymentHandler += handler;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //webview.Loaded += delegate
            //{
                //webview.Navigate(new Uri("http://www.google.com/"));


                //string text = System.IO.File.ReadAllText(@"C:\dev\c_charp\Kiosk\Kiosk\zz.html");
                //MessageBox.Show(text);
                //webview.NavigateToString("<html><body><span style='color:back'>hello</span></body></html>");

                string curDir = Directory.GetCurrentDirectory();
                this.webview.Source = new Uri(String.Format("file:///{0}/zz.html", curDir));

                //Uri uri = new Uri(@"pack://Kiosk:,,,/zz.txt", UriKind.Absolute);
                    
            //};

                                             
            //doPayment();
        }


        private void webview_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            string script = "document.body.style.overflow ='hidden'";
            webview.InvokeScript("execScript", new Object[] { script, "JavaScript" });
        }




        public void doPayment()
        {
            Pos pos = new Pos(paymentCallBack);
            BuyRequest buyRequest = new BuyRequest();
            buyRequest.Amount = amount.ToString(); ;
            buyRequest.PcID = G.client_key;
            //buyRequest.PayerId = "user_" + G.restaurant.id.ToString();
            buyRequest.MerchantMsg = "";

            pos.requestBuy(buyRequest);
        }


        public void paymentCallBack(object sender, EventArgs e)
        {
            BuyResponse buyResponse = sender as BuyResponse;
            paymentHandler(buyResponse, new EventArgs());
            this.Close();
        }

       

        
    }
}
