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
    }
}
