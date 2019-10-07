using Kiosk.pos;
using Kiosk.pos.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            //this.amount = amount*10; //convert to rial
            this.amount = 10000;
            paymentHandler += handler;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //doPayment();
        }


        private  void doPayment()
        {
            Pos pos = new Pos(paymentCallBack);
            BuyRequest buyRequest = new BuyRequest();
            buyRequest.Amount = amount.ToString(); ;
            buyRequest.PcID = G.client_key;
            //buyRequest.PayerId = "user_" + G.restaurant.id.ToString();
            buyRequest.MerchantMsg = "digiarta.com";

            pos.requestBuy(buyRequest);
        }


        public void paymentCallBack(object sender, EventArgs e)
        {
            //BuyResponse buyResponse = sender as BuyResponse;
            paymentHandler(sender, new EventArgs());
            this.Close();
        }

       

        
    }
}
