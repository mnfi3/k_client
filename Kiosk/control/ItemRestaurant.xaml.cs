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
    /// Interaction logic for ItemRestaurant.xaml
    /// </summary>
    public partial class ItemRestaurant : UserControl
    {

        public Restaurant restaurant;
        public ItemRestaurant()
        {
            InitializeComponent();
        }

        public ItemRestaurant(Restaurant rest)
        {
            InitializeComponent();

            this.restaurant = rest;

            txt_name.Text = rest.name;
            img_restaurant.ImageUrl = rest.image;
        }


    }
}
