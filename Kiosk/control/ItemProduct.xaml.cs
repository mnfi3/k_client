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
    /// Interaction logic for ItemProduct.xaml
    /// </summary>
    public partial class ItemProduct : UserControl
    {

        public Product product;
        public ItemProduct()
        {
            InitializeComponent();
        }

        public ItemProduct(Product p)
        {
            InitializeComponent();

            this.product = p;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_product.Text = product.name;
            txt_product_price.Text = Utils.persian_split(product.d_price) + " تومان ";
            img_product.Source = null;
            img_product.ImageUrl = product.image;
            if (product.d_price < product.price)
            {
                lbl_discount.Visibility = Visibility.Visible;
                float price = product.price;
                float d_price = product.d_price;
                lbl_discount.Content =  ((int)   (((price - d_price) / price) * 100)   ).ToString() + "%";
            }
            else
            {
                lbl_discount.Visibility = Visibility.Collapsed;
            }
        }



    }
}
