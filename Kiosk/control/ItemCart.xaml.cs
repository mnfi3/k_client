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
    /// Interaction logic for ItemCart.xaml
    /// </summary>
    public partial class ItemCart : UserControl
    {
        private EventHandler eventChange = null, eventRemoved;
        public CartItem cartItem;

        public ItemCart(CartItem ci, EventHandler handler, EventHandler removeHandler)
        {
            InitializeComponent();

            this.cartItem = ci;
            eventChange += handler; 
            eventChange += dessertRemovedHandler;
            eventRemoved += removeHandler;
        }




        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_product.Text = cartItem.food.name;
            img_product.Source = null;
            img_product.ImageUrl = cartItem.food.image;
            txt_product_price.Text = Utils.persian_split(cartItem.cost) + " تومان ";
            txt_count.Text = cartItem.count.ToString();
            txt_count.Text = Utils.toPersianNum(cartItem.count);

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
                        eventRemoved(cartItem.food.name, new EventArgs());
                        break;
                    }
                }
            }
        }






        private void btn_up_Click(object sender, RoutedEventArgs e)
        {
            foreach(CartItem i in G.cart.items){
                if(i.food.id == this.cartItem.food.id)
                {
                    i.count++;
                    txt_count.Text = Utils.toPersianNum(i.count);
                    txt_product_price.Text = Utils.persian_split(i.cost) + " تومان ";
                    break;
                }
            }
            eventChange(cartItem.food.name, new EventArgs());
        }

        private void btn_down_Click(object sender, RoutedEventArgs e)
        {
            foreach (CartItem i in G.cart.items)
            {
                if (i.food.id == this.cartItem.food.id)
                {
                    if (i.count > 1)
                    {
                        i.count--;
                        txt_count.Text = Utils.toPersianNum(i.count);
                        txt_product_price.Text = Utils.persian_split(i.cost) + " تومان ";
                    }
                    break;
                }
            }
            eventChange(cartItem.food.name, new EventArgs());
        }



        private void dessertRemovedHandler(object sender, EventArgs e)
        {
            txt_product_price.Text = Utils.persian_split(this.cartItem.cost) + " تومان ";
        }



    }
}
