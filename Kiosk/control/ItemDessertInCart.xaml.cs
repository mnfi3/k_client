using Kiosk.model;
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
    /// Interaction logic for ItemDessertInCart.xaml
    /// </summary>
    public partial class ItemDessertInCart : UserControl
    {
        public Dessert dessert;
        private EventHandler removeHandler;
        public ItemDessertInCart(Dessert d, EventHandler handler)
        {
            InitializeComponent();

            this.removeHandler += handler;
            this.dessert = d;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_name.Text = dessert.name;
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            foreach (CartItem item in G.cart.items)
            {
                if (item.product.id == this.dessert.product_id)
                {
                    for (int i = 0; i < item.desserts.Count; i++)
                    {
                        if (item.desserts[i].id == this.dessert.id){
                            item.desserts.RemoveAt(i);
                            this.Visibility = Visibility.Collapsed;
                            break;
                        }
                    }
                        
                }
            }

            removeHandler(dessert.name, new EventArgs());
        }
    }
}
