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

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        public ProductInfo()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            //something
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ItemDessert _item;
            for (int i = 0; i < 30; i++)
            {
                _item = new ItemDessert();
                lst_dessert1.Items.Add(_item);
                _item = new ItemDessert();
                lst_dessert2.Items.Add(_item);
            }
        }

        private void lst_dessert1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemDessert _item = (sender as ItemDessert);
            //_item.Background = System.Drawing.ColorTranslator.FromHtml("#fcfcfc");
            MessageBox.Show("selected");
            if (_item != null)
            {
                MessageBox.Show("selected");
                var bc = new BrushConverter();
                _item.Background = (Brush)bc.ConvertFrom("#fcfcfc");
            }
        }
    }
}
