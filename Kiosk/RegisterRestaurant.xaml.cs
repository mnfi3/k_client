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
            ItemRestaurantInRegister _item1 = new ItemRestaurantInRegister();
            ItemRestaurantInRegister _item2 = new ItemRestaurantInRegister();
            ItemRestaurantInRegister _item3 = new ItemRestaurantInRegister();
            ItemRestaurantInRegister _item4 = new ItemRestaurantInRegister();
            lst_restaurants.Items.Add(_item1);
            lst_restaurants.Items.Add(_item2);
            lst_restaurants.Items.Add(_item3);
            lst_restaurants.Items.Add(_item4);

            //DBRestaurant db_restaurant = new DBRestaurant();
            //db_restaurant.getRestaurants();
            //foreach (Restaurant rest in db_restaurant.getRestaurants())
            //{
            //    ItemRestaurantInRegister _item1 = new ItemRestaurantInRegister();
            //}

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
    }
}
