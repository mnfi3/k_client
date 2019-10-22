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
using Kiosk.api;
using Kiosk.model;
using ToastNotifications;
using Kiosk.control;
using Kiosk.preference;

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

            txt_client_key.Text = "client_key : " + G.client_key;
            txt_device_name.Text = "name : " + G.device.name;
            txt_device_user_name.Text = "user_name : " + G.device.user_name;

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
            RDevice r_device = new RDevice();
            r_device.logout(logoutCallBack);
           
        }


        private void logoutCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            if (res.status == 1)
            {
                //new DBDevice().logoutDevice();
                new STDevice().logoutDevice();
                G.isLoggedIn = false;
                G.device = G.getDevice();
                btn_logout.Visibility = Visibility.Collapsed;
                grd_login.Visibility = Visibility.Visible;

            }
            else
            {
            }
        } 



        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string user_name = txt_user_name.Text.ToString();
            string password = txt_password.Password.ToString();
            RDevice req = new RDevice();
            req.login(user_name, password, loginCallBack);
        }

        private void loginCallBack(object sender, EventArgs e)
        {
            Device device = sender as Device;
            if (device.token != null)
            {
                //DBDevice db_device = new DBDevice();
                //db_device.saveDevice(device);
                STDevice st_device = new STDevice();
                st_device.saveDevice(device);
                G.isLoggedIn = true;
                G.device = G.getDevice();
                btn_logout.Visibility = Visibility.Visible;
                grd_login.Visibility = Visibility.Collapsed;
            }
            else
            {
            }
        } 

       

        

       
    }
}
