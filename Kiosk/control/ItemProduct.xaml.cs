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
            if (product.discount_percent == 0) txt_product_price.Visibility = Visibility.Collapsed;
            txt_product.Text = product.name;
            txt_product_d_price.Text = Utils.persian_split(product.d_price) + " تومان ";
            txt_product_price.Text = Utils.persian_split(product.price) + " تومان ";
            //BitmapImage b = new BitmapImage();
            //b.BeginInit();
            //b.UriSource = new Uri("B:\\programing\\C#\\Kiosk\\Kiosk\\img\\ic_pasta.jpg");
            //b.EndInit();
            img_product.Source = null;
            img_product.ImageUrl = product.image;
            if (product.d_price < product.price)
            {
                lbl_discount.Visibility = Visibility.Visible;
               
                string discount = (product.discount_percent).ToString() + "%";
                lbl_discount.Text = Utils.toPersianNum(discount);
            }
            else
            {
                lbl_discount.Visibility = Visibility.Collapsed;
            }


            double height = G.height / 2.5;
            double img_height = (height / 7) * 5;
            this.Height = height;
            grd_main.RowDefinitions[0].Height = new GridLength(img_height); ;
            this.img_product.Height = img_height;

        }



    }
}
