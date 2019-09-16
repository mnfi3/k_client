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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for VKeyboard.xaml
    /// </summary>
    public partial class VKeyboard : Window
    {
        public VKeyboard()
        {
            InitializeComponent();
        }

        private TextBox input = null;
        private PasswordBox input2 = null;
        private bool capselock = false;

        public VKeyboard(ref TextBox txt_input)
        {
            InitializeComponent();

            input = txt_input;
        }

        public VKeyboard(ref PasswordBox txt_input)
        {
            InitializeComponent();


            input2 = txt_input;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Application curApp = Application.Current;
            //Window mainWindow = curApp.MainWindow;
            //this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            //this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
            opacityIn();
        }

        private void opacityIn()
        {
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = 0;
            anim.To = 1;
            anim.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            anim.AccelerationRatio = .5;
            this.BeginAnimation(OpacityProperty, anim);
        }

        private void opacityOut()
        {
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = 1;
            anim.To = 0;
            anim.Completed += new EventHandler(opacityOutFinished);
            anim.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            anim.AccelerationRatio = .5;
            this.BeginAnimation(OpacityProperty, anim);
        }

        private void opacityOutFinished(object sender, EventArgs e)
        {
            DialogResult = true;
        }




        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            if (!Config.DEBUG) return;
            opacityOut();
        }

        private void btn_close_TouchDown(object sender, TouchEventArgs e)
        {
            opacityOut();
        }

       


       

        private void btn_capselock_Click(object sender, RoutedEventArgs e)
        {
            if (!Config.DEBUG) return;
            if (capselock == true)
            {
                capselock = false;
                btn_capselock.Foreground = Brushes.White;
            }
            else
            {
                capselock = true;
                btn_capselock.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#29B6F6"));
            }

        }

        private void btn_capselock_TouchDown(object sender, TouchEventArgs e)
        {
            
            if (capselock == true)
            {
                capselock = false;
                btn_capselock.Foreground = Brushes.White;
            }
            else
            {
                capselock = true;
                btn_capselock.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#29B6F6"));
            }
        }




        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!Config.DEBUG) return;
            if (input != null)
            {
                string str = input.Text;
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1);
                    input.Text = str;
                }
            }
            else
            {
                string str = input2.Password;
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1);
                    input2.Password = str;
                }
            }
        }

        private void btn_backspace_TouchDown(object sender, TouchEventArgs e)
        {
            if (input != null)
            {
                string str = input.Text;
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1);
                    input.Text = str;
                }
            }
            else
            {
                string str = input2.Password;
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 1);
                    input2.Password = str;
                }
            }
        }









        private void buttonClick(object sender, RoutedEventArgs e)
        {
            if (!Config.DEBUG) return;
            Button button = sender as Button;
            string tag = button.Tag.ToString();
            if (capselock == true)
            {
                tag = tag.ToUpper();
            }

            if (input != null)
            {
                input.Text += tag;
            }
            else
            {
                input2.Password += tag;
            }
        }

        private void btnTouchDown(object sender, TouchEventArgs e)
        {
            Button button = sender as Button;
            string tag = button.Tag.ToString();
            if (capselock == true)
            {
                tag = tag.ToUpper();
            }

            if (input != null)
            {
                input.Text += tag;
            }
            else
            {
                input2.Password += tag;
            }
        }

        

        

       



        



      
        
        



    }
}
