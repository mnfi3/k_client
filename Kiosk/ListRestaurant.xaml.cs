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
using System.Net;
using System.IO;
using System.Timers;

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
        }



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lst_restaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListProducts _products = new ListProducts();
            _products.Show();
            G.setupTimer();
            this.Close();
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
            ItemRestaurant r1 = new ItemRestaurant();
            ItemRestaurant r2 = new ItemRestaurant();
            ItemRestaurant r3 = new ItemRestaurant();
            ItemRestaurant r4 = new ItemRestaurant();
            ItemRestaurant r5 = new ItemRestaurant();
            ItemRestaurant r6 = new ItemRestaurant();
            ItemRestaurant r7 = new ItemRestaurant();
            r1.txt_restaurant.Text = "رستوران 1";
            r2.txt_restaurant.Text = "رستوران 2";
            r3.txt_restaurant.Text = "رستوران 3";
            r4.txt_restaurant.Text = "رستوران 4";
            r5.txt_restaurant.Text = "رستوران 5";
            r6.txt_restaurant.Text = "رستوران 6";
            r7.txt_restaurant.Text = "رستوران 7";

            var fullFilePath = @"http://www.americanlayout.com/wp/wp-content/uploads/2012/08/C-To-Go-300x300.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
           
            r1.img_restaurant.Source =bitmap;
            r2.img_restaurant.Source =bitmap;


            lst_restaurants.Items.Add(r1);
            lst_restaurants.Items.Add(r2);
            lst_restaurants.Items.Add(r3);
            lst_restaurants.Items.Add(r4);
            lst_restaurants.Items.Add(r5);
            lst_restaurants.Items.Add(r6);
            lst_restaurants.Items.Add(r7);
            //lst_restaurants.Items.Add(r1);

            //grd_restaurants.Children.Add(r1);
            //grd_restaurants.Children.Add(r2);
            //grd_restaurants.Children.Add(r3);
            //grd_restaurants.Children.Add(r4);
            //grd_restaurants.Children.Add(r5);
            //grd_restaurants.Children.Add(r6);
            //Grid.SetRow(r1, 0);
            //Grid.SetRow(r2, 0);
            //Grid.SetRow(r3, 0);
            //Grid.SetRow(r4, 1);
            //Grid.SetRow(r5, 1);
            //Grid.SetRow(r6, 1);
            //Grid.SetColumn(r1, 0);
            //Grid.SetColumn(r2, 1);
            //Grid.SetColumn(r3, 2);
            //Grid.SetColumn(r4, 0);
            //Grid.SetColumn(r5, 1);
            //Grid.SetColumn(r6, 2);
        }

        

       

        
    }
}
