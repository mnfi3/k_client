using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using Kiosk.control;
using Kiosk.system;
using Kiosk.license;
using Kiosk.db;
using System.Data.SqlClient;


namespace Kiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DBDevice db_device = new DBDevice();

            if (!Security.licenceChecker())
            {
                LicenseManager _manager = new LicenseManager();
                _manager.Show();
            }
            else if (!db_device.isLoggedIn())
            {
                DeviceLogin _device = new DeviceLogin();
                _device.Show();
            }
            else
            {
                ListRestaurant _restaurants = new ListRestaurant();
                _restaurants.Show();
            }

            

            this.Close();
        }

        

       

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




    }
}
