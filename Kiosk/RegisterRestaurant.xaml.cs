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
using Kiosk.db_lite;
using Kiosk.model;
using System.Diagnostics;
using Kiosk.api;
using ToastNotifications;
using Kiosk.system;
using Kiosk.preference;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for RegisterRestaurant.xaml
    /// </summary>
    public partial class RegisterRestaurant : Window
    {
        public RegisterRestaurant()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadRests();

        }

        private void btn_finish_Click(object sender, RoutedEventArgs e)
        {
            ListRestaurant _list = new ListRestaurant(true);
            _list.Show();
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
                //DBRestaurant db_rest = new DBRestaurant();
                //db_rest.setRestaurant(restaurant);
                STRestaurant st_rest = new STRestaurant();
                st_rest.setRestaurant(restaurant);
                G.restaurants = G.getRestaurants();
                loadRests();
            }
            else
            {
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

        private void lst_restaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst_restaurants.SelectedItem == null) return;


            ItemRestaurantInRegister _item = (ItemRestaurantInRegister)(sender as ListView).SelectedItem;
            RestaurantDetails _details = new RestaurantDetails(_item.restaurant);
            _details.Show();
            this.Close();

            lst_restaurants.SelectedItem = null;
        }
    }
}
