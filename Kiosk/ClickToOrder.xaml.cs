using Kiosk.api;
using Kiosk.db;
using Kiosk.model;
using Kiosk.preference;
using Kiosk.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            renderViews();

            syncData();
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




        






        private void open_list_restaurant(object sender, MouseEventArgs e)
        {
            DoubleAnimation slideUp = new DoubleAnimation();
            slideUp.Completed += new EventHandler(slideUpFinished);
            slideUp.Completed += this.handler;
            slideUp.From = 0;
            slideUp.To = -G.height;
            slideUp.Duration = new Duration(TimeSpan.FromMilliseconds(350));
            slideUp.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slideUp);
        }

        private void slideUpFinished(object sender,EventArgs e)
        {
            this.Close();
        }








        private async void syncData()
        {
            DataSync syncer = new DataSync();
            await Task.Run(() => {
                syncer.syncAllData();
            });
           

        }

       
    }

}
