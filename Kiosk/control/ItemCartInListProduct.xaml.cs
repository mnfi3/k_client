using Kiosk.model;
using Kiosk.system;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for ItemCartInProducts.xaml
    /// </summary>
    public partial class ItemCartInListProduct : UserControl
    {

        public CartItem cartItem;
        EventHandler costChangeHandler;
        EventHandler removedHandler;

        public ItemCartInListProduct()
        {
            InitializeComponent();
        }

        public ItemCartInListProduct(CartItem item, EventHandler up_down_handler, EventHandler remove_handler)
        {
            InitializeComponent();
            this.cartItem = item;
            costChangeHandler += up_down_handler;
            removedHandler += remove_handler;
            
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_product.Text = cartItem.food.name;
            txt_count.Text = Utils.toPersianNum(cartItem.count);
            txt_price.Text = Utils.persian_split(cartItem.cost) + " تومان ";
            img_product.Source = null;
            img_product.ImageUrl = cartItem.food.image;
        }

        private void btn_up_Click(object sender, RoutedEventArgs e)
        {
            foreach (CartItem item in G.cart.items)
            {
                if (item.food.id == this.cartItem.food.id)
                {
                    item.count++;
                    txt_count.Text = Utils.toPersianNum(item.count);
                    txt_price.Text = Utils.persian_split(cartItem.cost) + " تومان ";
                    costChangeHandler(new object(), new EventArgs());
                    break;
                }
            }
        }

        private void btn_down_Click(object sender, RoutedEventArgs e)
        {
            foreach (CartItem item in G.cart.items)
            {
                if (item.food.id == this.cartItem.food.id)
                {
                    if (item.count > 1)
                    {
                        item.count--;
                        txt_count.Text = Utils.toPersianNum(item.count);
                        txt_price.Text = Utils.persian_split(cartItem.cost) + " تومان ";
                        costChangeHandler(new object(), new EventArgs());
                        break;
                    }
                }
            }
        }



        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            DialogPublic _d = new DialogPublic("آیا می خواهید " + cartItem.food.name + " را از سبد خرید حذف کنید؟");
            if (_d.ShowDialog() == true)
            {
                for (int i = 0; i < G.cart.items.Count; i++)
                {
                    if (this.cartItem.food.id == G.cart.items[i].food.id)
                    {
                        G.cart.items.RemoveAt(i);
                        this.Visibility = Visibility.Collapsed;
                        removedHandler(cartItem.food.name, new EventArgs());
                        break;
                    }
                }
            }
        }
    }
}
