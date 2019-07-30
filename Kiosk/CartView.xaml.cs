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
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using System.Windows.Media.Effects;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class CartView : Window
    {

        private List<ItemCart> carts = new List<ItemCart>();

        private readonly Toast toast;


        public CartView(List<ItemCart> carts)
        {
            InitializeComponent();
            this.carts = carts;


            toast = new Toast(this);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (ItemCart i in carts)
            {
                lst_cart.Items.Add(i);
            }

            ItemCart _item;
            for (int i = 0; i < 30; i++)
            {
                _item = new ItemCart();
                lst_cart.Items.Add(_item);
            }

            //toast.OnUnloaded();
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
            ListProducts _listProducts = new ListProducts(this.carts);
            _listProducts.ShowDialog();
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

            toast.ShowInformation("کد تخفیف را وارد کنید");
        }

        private void btn_pay_Click(object sender, RoutedEventArgs e) 
        {
            BlurEffect blur = new BlurEffect();
            grd_main.Effect = blur;

            DialogPaymentAccept dialog = new DialogPaymentAccept();
            if (dialog.ShowDialog() == true)
            {
                DialogCartSwipe dialog2 = new DialogCartSwipe();
                dialog2.ShowDialog();
            }
            else
            {
                grd_main.Effect = null;
            }
        }
            
    }
}
