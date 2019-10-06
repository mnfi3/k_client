﻿using Kiosk.model;
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
    public partial class ItemDessert : UserControl
    {
        public Dessert dessert;
        public bool is_selected;
        public ItemDessert()
        {
            InitializeComponent();
        }

        public ItemDessert(Dessert d)
        {
            InitializeComponent();
            is_selected = false;
            this.dessert = d;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_name.Text = dessert.name;
            img_dessert.ImageUrl = dessert.image;
            txt_price.Text = Utils.persian_split(dessert.price) + " تومان ";
        }


        public void setSelection()
        {
            if (is_selected == true)
            {
               PulseBox.Background = Brushes.Transparent;
               PulseBox.Effect = null;
               is_selected = false;
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
            }
        }
    }
}
