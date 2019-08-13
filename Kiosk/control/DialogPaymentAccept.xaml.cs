using Kiosk.system;
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

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for DialogPaymentAccept.xaml
    /// </summary>
    public partial class DialogPaymentAccept : Window
    {
        int price;
        public DialogPaymentAccept()
        {
            InitializeComponent();
        }

        public DialogPaymentAccept(int p)
        {
            InitializeComponent();
            price = p;
            txt_price.Text = Utils.persian_split(price) + " تومان ";

        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
