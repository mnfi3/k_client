﻿using System;
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
using System.Windows.Media.Animation;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        private Product product;
        private CartItem cartItem;
        private int count = 1;
        private Boolean added;

        private string dessert_size = "small";

        Toast toast;

        //public ProductInfo()
        //{
        //    InitializeComponent();
        //}

        public ProductInfo(Product p)
        {
            InitializeComponent();
            this.product = p;
            this.Height = G.height;
            this.Width = G.width;
            this.Left = G.width;
            
            cartItem = new CartItem();
            
        }

        private void slideInLeft()
        {
            DoubleAnimation slideInRight = new DoubleAnimation();
            slideInRight.From = G.width;
            slideInRight.To = 0;
            slideInRight.Duration = new Duration(TimeSpan.FromMilliseconds(350));
            slideInRight.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slideInRight);
        }
        private void slideOutRight()
        {
            DoubleAnimation slideOutLeft = new DoubleAnimation();
            slideOutLeft.Completed += new EventHandler(slideOutFinished);
            
            slideOutLeft.From = 0;
            slideOutLeft.To = G.width;
            slideOutLeft.Duration = new Duration(TimeSpan.FromMilliseconds(350));
            slideOutLeft.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slideOutLeft);
        }
        private void slideOutFinished(object sender, EventArgs e)
        {
            DialogResult = added;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            slideInLeft();
            


            txt_name.Text = product.name;
            txt_price.Text = Utils.persian_split(product.d_price) + "  تومان  ";
            txt_description.Text = product.description;
            img_product.Source = null;
            img_product.ImageUrl = product.image;
            cartItem.product = this.product;


            loadDesserts();

            if (G.cart.isExistInCart(this.product) == true)
            {
                this.cartItem = G.cart.findByProduct(this.product);
                loadCartItem();
                G.cart.remove(cartItem);
            }


            refreshCartItem();
           
        }



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            added = false;
            slideOutRight();
           
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            G.cart.items.Add(this.cartItem);
            added = true;
            slideOutRight();
            
        }


        private void btn_up_Click(object sender, RoutedEventArgs e)
        {
            count++;
            txt_count.Text = count.ToString();

            cartItem.count = count;
            refreshCartItem();
        }

        private void btn_down_Click(object sender, RoutedEventArgs e)
        {
            if (count > 1)
            {
                count--;
                cartItem.count = count;
                txt_count.Text = count.ToString();

                refreshCartItem();
            }
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

            refreshCartItem();



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
            


            refreshCartItem();

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

            refreshCartItem();
        }

        private void btn_medium_Click(object sender, RoutedEventArgs e)
        {
            dessert_size = "medium";
            resetDessertsPrices();
            resetBackColors();

            refreshCartItem();
        }

        private void btn_large_Click(object sender, RoutedEventArgs e)
        {
            dessert_size = "large";
            resetDessertsPrices();
            resetBackColors();

            refreshCartItem();
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



        private void loadCartItem()
        {
            count = cartItem.count;
            txt_count.Text = count.ToString();
            this.dessert_size = cartItem.desserts_size;
            resetDessertsPrices();
            txt_total.Text = Utils.persian_split(cartItem.cost) + "  تومان  ";
            resetBackColors();

            foreach (ItemDessert _item1 in lst_dessert1.Items)
            {
                foreach (Dessert d in cartItem.desserts)
                {
                    if (d.id == _item1.dessert.id)
                    {
                        _item1.is_selected = true;
                        _item1.Background = Brushes.White;
                        break;
                    }
                }
            }

            foreach (ItemDessert _item2 in lst_dessert2.Items)
            {
                foreach (Dessert d in cartItem.desserts)
                {
                    if (d.id == _item2.dessert.id)
                    {
                        _item2.is_selected = true;
                        _item2.Background = Brushes.White;
                        break;
                    }
                }
            }

        }



        private void refreshCartItem()
        {
            cartItem.desserts.Clear();
            cartItem.desserts_size = this.dessert_size;

            foreach (ItemDessert item in lst_dessert1.Items)
            {
                if (item.is_selected == true)
                {
                    item.dessert.product_id = this.product.id;
                    cartItem.desserts.Add(item.dessert);
                }
            }

            foreach (ItemDessert item in lst_dessert2.Items)
            {
                if (item.is_selected == true)
                {
                    item.dessert.product_id = this.product.id;
                    cartItem.desserts.Add(item.dessert);
                }
            }


            txt_total.Text = Utils.persian_split(cartItem.cost) + "  تومان  ";
        }




        private void btn_up_TouchDown(object sender, TouchEventArgs e)
        {
            count++;
            txt_count.Text = count.ToString();

            cartItem.count = count;
            refreshCartItem();
        }

       
        
        
        }
}
