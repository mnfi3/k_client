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
            string text = System.IO.File.ReadAllText(@"C:\dev\c_charp\Kiosk\Kiosk\zz.txt");
            //MessageBox.Show(text);
            //webview.NavigateToString(text);

            ////Uri uri = new Uri(@"pack://Kiosk:,,,/zz.txt", UriKind.Absolute);
            //Uri uri = new Uri("C:\\dev\\c_charp\\Kiosk\\Kiosk\\zz.txt");
            //Stream stream = Application.GetResourceStream(uri).Stream;
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    // Navigate to HTML document string  
            //    this.webview.NavigateToString(reader.ReadToEnd());
            //}                                                      
            //doPayment();
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
