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
using Kiosk.db;
using Kiosk.model;
using System.Diagnostics;
using Kiosk.api;
using ToastNotifications;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for RegisterRestaurant.xaml
    /// </summary>
    public partial class RegisterRestaurant : Window
    {
        Toast toast;
        public RegisterRestaurant()
        {
            InitializeComponent();
            toast = new Toast(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadRests();

        }

        private void btn_finish_Click(object sender, RoutedEventArgs e)
        {
            ListRestaurant _restaurnats = new ListRestaurant();
            _restaurnats.Show();
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

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            DeviceLogin _login = new DeviceLogin();
            _login.Show();
            this.Close();
        }



        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string user_name = txt_user_name.Text.ToString();
            string password = txt_password.Password.ToString();

            RRestaurant r_restaurant = new RRestaurant();
            r_restaurant.login(user_name, password, loginCompleteCallBack);
        }

        private void loginCompleteCallBack(object sender, EventArgs e){
            Restaurant restaurant = sender as Restaurant;
            if (restaurant.token != null)
            {
                DBRestaurant db_rest = new DBRestaurant();
                db_rest.setRestaurant(restaurant);
                toast.ShowSuccess("رستوران با موفقیت ثبت شد");
                G.restaurants = G.getRestaurants();
                loadRests();
            }
            else
            {
                toast.ShowError("عملیات انجام نشد");
            }
        }






        private void loadRests()
        {
            List<Restaurant> restaurants = G.restaurants;
            lst_restaurants.Items.Clear();
            ItemRestaurantInRegister _item;
            foreach (Restaurant res in restaurants)
            {
                _item = new ItemRestaurantInRegister(res);
                lst_restaurants.Items.Add(_item);
            }
        }
    }
}
