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
using Kiosk.license;
using Kiosk.control;
using Kiosk.api;
using System.Net;
using System.IO;
using System.Timers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Kiosk.db;
using Kiosk.model;
using Kiosk.system;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ListRestaurant.xaml
    /// </summary>
    public partial class ListRestaurant : Window
    {
        public ListRestaurant()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadRestaurants();
            G.timer.Enabled = false;
            G.restaurant = null;
            G.cart.clear();

        }




       



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




        private void lst_restaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst_restaurants.SelectedItem == null) return;


            ItemRestaurant _item = (ItemRestaurant)(sender as ListView).SelectedItem;
            G.restaurant = _item.restaurant;

            ListProducts _list = new ListProducts(_item.restaurant);
            _list.Show();

            //G.setupTimer();
            this.Close();


            lst_restaurants.SelectedItem = null;
        }

        private void btn_manage_Click(object sender, RoutedEventArgs e)
        {
            DialogManageApp _dialog = new DialogManageApp();
            if (_dialog.ShowDialog() == true)
            {
                DeviceLogin _login = new DeviceLogin();
                _login.Show();
                this.Close();
            }
        }
        





        private void loadRestaurants()
        {
            DBRestaurant db_rest = new DBRestaurant();
            List<Restaurant> rests = db_rest.getRestaurants();
            ItemRestaurant _item;

            foreach (Restaurant rest in rests)
            {
                _item = new ItemRestaurant(rest);
                lst_restaurants.Items.Add(_item);
            }

        }

        

       

        
    }
}
