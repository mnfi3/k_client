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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for Toast.xaml
    /// </summary>
    
    public partial class Toast : Window
    {
        //Toast.message();
        //Toast.success();
        //Toast.error();

        private const string COLOR_MESSAGE = "#9978909C";
        private const string COLOR_SUCCESS = "#aa4CAF50";
        private const string COLOR_ERROR = "#99f44336";

        private static Toast toast;


        private int timeSecond;

        //public Toast()
        //{
        //    InitializeComponent();
        //}
        public Toast(string text, int second)
        {
            InitializeComponent();
            timeSecond = second;
            StartCloseTimer();
            txt_text.Text = text;
            this.Left = G.width;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            slideInLeft();
        }


        private void slideInLeft()
        {
            DoubleAnimation slideInRight = new DoubleAnimation();
            slideInRight.From = G.width;
            slideInRight.To = G.width/2 - 250;
            slideInRight.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            slideInRight.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slideInRight);
        }
        private void slideOutRight()
        {
            DoubleAnimation slideOutLeft = new DoubleAnimation();
            slideOutLeft.Completed += new EventHandler(slideOutFinished);

            slideOutLeft.From = G.width / 2 - 250;
            slideOutLeft.To = G.width;
            slideOutLeft.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            slideOutLeft.AccelerationRatio = .5;
            this.BeginAnimation(LeftProperty, slideOutLeft);
        }
        private void slideOutFinished(object sender, EventArgs e)
        {
            this.Close();
            //DialogResult = added;
        }






        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(timeSecond);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            slideOutRight();
        }



       






        public static void success(string text, int second = 2)
        {
            toast = new Toast(text, second);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_SUCCESS);
            toast.ShowDialog();
        }

        public static void error(string text, int second = 2)
        {
            toast = new Toast(text, second);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_ERROR);
            toast.ShowDialog();
        }

        public static void message(string text, int second = 2)
        {
            toast = new Toast(text, second);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_MESSAGE);
            toast.ShowDialog();
        }






        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Config.DEBUG) return;
            this.Close();
        }

        private void Window_TouchDown(object sender, TouchEventArgs e)
        {
            this.Close();
        }
    }
}
