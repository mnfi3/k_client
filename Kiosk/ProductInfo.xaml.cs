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
using Kiosk.model;
using Kiosk.system;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        public Product product;

        private string dessert_size = "small";
        public ProductInfo()
        {
            InitializeComponent();
        }

        public ProductInfo(Product p)
        {
            InitializeComponent();
            this.product = p;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_name.Text = product.name;
            txt_price.Text = Utils.persian_split(product.d_price) + "  تومان  ";
            txt_description.Text = product.description;

            loadDesserts();
        }



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            //something
            DialogResult = true;
        }



       

        private void lst_dessert1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem == null) return;


            ItemDessert _item = (ItemDessert)(sender as ListView).SelectedItem;
            if (_item != null)
            {
                if (_item.is_selected == true)
                {
                    _item.Background = Brushes.Transparent;
                    _item.is_selected = false;
                }
                else
                {
                    _item.Background = (Brush)new BrushConverter().ConvertFrom("#fcfcfc");
                    _item.is_selected = true;
                }
            }




            lst_dessert1.SelectedItem = null;
        }

        private void lst_dessert2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem == null) return;


            ItemDessert _item = (ItemDessert)(sender as ListView).SelectedItem;
            if (_item != null)
            {
                if (_item.is_selected == true)
                {
                    _item.Background = Brushes.Transparent;
                    _item.is_selected = false;
                }
                else
                {
                    _item.Background = (Brush)new BrushConverter().ConvertFrom("#fcfcfc");
                    _item.is_selected = true;
                }
            }


            lst_dessert2.SelectedItem = null;
        }


        private void loadDesserts()
        {
            lst_dessert1.Items.Clear();
            lst_dessert2.Items.Clear();
            ItemDessert _item;
            foreach (Dessert d in product.desserts)
            {
                _item = new ItemDessert(d);
                if (d.type == "d1")
                {
                    lst_dessert1.Items.Add(_item);
                }
                else if(d.type == "d2")
                {
                    lst_dessert2.Items.Add(_item);
                }
            }

        }



        private void btn_small_Click(object sender, RoutedEventArgs e)
        {
            dessert_size = "small";
            resetDessertsPrices();
            resetBackColors();
        }

        private void btn_medium_Click(object sender, RoutedEventArgs e)
        {
            dessert_size = "medium";
            resetDessertsPrices();
            resetBackColors();
        }

        private void btn_large_Click(object sender, RoutedEventArgs e)
        {
            dessert_size = "large";
            resetDessertsPrices();
            resetBackColors();
        }


        private void resetDessertsPrices()
        {
            if (dessert_size == "small")
            {
                foreach (ItemDessert item in lst_dessert1.Items)
                {
                    item.txt_price.Text = Utils.persian_split(item.dessert.price_small) + " تومان ";
                }

                foreach (ItemDessert item in lst_dessert2.Items)
                {
                    item.txt_price.Text = Utils.persian_split(item.dessert.price_small) + " تومان ";
                }
            }
            else if (dessert_size == "medium")
            {
                foreach (ItemDessert item in lst_dessert1.Items)
                {
                    item.txt_price.Text = Utils.persian_split(item.dessert.price_medium) + " تومان ";
                }

                foreach (ItemDessert item in lst_dessert2.Items)
                {
                    item.txt_price.Text = Utils.persian_split(item.dessert.price_medium) + " تومان ";
                }
            }
            else if (dessert_size == "large")
            {
                foreach (ItemDessert item in lst_dessert1.Items)
                {
                    item.txt_price.Text = Utils.persian_split(item.dessert.price_large) + " تومان ";
                }

                foreach (ItemDessert item in lst_dessert2.Items)
                {
                    item.txt_price.Text = Utils.persian_split(item.dessert.price_large) + " تومان ";
                }
            }
        }

        private void resetBackColors()
        {
            if (dessert_size == "small")
            {
                btn_small.Background = Brushes.White;
                btn_medium.Background = Brushes.Transparent;
                btn_large.Background = Brushes.Transparent;
            }
            else if (dessert_size == "medium")
            {
                btn_small.Background = Brushes.Transparent;
                btn_medium.Background = Brushes.White;
                btn_large.Background = Brushes.Transparent;
            }
            else if (dessert_size == "large")
            {
                btn_small.Background = Brushes.Transparent;
                btn_medium.Background = Brushes.Transparent;
                btn_large.Background = Brushes.White;
            }
        }


        
        
        }
}
