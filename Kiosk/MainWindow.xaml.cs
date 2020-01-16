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
using Kiosk.db_lite;
using System.Data.SqlClient;
using Kiosk.api;
using Kiosk.model;
using Newtonsoft.Json;
using Kiosk.preference;
using System.Net;
using System.Reflection;


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
            G.syncOrders();
            checkForUpdate();


            if (!Security.licenceChecker())
            {
                LicenseManager _manager = new LicenseManager();
                _manager.Show();
            }
            else if (!G.isLoggedIn)
            {
                DeviceLogin _device = new DeviceLogin();
                _device.Show();
            }
            else
            {
                //Receipt _receipt = new Receipt();
                //_receipt.Show();
                ListRestaurant _list = new ListRestaurant(true);
                _list.Show();
                //fortest _tst = new fortest();
                //_tst.Show();
                
            }



            this.Close();
        }


        

       

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_close_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void checkForUpdate()
        {
            var webRequest = WebRequest.Create(@"" + Urls.UPDATE_INFO_URL);

            string str_update = Config.VERSION;
            try
            {
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    str_update = reader.ReadToEnd();
                }

            }
            catch (Exception e1) { }



            //application is latest version
            if (str_update.Contains(Config.VERSION)) return;


            DialogPublic _dialog = new DialogPublic("نسخه ی جدید برنامه منتشر شده است.آیا میخواهید آپدیت کنید؟");
            if (_dialog.ShowDialog() == true)
            {
                string updater_path = AppDomain.CurrentDomain.BaseDirectory + "updater.exe";
                Process updater_app = new Process();
                updater_app.StartInfo.FileName = updater_path;
                try
                {
                    updater_app.Start();
                    System.Windows.Application.Current.Shutdown();
                }
                catch (Exception ex) { }
            }


            return;
        }




    }
}
