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

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for DialogTest.xaml
    /// </summary>
    public partial class DialogTest : Window
    {
        
        public DialogTest()
        {
            InitializeComponent();
            
        }

        public DialogTest(string text)
        {
            InitializeComponent();
            txt_text.Text = text;
        }
    }
}
