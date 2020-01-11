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
        private bool paymentDone = false;
        public DialogCartSwipe(int amount, EventHandler handler)
        {
            InitializeComponent();

            //this.amount = amount*10; //convert to rial
            this.amount = 10000;
            paymentHandler += handler;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            doPayment();
            secondCounter();
        }


        private  void doPayment()
        {
            //fake payment
            //paymentCallBack(new object(), new EventArgs());


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
            paymentDone = true;
            paymentHandler(sender, new EventArgs());
            this.Close();




            //fake payment for test
            //BuyResponse res = new BuyResponse();
            //res.success = true;
            //res.PAN = "610433***9896";
            //res.ReqID = "";
            //res.SerialTransaction = "564546546";
            //res.TerminalNo = "1234";
            //res.TraceNumber = "564";
            //res.TransactionDate = "1398/01/24";
            //res.TransactionTime = "14:55";
            //Task.Delay(2000);
            //paymentHandler(res, new EventArgs());
            //this.Close();

        }




        private async void secondCounter()
        {
            for (int i = 30; i >= 0; i --)
            {
                txt_second.Text = i.ToString();
                await Task.Delay(950);
            }

            if (paymentDone) return;

            BuyResponse res = new BuyResponse();
            res.success = false;
            res.error = "مهلت پرداخت تمام شده است";
            paymentHandler(res, new EventArgs());

            this.Close();
        }
       

        
    }
}
