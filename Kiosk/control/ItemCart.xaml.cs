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
        public ItemCart()
        {
            InitializeComponent();

            ItemDessertInCart _item;

            for (int i = 0; i < 2; i++)
            {
                _item = new ItemDessertInCart();
                lst_desserts.Items.Add(_item);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
