using Kiosk.control;
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

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ListProducts.xaml
    /// </summary>
    public partial class ListProducts : Window
    {
        public ListProducts()
        {
            InitializeComponent();
        }

        public ListProducts(List<ItemCart> items)
        {
            InitializeComponent();
            G.timer.Enabled = true; ;

        }


       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadCategories();
        }


       
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_cart_Click(object sender, RoutedEventArgs e)
        {
            List<ItemCart> _itemCarts = new List<ItemCart>();

            CartView _cart = new CartView(_itemCarts);
            _cart.Show();
            this.Close();
        }


        private void btn_back_to_restaurants_Click(object sender, RoutedEventArgs e)
        {
            ListRestaurant _listRestaurants = new ListRestaurant();
            _listRestaurants.Show();
            this.Close();
        }




        private void loadProducts()
        {

            //grd_products.Children.Clear();
            ItemProduct p1 = new ItemProduct();
            ItemProduct p2 = new ItemProduct();
            ItemProduct p3 = new ItemProduct();
            ItemProduct p4 = new ItemProduct();
            p1.txt_product.Text = "پیتزا";
            p2.txt_product.Text = "همبرگر";
            p3.txt_product.Text = "جوجه";
            p4.txt_product.Text = "سالاد";
            p1.img_product.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_appetizer.jpg", UriKind.RelativeOrAbsolute));
            p2.img_product.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_chicken_and_ribs.jpg", UriKind.RelativeOrAbsolute));
            p3.img_product.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_pasta.jpg", UriKind.RelativeOrAbsolute));
            p4.img_product.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_salads.jpg", UriKind.RelativeOrAbsolute));

            lst_products.Items.Clear();
            lst_products.Items.Refresh();
            lst_products.Items.Add(p1);
            lst_products.Items.Add(p2);
            lst_products.Items.Add(p3);
            lst_products.Items.Add(p4);
            //grd_products.Children.Add(p1);
            //grd_products.Children.Add(p2);
            //grd_products.Children.Add(p3);
            //grd_products.Children.Add(p4);
            //Grid.SetRow(p1, 0);
            //Grid.SetRow(p2, 0);
            //Grid.SetRow(p3, 0);
            //Grid.SetRow(p4, 1);
            //Grid.SetColumn(p1, 0);
            //Grid.SetColumn(p2, 1);
            //Grid.SetColumn(p3, 2);
            //Grid.SetColumn(p4, 0);

        }


        private void loadCategories()
        {
            ItemCategory ct1 = new ItemCategory();
            ItemCategory ct2 = new ItemCategory();
            ItemCategory ct3 = new ItemCategory();
            ItemCategory ct4 = new ItemCategory();
            ItemCategory ct5 = new ItemCategory();
            ItemCategory ct6 = new ItemCategory();
            ItemCategory ct7 = new ItemCategory();
            ItemCategory ct8 = new ItemCategory();
            ct1.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_appetizer.jpg", UriKind.RelativeOrAbsolute));
            ct2.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_chicken_and_ribs.jpg", UriKind.RelativeOrAbsolute));
            ct3.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_pasta.jpg", UriKind.RelativeOrAbsolute));
            ct4.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_salads.jpg", UriKind.RelativeOrAbsolute));
            ct5.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_appetizer.jpg", UriKind.RelativeOrAbsolute));
            ct6.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_chicken_and_ribs.jpg", UriKind.RelativeOrAbsolute));
            ct7.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_pasta.jpg", UriKind.RelativeOrAbsolute));
            ct8.img_category.Source = new BitmapImage(new Uri(@"/Kiosk;component/img/ic_salads.jpg", UriKind.RelativeOrAbsolute));
            ct1.txt_category.Text = "پیش غذا";
            ct2.txt_category.Text = "جوجه";
            ct3.txt_category.Text = "ماکارونی";
            ct4.txt_category.Text = "سالاد";
            ct5.txt_category.Text = "پیش غذا";
            ct6.txt_category.Text = "جوجه";
            ct7.txt_category.Text = "ماکارونی";
            ct8.txt_category.Text = "سالاد";
            lst_categories.Items.Add(ct1);
            lst_categories.Items.Add(ct2);
            lst_categories.Items.Add(ct3);
            lst_categories.Items.Add(ct4);
            lst_categories.Items.Add(ct5);
            lst_categories.Items.Add(ct6);
            lst_categories.Items.Add(ct7);
            lst_categories.Items.Add(ct8);
        }



        private void lst_categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ItemCategory c in lst_categories.Items)
            {
                c.txt_category.Foreground = Brushes.Black;
            }

            try
            {
                ItemCategory cat = (ItemCategory)(sender as ListView).SelectedItem;
                cat.txt_category.Foreground = Brushes.Green;
                loadProducts();
            }
            catch (InvalidCastException m)
            {
                //m.ToString();
            }
           
        }

        private void lst_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ItemProduct pr = (ItemProduct)((sender as ListView).SelectedItem);
            //try
            //{
            //    ItemCartInProducts _cart = new ItemCartInProducts();
            //    _cart.txt_product.Text = pr.txt_product.Text;
            //    _cart.txt_product_price.Text = pr.txt_product_price.Text;
            //    _cart.img_product.Source = pr.img_product.Source;
            //    //lst_cart.Items.Clear();
            //    lst_cart.Items.Add(_cart);
            //}
            //catch (NullReferenceException m)
            //{
            //    //m.ToString();
            //}

            ProductInfo _info = new ProductInfo();
            if (_info.ShowDialog() == true)
            {

            }
        }

       
        
        
       

        
    }
}
