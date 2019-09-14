using Kiosk.api;
using Kiosk.control;
using Kiosk.db;
using Kiosk.model;
using Kiosk.system;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Stimulsoft.Report;
using System.Drawing.Printing;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ListProducts.xaml
    /// </summary>
    public partial class ListProducts : Window
    {

        private Restaurant restaurant;

        ClickToOrder _clickToOrder;

        //private Toast toast;


        public ListProducts()
        {
            InitializeComponent();
            this.Height = G.height;
            this.Width = G.width;
            this.cln_cart.Width =new  GridLength(0, GridUnitType.Star);
            this.restaurant = G.restaurant;
        }





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //show btn_back_to_restaurants button if have more than one restaurant

            if (G.restaurants.Count > 1)
            {
                btn_back_to_restaurants.Visibility = Visibility.Visible;
            }
            //toast = new Toast(this);

            if (G.cart.items.Count > 0)
            {
                this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
            }

            if (G.restaurants.Count == 1)
            {
                G.restaurant = G.restaurants[0];
                this.restaurant = G.restaurants[0];
                //loadProducts();
                //loadCart();
                _clickToOrder = new ClickToOrder(animCallback);
                _clickToOrder.ShowDialog();
            }
            else
            {
                loadProducts();
                loadCart();
            }
            txt_total.Text = "ت "  + Utils.persian_split(G.cart.cost);



            //print test
            //StiReport report = new StiReport();
            //report.Load("Report.mrt");
            //report.Compile();
            //report["restaurant"] = G.restaurant.name;
            //report["cost"] = Utils.persian_split(125000) + " تومان ";
            //report["d_cost"] = Utils.persian_split(100000) + " تومان ";
            //report["order_number"] = Utils.toPersianNum("1547");
            //report.Printed += Report_Printed;
            //report.Printing += Report_Printing;
            //PrinterSettings setting = new PrinterSettings();
            //setting.PrinterName = "ReceiptPrinter";
            //report.Print(false, setting);
        }

        private void Report_Printing(object sender, EventArgs e)
        {
            //when printing
            //MessageBox.Show("printing");
        }

        private void Report_Printed(object sender, EventArgs e)
        {
            //when printed
            //MessageBox.Show("printed");
        }



        private void animCallback(object sender, EventArgs e)
        {
            loadProducts();
            loadCart();
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

        private void selectFirstCategory()
        {
            if (lst_categories.Items.Count < 1) return;

            foreach (ItemCategory c in lst_categories.Items)
            {
                c.txt_category.Foreground = Brushes.Black;
            }
            ItemCategory cat = (ItemCategory)lst_categories.Items[0];
            cat.txt_category.Foreground = Brushes.Green;
            loadProducts(cat.category);
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
                if (G.cart.items.Count > 0)
                {
                    this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
                }
                txt_total.Text = "ت " + Utils.persian_split(G.cart.cost);
                              
            }
            else
            {
                loadCart();
                txt_total.Text = "ت " + Utils.persian_split(G.cart.cost);
                if (G.cart.items.Count > 0)
                {
                    this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
                }
                else
                {
                    this.cln_cart.Width = new GridLength(0, GridUnitType.Star);
                }
            }


            lst_products.SelectedItem = null;

        }


        private void loadProducts()
        {
            //load from server
            RRestaurant r_rest = new RRestaurant();
            r_rest.products(G.restaurant, productCallBack);
        }

        private void productCallBack(object sender, EventArgs e)
        {
            DBProducts db_products = new DBProducts();
            List<Category> categories = sender as List<Category>;

            //if connection was fail
            if (categories.Count == 0)
            {
                categories = db_products.getProducts(this.restaurant);
                loadCategories(categories);
            }
            else
            {
                loadCategories(categories);
                //save new products to local db
                Task.Run(() =>
                    db_products.resetProducts(categories, this.restaurant)
                    );
               
            }

           
        }


        private  void loadCart()
        {
            loadCart1();
            //lst_cart.Items.Clear();
            //ItemCartInListProduct _item;
            
            //foreach (CartItem i in G.cart.items)
            //{
            //    _item = new ItemCartInListProduct(i, on_cost_changed_handler);
            //    lst_cart.Items.Add(_item);
            //}
        }

      


        private async void loadCategories(List<Category> cs)
        {
            ItemCategory _item;
            foreach (Category ct in cs)
            {
                _item = new ItemCategory(ct);
                lst_categories.Items.Add(_item);
                await Task.Delay(200);
            }

            selectFirstCategory();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //lst_categories.Items.Clear();
            //lst_products.Items.Clear();
            //lst_cart.Items.Clear();
            //_clickToOrder = new ClickToOrder(animCallback);
            //_clickToOrder.ShowDialog();
            DialogManageApp _dialog = new DialogManageApp();
            if (_dialog.ShowDialog() == true)
            {
                DeviceLogin _login = new DeviceLogin();
                _login.Show();
                this.Close();
            }
        }

        private void btn_checkout_Click(object sender, RoutedEventArgs e)
        {
            CartView _cartView = new CartView();
            _cartView.Show();
            this.Close();

        }


        private void on_cost_changed_handler(object sender, EventArgs e)
        {
            txt_total.Text = "ت " + Utils.persian_split(G.cart.cost);
        }






        private async void loadCart1()
        {
            ItemCartInListProduct _item;

            //add new items to listview
            foreach (CartItem i in G.cart.items)
            {
                bool is_find = false;
                foreach (ItemCartInListProduct ic in lst_cart.Items)
                {
                    if (i.product.id == ic.cartItem.product.id)
                    {
                        is_find = true;
                        break;
                    }
                }

                if (!is_find)
                {
                    _item = new ItemCartInListProduct(i, on_cost_changed_handler);
                    lst_cart.Items.Add(_item);
                    await Task.Delay(200);
                }
            }

            //remove old item from listview
            bool is_reload = false;
            foreach (ItemCartInListProduct ic in lst_cart.Items)
            {
                bool is_exist = false;
                foreach (CartItem i in G.cart.items)
                {
                    if (i.product.id == ic.cartItem.product.id)
                    {
                        is_exist = true;
                        break;
                    }
                }

                if (!is_exist)
                {
                    is_reload = true;
                    break;
                }
            }

            if (is_reload)
            {
                lst_cart.Items.Clear();
                foreach (CartItem i in G.cart.items)
                {
                    _item = new ItemCartInListProduct(i, on_cost_changed_handler);
                    lst_cart.Items.Add(_item);
                }
            }
        }


    }
}
