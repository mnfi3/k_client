using Kiosk.model;
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
    /// Interaction logic for Receipt.xaml
    /// </summary>
    public partial class Receipt : Window
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ReceiptItem> _items = new List<ReceiptItem>();
            ReceiptItem _r;
            for (int i = 0; i < 100; i++)
            {
                _r = new ReceiptItem();
                _r.num = i;
                _r.name = i.ToString();
                _r.size = "بزرگ";
                _r.price = i * 5445;
                _r.count = 10;
                _r.cost = i * 654654;
                _items.Add(_r);
                dtg.Items.Add(_r);
            }

            //dtg.DataContext = _items;



            PrintDialog myPrintDialog = new PrintDialog();
            if (myPrintDialog.ShowDialog() == true)
            {
                //myPrintDialog.PrintVisual(this, "Form All Controls Print");
                //myPrintDialog.PrintVisual(dtg, "test");


            }
            else
            {
                // MessageBox.Show("failed");
            }

        }
    }
}
