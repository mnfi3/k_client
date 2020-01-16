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

namespace Kiosk.system
{
    /// <summary>
    /// Interaction logic for LicenseManager.xaml
    /// </summary>
    public partial class LicenseManager : Window
    {
        public LicenseManager()
        {
            InitializeComponent();
        }



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(tbx_client_key.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbx_client_key.Text = G.client_key;
            Log.i("application license incorrect. client_key=" + G.client_key, "LicenseManager");
        }
    }
}
