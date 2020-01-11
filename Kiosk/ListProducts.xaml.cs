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
using Kiosk.preference;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ListProducts.xaml
    /// </summary>
    public partial class ListProducts : Window
    {

        private Restaurant restaurant;
        AllProduct all_product;
        Category active_category;
        bool is_loaded_data = false;
        System.Timers.Timer timer;
        bool is_closed_window = false;





        public ListProducts()
        {
            InitializeComponent();

            this.Height = G.height;
            this.Width = G.width;
            this.cln_cart.Width =new  GridLength(0, GridUnitType.Star);
            this.restaurant = G.restaurant;
            resetTimer();

        }







        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fadeIn();
        }


        private void Window_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            is_closed_window = true;
            disableTimer();
        }

        private void resetTimer()
        {
            if (timer != null)
            {
                disableTimer();
            }
            timer = G.getTimer(timeFinished);
        }

        private void timeFinished(object sender, EventArgs e)
        {
            disableTimer();

            if (is_closed_window) return;
            this.Dispatcher.Invoke(() =>
            {
                ListRestaurant _list = new ListRestaurant(true);
                _list.Show();
                this.Close();
            });
        }

        private void disableTimer()
        {
            try
            {
                timer.AutoReset = false;
                timer.Stop();
                timer.Enabled = false;
                timer = null;
            }
            catch (Exception e) { }
        }



        

       
      

        




        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            disableTimer();

            System.Windows.Application.Current.Shutdown();
        }


      




        private void btn_back_to_restaurants_Click(object sender, RoutedEventArgs e)
        {
            disableTimer();
            ListRestaurant _list = new ListRestaurant(true);
            _list.Show();
            this.Close();
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

            disableTimer();

            ItemProduct _item = (ItemProduct)(sender as ListView).SelectedItem;
            ProductInfo _info = new ProductInfo(_item.food, addToCartCallBack);
            _info.Show();
            this.Hide();
            lst_products.SelectedItem = null;

        }

        private void addToCartCallBack(object sender, EventArgs e)
        {
            resetTimer();

            this.Show();
            if ((bool)sender == true)
            {
                loadCart();
                if (G.cart.items.Count > 0)
                {
                    this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
                }
                txt_total.Text = Utils.persian_split(G.cart.cost) + " ت ";
                //Toast.success ("به سبد خرید اضافه شد", 1);

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
            all_product = sender as AllProduct;
            List<Category> categories = all_product.categories;
            List<Food> sides = sender as List<Food>;

            //if connection was fail
            //if (categories.Count == 0)
            //{
                Task.Run(() =>{
                    all_product = db_products.getProducts(this.restaurant);
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        loadCategories(all_product.categories);
                    }));
                });
            //}
            //else
            //{
            //    loadCategories(categories);
            //    //save new products to local db
            //    Task.Run(() =>
            //    {
            //        db_products.resetProducts(all_product, this.restaurant);
            //    });
            //}

            G.restaurant.all_product = all_product;


            grd_main2.Effect = null;
            prg_loading.Stop();
            prg_loading.Visibility = Visibility.Collapsed;
            is_loaded_data = true;

           
        }


        private async void loadCart()
        {
            ItemCartInListProduct _item;

            //add new items to listview
            foreach (CartItem i in G.cart.items)
            {
                bool is_find = false;
                foreach (ItemCartInListProduct ic in lst_cart.Items)
                {
                    if (i.food.id == ic.cartItem.food.id)
                    {
                        is_find = true;
                        break;
                    }
                }

                if (!is_find)
                {
                    _item = new ItemCartInListProduct(i, on_cost_changed_handler, on_cart_item_removed_handler);
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
                    if (i.food.id == ic.cartItem.food.id)
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
                    _item = new ItemCartInListProduct(i, on_cost_changed_handler, on_cart_item_removed_handler);
                    lst_cart.Items.Add(_item);
                }
            }


            //reload cart items price and count
            foreach (ItemCartInListProduct ic in lst_cart.Items)
            {
                ic.txt_price.Text = Utils.persian_split(ic.cartItem.cost) + " تومان ";
                ic.txt_count.Text = Utils.toPersianNum(ic.cartItem.count);
            }
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
            int index = 0;
            foreach (Food p in c.foods)
            {
                if (c.id != active_category.id) return;
                _item = new ItemProduct(p, addToCartCallBack);
                lst_products.Items.Add(_item);
                await Task.Delay(70);
                if (index == 0) lst_products.ScrollIntoView(lst_products.Items[0]);
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
                disableTimer();

                DeviceLogin _login = new DeviceLogin();
                _login.Show();
                this.Close();
            }
        }

        private void btn_checkout_Click(object sender, RoutedEventArgs e)
        {
            disableTimer();

            CartView _cartView = new CartView();
            _cartView.Show();
            this.Close();
            

        }


        private void on_cost_changed_handler(object sender, EventArgs e)
        {
            txt_total.Text = Utils.persian_split(G.cart.cost) + " ت ";
        }

        private void on_cart_item_removed_handler(object sender, EventArgs e)
        {
            txt_total.Text = Utils.persian_split(G.cart.cost) + " ت ";

            if (G.cart.items.Count > 0)
            {
                this.cln_cart.Width = new GridLength(2.5, GridUnitType.Star);
            }
            else
            {
                this.cln_cart.Width = new GridLength(0, GridUnitType.Star);
            }

            loadCart();
        }







        private void fadeIn()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(fadeInFinished);
            //slide.From = G.width;
            slide.From = 0;
            //slide.To = 0;
            slide.To = 1;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            slide.AccelerationRatio = .5;
            //this.BeginAnimation(LeftProperty, slide);
            grd_main.BeginAnimation(OpacityProperty, slide);
        }

        private void fadeInFinished(object sender, EventArgs e)
        {
            if (!is_loaded_data)
            {
                grd_main2.Effect = new BlurEffect();
                prg_loading.Start();
                prg_loading.Visibility = Visibility.Visible;
            }
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

           
        }

        private void fadeOut()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(fadeOutFinished);
            //slide.From = G.width;
            slide.From = 1;
            //slide.To = 0;
            slide.To = 0;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            slide.AccelerationRatio = .5;
            //this.BeginAnimation(LeftProperty, slide);
            grd_main.BeginAnimation(OpacityProperty, slide);
        }
        private void fadeOutFinished(object sender, EventArgs e)
        {
            CartView _cartView = new CartView();
            _cartView.Show();
            this.Close();
        }

       

       

    }
}
