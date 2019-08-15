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
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using System.Windows.Media.Effects;
using Kiosk.model;
using Kiosk.system;
using Kiosk.api;
using Kiosk.db;
using Newtonsoft.Json;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class CartView : Window
    {


        private Toast toast;


        public CartView()
        {
            InitializeComponent();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            toast = new Toast(this);

            //txt_discount_code.Focus();

            //refresh cart
            ItemCart _item;
            foreach (CartItem i in G.cart.items)
            {
                _item = new ItemCart(i, refreshCartViewEvent);
                lst_cart.Items.Add(_item);
            }

            txt_cost.Text = Utils.persian_split(G.cart.cost) + " تومان ";
            txt_d_cost.Text = Utils.persian_split(G.cart.d_cost) + " تومان ";
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lst_cart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

       
        private void btn_back_to_restaurants_Click(object sender, RoutedEventArgs e)
        {
            //ListProducts _list = new ListProducts(G.restaurant);
            //_list.Show();
            this.Close();
        }


        private void txt_discount_code_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            toast.ShowInformation("کد تخفیف را وارد کنید");

            BlurEffect blur = new BlurEffect();
            grd_products.Effect = blur;

            VKeyboard _keyboard = new VKeyboard(ref txt_discount_code);
            if (_keyboard.ShowDialog() == true)
            {
                grd_products.Effect = null;
            }
        }

        private void btn_discount_Click(object sender, RoutedEventArgs e)
        {
            string discount_code = txt_discount_code.Text.ToString();
            RRestaurant r_rest = new RRestaurant();
            r_rest.checkDiscount(G.restaurant, discount_code, checkDiscountCodeComplete);
        }

        private void checkDiscountCodeComplete(object sender, EventArgs e)
        {
            Discount d = sender as Discount;
            if (d.is_valid)
            {
                G.cart.discount = d;
                txt_d_cost.Text = Utils.persian_split(G.cart.d_cost) + " تومان ";
                toast.ShowSuccess("کد تخفیف اعمال شد");
            }
        }




        private void btn_pay_Click(object sender, RoutedEventArgs e) 
        {
            if (G.cart.items.Count > 0)
            {
                BlurEffect blur = new BlurEffect();
                grd_main.Effect = blur;
                grd_main.Effect = null;
                DialogPaymentAccept dialog = new DialogPaymentAccept(G.cart.d_cost);
                if (dialog.ShowDialog() == true)
                {
                    //DialogCartSwipe dialog2 = new DialogCartSwipe();
                    //if (dialog2.ShowDialog() == true)
                    //{
                    //    //handleShop();
                    //}

                    handleShop();
                    grd_main.Effect = null;
                }
                else
                {
                    grd_main.Effect = null;
                }
            }
            else
            {
                toast.ShowError("هیچ محصولی به سبد خرید اضافه نشده است");
            }
        }



        private void refreshCartViewEvent(object sender, EventArgs e)
        {
            txt_cost.Text = Utils.persian_split(G.cart.cost) + " تومان ";
            txt_d_cost.Text = Utils.persian_split(G.cart.d_cost) + " تومان ";
        }




        private void handleShop()
        {
            DBOrder db_order = new DBOrder();
            db_order.saveOrder(G.restaurant, G.cart, "pay_receipt");
            toast.ShowSuccess("data saved!");
        }





            
    }
}
