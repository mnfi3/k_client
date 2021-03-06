﻿using Kiosk.system;
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

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for MB.xaml
    /// </summary>
    public partial class MB : Window
    {
        public MB()
        {
            InitializeComponent();
        }

        


        public static void Show(string text)
        {
            try
            {
                MB mb = new MB();
                mb.txt_text.Text = text;
                mb.ShowDialog();
            }
            catch (InvalidOperationException e)
            {

            }
        }

        private void btn_ok_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (!Config.DEBUG) return;
            this.Close();
        }
    }
}
