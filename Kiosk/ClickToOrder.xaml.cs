﻿using Kiosk.api;
using Kiosk.db_lite;
using Kiosk.model;
using Kiosk.preference;
using Kiosk.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for ClickToOrder.xaml
    /// </summary>
    public partial class ClickToOrder : Window
    {
        EventHandler handler;
        Thread thread;
        bool is_closing_windows = false;

        bool is_syncing_data = false;
        bool is_request_to_open_restaurants = false;

        
        //public ClickToOrder()
        //{
        //    InitializeComponent();
        //    this.Height = G.height;
        //    this.Width = G.width;
        //}

        public ClickToOrder(EventHandler handler)
        {
            InitializeComponent();
            this.handler += handler;
            this.Height = G.height;
            this.Width = G.width;

           

        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            fadeInBorder();
            renderViews();
            prg_wait.Visibility = Visibility.Collapsed;

            thread = new Thread(syncData);
            thread.Start();
            //syncData2();
        }




        private void renderViews()
        {
            //brdr_description.Effect = new BlurEffect();
            if (G.restaurants.Count > 0)
            {
                txt_description.Text = G.restaurants[0].description;
                img_splash.ImageUrl = G.restaurants[0].image;
            }

            
        }


        private void fadeInBorder()
        {
            
            DoubleAnimation slide = new DoubleAnimation();
            //slide.Completed += new EventHandler(fadeInFinished);
            slide.From = 0;
            slide.To = 1;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            slide.AccelerationRatio = .5;
            brdr_click_to_order.BeginAnimation(OpacityProperty, slide);
        }






        private void open_list_restaurant(object sender, MouseEventArgs e)
        {
            Task.Delay(200);
            if (is_closing_windows) return;
            is_closing_windows = true;

            openRestaurants();
        }


        private void open_list_restaurant2(object sender, TouchEventArgs e)
        {
            if (is_closing_windows) return;
            is_closing_windows = true;

            openRestaurants();
        }


        private void openRestaurants()
        {
            if(is_syncing_data)
            {
                is_request_to_open_restaurants = true;
                //BlurEffect ef = new BlurEffect();
                //this.Effect = ef;
                windowEffect();
                return;
            }

            thread.Abort();

            DoubleAnimation slideUp = new DoubleAnimation();
            slideUp.Completed += new EventHandler(slideUpFinished);
            slideUp.Completed += this.handler;
            slideUp.From = 0;
            slideUp.To = -G.height;
            slideUp.Duration = new Duration(TimeSpan.FromMilliseconds(350));
            slideUp.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slideUp);
        }




        private void windowEffect()
        {
            BlurEffect blur = new BlurEffect();
            PulseBox.Effect = blur;
            prg_wait.Visibility = Visibility.Visible;

            //BlurEffect blur = new BlurEffect();
            //while (is_syncing_data)
            //{
            //    this.Effect = blur;
            //    await Task.Delay(20);
            //    this.Effect = null;
            //    await Task.Delay(20);
            //}
        }
        

        private void slideUpFinished(object sender,EventArgs e)
        {
            thread.Abort();
            this.Close();
        }








        private void syncData()
        {
            DataSync syncer = new DataSync();
            while (true)
            {
                Thread.Sleep(1000);

                this.Dispatcher.Invoke((Action)(() =>
                {
                    txt_description.Text = "task started";
                }));

                is_syncing_data = true;
                syncer.syncAllData(onSyncFinished);


                Thread.Sleep(Config.SYNC_DATA_TIME);
                //Thread.Sleep(10000);


                
            }
        }



        private void onSyncFinished(object sender, EventArgs e)
        {
            is_syncing_data = false;

            this.Dispatcher.Invoke((Action)(() =>
            {
                txt_description.Text = "task finished";
            }));


            if (is_request_to_open_restaurants)
            {
                thread.Abort();

                this.Dispatcher.Invoke((Action)(() =>
                {
                    this.Effect = null;
                    openRestaurants();
                }));
            }


           
        }


        //private async void syncData2()
        //{
        //    DataSync syncer = new DataSync();
        //    await Task.Run(() =>
        //    {
        //        while (true)
        //        {
        //            is_sync_task_running = true;
        //            syncer.syncAllData();
        //            is_sync_task_running = false;
        //            Task.Delay(Config.SYNC_DATA_TIME);
        //        }
        //    });
        //}

       
    }

}
