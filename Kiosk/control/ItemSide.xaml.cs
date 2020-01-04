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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for ItemDessert.xaml
    /// </summary>
    public partial class ItemSide : UserControl
    {
        public Food side;
        public bool is_selected;
        public ItemSide()
        {
            InitializeComponent();
        }

        public ItemSide(Food s)
        {
            InitializeComponent();
            is_selected = false;
            this.side = s;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_name.Text = side.name;
            img_dessert.ImageUrl = side.image;
            txt_price.Text = Utils.persian_split(side.d_price) + " تومان ";
        }


        public bool setSelection()
        {
            if (is_selected == true)
            {
               PulseBox.Background = Brushes.Transparent;
               PulseBox.Effect = null;
               is_selected = false;
               return false;
            }
            else
            {
                PulseBox.Background = (Brush)new BrushConverter().ConvertFrom("#fcfcfc");
                DropShadowEffect effect = new DropShadowEffect();
                effect.ShadowDepth = 1;
                effect.BlurRadius = 2;
                effect.Opacity = 0.5;
                PulseBox.Effect = effect;
                is_selected = true;
                return true;
            }
        }
    }
}
