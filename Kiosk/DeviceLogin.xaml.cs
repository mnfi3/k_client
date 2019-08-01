using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Kiosk.db;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for DeviceLogin.xaml
    /// </summary>
    public partial class DeviceLogin : Window
    {
        public DeviceLogin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (G.isLoggedIn == true)
            {
                btn_logout.Visibility = Visibility.Visible;
                grd_login.Visibility = Visibility.Collapsed;
            }
            else
            {
                btn_logout.Visibility = Visibility.Collapsed;
                grd_login.Visibility = Visibility.Visible;
            }
        }



        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            RegisterRestaurant _register = new RegisterRestaurant();
            _register.Show();
            this.Close();
        }

      

        private void txt_user_name_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process process = Process.Start(new ProcessStartInfo(
                ((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
            txt_user_name.Focus();
        }

        private void txt_password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process process = Process.Start(new ProcessStartInfo(
                ((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
            txt_password.Focus();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            new DBDevice().logoutDevice();
            G.isLoggedIn = false;
            btn_logout.Visibility = Visibility.Collapsed;
            grd_login.Visibility = Visibility.Visible;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string user_name = txt_user_name.Text.ToString();
            string password = txt_password.Password.ToString();
            string client_key = G.client_key;

        }

       

        

       
    }
}
