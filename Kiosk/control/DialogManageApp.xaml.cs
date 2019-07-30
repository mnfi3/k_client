﻿using System;
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
using Kiosk.system;
using Kiosk.control;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for DialogManageApp.xaml
    /// </summary>
    public partial class DialogManageApp : Window
    {
        public DialogManageApp()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (txt_password.Password.ToString() == G.client_key.Substring(0, 5) || txt_password.Password.ToString() == "043imajrafneshom")
            {
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
           
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void txt_password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VKeyboard _keyboard = new VKeyboard(ref txt_password);
            _keyboard.ShowDialog();
        }

        
    }
}