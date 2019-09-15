using Kiosk.model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiosk.control
{
    /// <summary>
    /// Interaction logic for ItemPrinter.xaml
    /// </summary>
    public partial class ItemPrinter : UserControl
    {
        public Printer printer;
        public ItemPrinter()
        {
            InitializeComponent();
        }

        public ItemPrinter(Printer p)
        {
            InitializeComponent();
            this.printer = p;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_name.Text = printer.name;
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            chk_printer.IsChecked = !chk_printer.IsChecked;
        }

        
    }
}
