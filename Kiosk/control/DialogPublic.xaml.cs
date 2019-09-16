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

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for DialogPublic.xaml
    /// </summary>
    public partial class DialogPublic : Window
    {

        bool result;
        public DialogPublic()
        {
            InitializeComponent();
        }

        public DialogPublic(string text)
        {
            InitializeComponent();
            txt_text.Text = text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            slideInBottom();
        }



        private void slideInBottom()
        {
            DoubleAnimation slideAnim = new DoubleAnimation();
            slideAnim.From = G.height;
            slideAnim.To = G.height / 2 - 150;
            slideAnim.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            slideAnim.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slideAnim);
        }
        private void slideOutBottom()
        {
            DoubleAnimation slideAnim = new DoubleAnimation();
            slideAnim.Completed += new EventHandler(slideOutFinished);

            slideAnim.From = G.height / 2 - 150;
            slideAnim.To = G.height;
            slideAnim.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            slideAnim.AccelerationRatio = .5;
            this.BeginAnimation(TopProperty, slideAnim);
        }
        private void slideOutFinished(object sender, EventArgs e)
        {
            DialogResult = result;
        }







        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            result = true;
            slideOutBottom();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            result = false;
            slideOutBottom();
        }


        public static void show(string text){
            DialogPublic d = new DialogPublic();
            d.txt_text.Text = text;
            d.ShowDialog();
        }

       

    }
}
