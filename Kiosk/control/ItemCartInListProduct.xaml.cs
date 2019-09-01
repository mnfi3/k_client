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

        CartItem cartItem;

        public ItemCartInListProduct()
        {
            InitializeComponent();
        }

        public ItemCartInListProduct(CartItem item)
        {
            InitializeComponent();
            this.cartItem = item;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_product.Text = cartItem.product.name;
            txt_count.Text = cartItem.count.ToString();
            txt_price.Text = Utils.persian_split(cartItem.product.d_price) + " تومان ";
            img_product.Source = null;
            img_product.ImageUrl = cartItem.product.image;
        }

        private void btn_up_Click(object sender, RoutedEventArgs e)
        {
            foreach (CartItem item in G.cart.items)
            {
                if (item.product.id == this.cartItem.product.id)
                {
                    item.count++;
                    txt_count.Text = item.count.ToString();
                    break;
                }
            }
        }

        private void btn_down_Click(object sender, RoutedEventArgs e)
        {
            foreach (CartItem item in G.cart.items)
            {
                if (item.product.id == this.cartItem.product.id)
                {
                    if (item.count > 1)
                    {
                        item.count--;
                        txt_count.Text = item.count.ToString();
                        break;
                    }
                }
            }
        }
    }
}
