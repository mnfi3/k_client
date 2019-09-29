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
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ListProducts.xaml
    /// </summary>
    public partial class ListProducts : Window
    {

        private Restaurant restaurant;
        Category active_category;
        System.Timers.Timer timer = new System.Timers.Timer();




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
            slideInRight();

            grd_main2.Effect = new BlurEffect();
            prg_loading.Start();
            //show btn_back_to_restaurants button if have more than one restaurant
            if (G.restaurants.Count > 1)
            {
                btn_back_to_restaurants.Visibility = Visibility.Visible;
            }

            if (G.cart.items.Count > 0)
            {
                this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
            }

            loadProducts();
            loadCart();
            txt_total.Text = Utils.persian_split(G.cart.cost) + " ت ";


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



        //private void animCallback(object sender, EventArgs e)
        //{
        //    loadProducts();
        //    loadCart();
        //}



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_cart_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }
            ListRestaurant _window = new ListRestaurant(true);
            _window.Show();

            //CartView _cartView = new CartView();
            //_cartView.Show();
            //this.Close();

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
                ItemCategory _cat = (ItemCategory)(sender as ListView).SelectedItem;
                _cat.txt_category.Foreground = Brushes.Green;
                if (active_category == _cat.category)
                {
                    return;
                }
                else
                {
                    active_category = _cat.category;
                    renderProducts(_cat.category);
                    txt_category_name.Text = _cat.category.name;
                }
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
            ItemCategory _cat = (ItemCategory)lst_categories.Items[0];
            active_category = _cat.category;
            _cat.txt_category.Foreground = Brushes.Green;
            renderProducts(_cat.category);
            txt_category_name.Text = _cat.category.name;
            lst_categories.SelectedItem = null;
        }

        private void lst_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem == null) return;

            ItemProduct _item = (ItemProduct)(sender as ListView).SelectedItem;
            ProductInfo _info = new ProductInfo(_item.product, addToCartCallBack);
            _info.Show();
            this.Hide();

            lst_products.SelectedItem = null;

        }

        private void addToCartCallBack(object sender, EventArgs e)
        {

            this.Show();
            if ((bool)sender == true)
            {
                loadCart();
                if (G.cart.items.Count > 0)
                {
                    this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
                }
                txt_total.Text = Utils.persian_split(G.cart.cost) + " ت ";
                Toast.success ("به سبد خرید اضافه شد", 1);

            }
            else
            {
                loadCart();
                txt_total.Text = Utils.persian_split(G.cart.cost) + " ت ";
                if (G.cart.items.Count > 0)
                {
                    this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
                }
                else
                {
                    this.cln_cart.Width = new GridLength(0, GridUnitType.Star);
                }
            }
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

            grd_main2.Effect = null;
            prg_loading.Stop();
            prg_loading.Visibility = Visibility.Collapsed;

           
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

        private async void renderProducts(Category c)
        {
            lst_products.Items.Clear();
            ItemProduct _item;
            foreach (Product p in c.products)
            {
                _item = new ItemProduct(p);
                lst_products.Items.Add(_item);
                await Task.Delay(70);
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
            slideOutLeft();
            

        }


        private void on_cost_changed_handler(object sender, EventArgs e)
        {
            txt_total.Text = Utils.persian_split(G.cart.cost) + " ت ";
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



        private void slideInRight()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(slideInFinished);
            slide.From = G.width;
            slide.To = 0;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            slide.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slide);
        }

        private void slideInFinished(object sender, EventArgs e)
        {
        }

        private void slideOutLeft()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(slideOutFinished);
            slide.From = 0;
            slide.To = -G.width;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            slide.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slide);
        }
        private void slideOutFinished(object sender, EventArgs e)
        {
            CartView _cartView = new CartView();
            _cartView.Show();
            this.Close();
        }

    }
}
