﻿using Kiosk.api;
using Kiosk.control;
using Kiosk.model;
using Kiosk.system;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        private Restaurant restaurant;

        //private Toast toast;


        public ListProducts()
        {
            InitializeComponent();

            this.restaurant = G.restaurant;
        }



       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //toast = new Toast(this);

            if (restaurant != null)
            {
                loadProducts();
                loadCart();
            }
        }

        
       



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_cart_Click(object sender, RoutedEventArgs e)
        {
            CartView _cartView = new CartView();
            _cartView.Show();
            this.Close();
            //if (_cartView.ShowDialog() == true)
            //{
            //    //PrintReceipt print = new PrintReceipt();
            //    //print.ShowDialog();

            //    //G.cart.clear();
            //    //G.syncOrders();
            //}
        }

       


        private void btn_back_to_restaurants_Click(object sender, RoutedEventArgs e)
        {
            DialogPublic _dialog = new DialogPublic("آیا میخواهید به لیست رستوران ها برگردید؟ (سبد خرید شما خالی خواهد شد)");
            if (_dialog.ShowDialog() == true)
            {
                ListRestaurant _list = new ListRestaurant();
                _list.Show();
                this.Close();
            }
        }

        private void lst_categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem == null) return;

            foreach (ItemCategory c in lst_categories.Items)
            {
                c.txt_category.Foreground = Brushes.Black;
            }

            try
            {
                ItemCategory cat = (ItemCategory)(sender as ListView).SelectedItem;
                cat.txt_category.Foreground = Brushes.Green;
                loadProducts(cat.category);
            }
            catch (InvalidCastException m)
            {
                //m.ToString();
            }


            lst_categories.SelectedItem = null;


        }

        private void lst_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem == null) return;

            ItemProduct _item = (ItemProduct)(sender as ListView).SelectedItem;
            ProductInfo _info = new ProductInfo(_item.product);
            if (_info.ShowDialog() == true)
            {
                //toast.ShowSuccess("به سبد خرید اضافه شد");
                loadCart();
            }
            else
            {
                loadCart();
            }


            lst_products.SelectedItem = null;

        }

       











        private void loadProducts()
        {

            RRestaurant r_rest = new RRestaurant();
            r_rest.products(G.restaurant, productCallBack);

        }

        private void productCallBack(object sender, EventArgs e)
        {
            List<Category> categories = sender as List<Category>;
            loadCategories(categories);

        }


        private void loadCart()
        {
            lst_cart.Items.Clear();
            ItemCartInListProduct _item;
            foreach (CartItem i in G.cart.items)
            {
                _item = new ItemCartInListProduct(i);
                lst_cart.Items.Add(_item);
            }

        }


        private void loadCategories(List<Category> cs)
        {
            ItemCategory _item;
            foreach (Category ct in cs)
            {
                _item = new ItemCategory(ct);
                lst_categories.Items.Add(_item);
            }
        }

        private void loadProducts(Category c)
        {
            lst_products.Items.Clear();
            ItemProduct _item;
            foreach (Product p in c.products)
            {
                _item = new ItemProduct(p);
                lst_products.Items.Add(_item);
            }

        }


        
        



    
       
        
        
       

        
    }
}
