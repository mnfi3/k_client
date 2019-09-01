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

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for temp.xaml
    /// </summary>
    public partial class temp : Window
    {
        public temp()
        {
            InitializeComponent();
        }
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DoubleAnimation da = new DoubleAnimation();
            //da.From = 1920;
            //da.To = 0;
            //da.Duration = new Duration(TimeSpan.FromSeconds(1));
            //da.AutoReverse = true;
            //da.RepeatBehavior = RepeatBehavior.Forever;
            //da.RepeatBehavior = new RepeatBehavior(3);
            //window_1.BeginAnimation(Window.LeftProperty, da);


            //var T = new TranslateTransform(900, 0);
            //Duration duration = new Duration(new TimeSpan(0, 0, 0, 0, 800));
            //DoubleAnimation anim = new DoubleAnimation(0, duration);
            //T.BeginAnimation(TranslateTransform.YProperty, anim);
            //window_1.RenderTransform = T;
            //this.Left = 50;
            
            //DoubleAnimation doubleanimation = new DoubleAnimation();
            //doubleanimation.To = SystemParameters.PrimaryScreenHeight - (this.Height+50);
            //doubleanimation.From = SystemParameters.PrimaryScreenHeight;
            //doubleanimation.AutoReverse = false;

            //Storyboard storyboard = new Storyboard();

            //Storyboard.SetTarget(doubleanimation, this);
            //Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(Window.TopProperty));

            //storyboard.Children.Add(doubleanimation);
            //storyboard.Begin(this);
        }
    }
}
