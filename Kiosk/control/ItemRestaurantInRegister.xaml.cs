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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kiosk.model;
using Kiosk.api;
using ToastNotifications;
using Kiosk.db;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for ItemRestaurantInRegister.xaml
    /// </summary>
    public partial class ItemRestaurantInRegister : UserControl
    {

        public Restaurant restaurant;
        public ItemRestaurantInRegister()
        {
            InitializeComponent();
        }

        public ItemRestaurantInRegister(Restaurant res)
        {
            InitializeComponent();

            this.restaurant = res;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (restaurant != null)
            {
                txt_name.Text = restaurant.name;
                txt_user_name.Text = restaurant.user_name;
                img_restaurant.ImageUrl = restaurant.image;
                img_restaurant.Source = null;
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            RRestaurant r_res = new RRestaurant();
            r_res.logout(this.restaurant, logoutCallBack);
        }

        private void logoutCallBack(object sender, EventArgs e)
        {
            Response res = sender as Response;
            DBRestaurant db_res = new DBRestaurant();
            db_res.removeRestaurant(this.restaurant);
            G.restaurants = G.getRestaurants();
            this.Visibility = Visibility.Collapsed;
        }

       
    }
}
