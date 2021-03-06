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
using System.Windows.Media.Effects;
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

        private const string COLOR_MESSAGE = "#dd78909C";
        private const string COLOR_SUCCESS = "#dd00b356";
        private const string COLOR_ERROR = "#ddf44336";

        private static Toast toast;
        private Grid grid = null;


        private double timeSecond;

        //public Toast()
        //{
        //    InitializeComponent();
        //}
        public Toast(string text, double second)
        {
            InitializeComponent();
            timeSecond = second;
            StartCloseTimer();
            txt_text.Text = text;
            this.Left = G.width;
        }

        public Toast(string text, double second, ref Grid g)
        {
            InitializeComponent();
            timeSecond = second;
            StartCloseTimer();
            txt_text.Text = text;
            this.Left = G.width;
            this.grid = g;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (grid != null) grid.Effect =  new BlurEffect();
            //slideInTop();
            sizeUp();
        }




        private void slideInTop()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(slideInFinished);
            slide.From =0;
            slide.To = G.height / 2 - 50;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            slide.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slide);
        }

        private void slideInFinished(object sender, EventArgs e)
        {
            if (grid != null) grid.Effect = new BlurEffect();
        }

        private void slideOutBottom()
        {
            DoubleAnimation slide = new DoubleAnimation();
            slide.Completed += new EventHandler(slideOutFinished);

            slide.From = G.height / 2 - 50;
            slide.To = G.height;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            slide.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slide);
        }
        private void slideOutFinished(object sender, EventArgs e)
        {
            if(grid != null) this.grid.Effect = null;
            this.Close();
        }


        //=================================================
        private void sizeUp()
        {
            DoubleAnimation w = new DoubleAnimation();
            w.Completed += new EventHandler(sizeUpFinished);
            w.From = 0;
            w.To = 500;
            w.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            w.AccelerationRatio = .5;
            //DoubleAnimation h = new DoubleAnimation();
            //h.From = 0;
            //w.To = 100;
            //h.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            //h.AccelerationRatio = .5;

            this.BeginAnimation(WidthProperty, w);
            //this.BeginAnimation(HeightProperty, h);
        }

        private void sizeUpFinished(object sender, EventArgs e)
        {
            if (grid != null) grid.Effect = new BlurEffect();
        }

        private void sizeDown()
        {
            DoubleAnimation w = new DoubleAnimation();
            w.Completed += new EventHandler(sizeDownFinished);
            w.From = 500;
            w.To = 0;
            w.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            w.AccelerationRatio = .5;
            //DoubleAnimation h = new DoubleAnimation();
            //w.From = 100;
            //h.To = 0;
            //h.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            //h.AccelerationRatio = .5;

            this.BeginAnimation(WidthProperty, w);
            //this.BeginAnimation(HeightProperty, h);
        }
        private void sizeDownFinished(object sender, EventArgs e)
        {
            if (grid != null) this.grid.Effect = null;
            this.Close();
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
            //slideOutBottom();
            sizeDown();
        }










        public static void success(string text, double second = 1.5)
        {
            toast = new Toast(text, second);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_SUCCESS);
            toast.ShowDialog();
        }
        public static void successBlur(string text, ref Grid g, double second = 1.5)
        {
            toast = new Toast(text, second, ref g);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_SUCCESS);
            toast.ShowDialog();
        }

        public static void error(string text, double second = 1.5)
        {
            toast = new Toast(text, second);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_ERROR);
            toast.ShowDialog();
        }
        public static void errorBlur(string text, ref Grid g, double second = 1.5)
        {
            toast = new Toast(text, second, ref g);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_ERROR);
            toast.ShowDialog();
        }

        public static void message(string text, double second = 1.5)
        {
            toast = new Toast(text, second);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_MESSAGE);
            toast.ShowDialog();
        }

        public static void messageBlur(string text, ref Grid g, double second = 1.5)
        {
            toast = new Toast(text, second, ref g);
            toast.PulseBox.Background = (Brush)new BrushConverter().ConvertFrom(COLOR_MESSAGE);
            toast.ShowDialog();
        }

        



      



        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Config.DEBUG) return;
            //slideOutBottom();
            sizeDown();
        }

        private void Window_TouchDown(object sender, TouchEventArgs e)
        {
            //slideOutBottom();
            sizeDown();
        }
    }
}
