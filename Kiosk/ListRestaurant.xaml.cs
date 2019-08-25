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
using System.Windows.Media.Animation;

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


            //DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            //myDoubleAnimation.From = 1.0;
            //myDoubleAnimation.To = 0.0;
            //myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            //myDoubleAnimation.AutoReverse = true;
            //myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            //myStoryboard = new Storyboard();
            //myStoryboard.Children.Add(myDoubleAnimation);
            //Storyboard.SetTargetName(myDoubleAnimation, lst_restaurants.Name);
            //Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            //// Use the Loaded event to start the Storyboard.
            //lst_restaurants.Loaded += new RoutedEventHandler(lst_restaurantsLoaded);
            //grd_main.Children.Add(lst_restaurants);
            //this.Content = grd_main;


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

            G.restaurant = _item.restaurant;
            ListProducts _list = new ListProducts();
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
