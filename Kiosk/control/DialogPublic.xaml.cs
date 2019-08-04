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
    /// Interaction logic for DialogPublic.xaml
    /// </summary>
    public partial class DialogPublic : Window
    {
        public DialogPublic()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        public static void show(string text){
            DialogPublic d = new DialogPublic();
            d.txt_text.Text = text;
            d.ShowDialog();
        }

    }
}
