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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        List<Food> suggests ;
        List<Food> sides;

        private Food product;
        private CartItem cartItem;
        private int count = 1;
        private bool added = false;
        private EventHandler addToCartHandler;
        private bool desserts_loaded = false;



        //public ProductInfo()
        //{
        //    InitializeComponent();
        //}

        public ProductInfo(Food p, EventHandler handler)
        {
            InitializeComponent();

            suggests = G.restaurant.all_product.suggets;
            sides = G.restaurant.all_product.sides;

            



            this.product = p;
            this.Height = G.height;
            this.Width = G.width;
            //this.Left = G.width;

            addToCartHandler += handler;
            cartItem = new CartItem();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            fadeIn();

            BlurEffect blur = new BlurEffect();
            btn_add.Effect = blur;
            btn_cancel.Effect = blur;

            txt_name.Text = product.name;
            txt_count.Text = Utils.toPersianNum(count);
            txt_d_price.Text = Utils.persian_split(product.d_price) + " تومان ";
            txt_price.Text = Utils.persian_split(product.price) + " تومان ";
            if (product.discount_percent == 0)
            {
                txt_price.Visibility = Visibility.Collapsed;
            }
            txt_description.Text = product.description;
            img_product.Source = null;
            img_product.ImageUrl = product.image;
            cartItem.food = this.product;




            if (G.cart.isExistInCart(this.product) == true)
            {
                this.cartItem = G.cart.findByProduct(this.product);
                //btn_cancel.Content = "بازگشت";
                //btn_add.Content = "اعمال تغییرات";
                count = cartItem.count;
                txt_count.Text = Utils.toPersianNum(count);
                txt_total.Text = Utils.persian_split(cartItem.cost) + " تومان ";
            }
            loadSides();
        }

        private void Window_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }




        private void fadeIn()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(fadeInFinished);
            slide.From = 0;
            slide.To = 1;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            slide.AccelerationRatio = .5;
            grd_main.BeginAnimation(OpacityProperty, slide);
        }

        private void fadeInFinished(object sender, EventArgs e)
        {
        }

        private void fadeOut()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(fadeOutFinished);
            slide.From = 1;
            slide.To = 0;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            slide.AccelerationRatio = .5;
            grd_main.BeginAnimation(OpacityProperty, slide);
        }
        private void fadeOutFinished(object sender, EventArgs e)
        {
            addToCartHandler(added, new EventArgs());
            this.Close();
        }








        private void sidesLoadedCallBack(object sender, EventArgs e)
        {
            loadCartItem();

            refreshCartItem();
            desserts_loaded = true;
            btn_add.Effect = null;
            btn_cancel.Effect = null;
        }








        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (!desserts_loaded) return;
            added = false;
            fadeOut();

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (!desserts_loaded) return;

            if (G.cart.isExistInCart(this.product) == true)
            {
                G.cart.remove(cartItem);
            }


            G.cart.items.Add(this.cartItem);
            added = true;
            fadeOut();

        }


        private void btn_up_Click(object sender, RoutedEventArgs e)
        {
            count++;
            txt_count.Text = Utils.toPersianNum(count);

            cartItem.count = count;
            refreshCartItem();
        }

        private void btn_down_Click(object sender, RoutedEventArgs e)
        {
            if (count > 1)
            {
                count--;
                cartItem.count = count;
                txt_count.Text = Utils.toPersianNum(count);

                refreshCartItem();
            }
        }




        private void lst_sides_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!desserts_loaded)
            {
                lst_sides.SelectedItem = null;
                return;
            }
            if ((sender as ListView).SelectedItem == null) return;


            ItemSide _item = (ItemSide)(sender as ListView).SelectedItem;
            if (_item != null)
            {
                CartItem c_item = new CartItem(_item.side);
                if (_item.setSelection())
                {
                    if(!G.cart.isExistInCart(_item.side)) G.cart.items.Add(c_item);
                }
                else
                {
                    if (G.cart.isExistInCart(_item.side)) G.cart.remove(c_item);
                }
            }

            refreshCartItem();



            lst_sides.SelectedItem = null;
        }

        private void lst_suggests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!desserts_loaded)
            {
                lst_suggests.SelectedItem = null;
                return;
            }
            if ((sender as ListView).SelectedItem == null) return;


            ItemSide _item = (ItemSide)(sender as ListView).SelectedItem;
            ProductInfo _info = new ProductInfo(_item.side, addToCartHandler);
            _info.Show();
            this.Close();


            lst_suggests.SelectedItem = null;
        }


        private async void loadSides()
        {
            lst_sides.Items.Clear();
            lst_suggests.Items.Clear();
            ItemSide _item;

            //add sides
            foreach (Food f in sides)
            {
                _item = new ItemSide(f);
                lst_sides.Items.Add(_item);
                await Task.Delay(10);
            }

            //add suggests
            foreach (Food f in suggests)
            {
                _item = new ItemSide(f);
                lst_suggests.Items.Add(_item);
                await Task.Delay(10);
            }

            sidesLoadedCallBack(new object(), new EventArgs());

        }








        private void loadCartItem()
        {

            count = cartItem.count;
            txt_count.Text = Utils.toPersianNum(count);
            txt_total.Text = Utils.persian_split(cartItem.cost) + " تومان ";

            foreach (ItemSide _item1 in lst_sides.Items)
            {
                foreach (CartItem ci in G.cart.items)
                {
                    if (ci.food.id == _item1.side.id)
                    {
                        _item1.is_selected = true;
                        _item1.PulseBox.Background = Brushes.White;
                        break;
                    }
                }
            }

        }



        private void refreshCartItem()
        {

            //foreach (ItemSide item in lst_sides.Items)
            //{
            //    if (item.is_selected == true)
            //    {
            //        item.dessert.product_id = this.product.id;
            //        cartItem.desserts.Add(item.dessert);
            //    }
            //}

            txt_total.Text = Utils.persian_split(cartItem.cost) + " تومان ";
        }



    }
}
