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
using System.Windows.Shapes;
using System.Drawing.Printing;
using Kiosk.control;
using Kiosk.db_lite;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for RestaurantDetails.xaml
    /// </summary>
    public partial class RestaurantDetails : Window
    {
        public Restaurant restaurant;
        List<Printer> printers = new List<Printer>();
        public RestaurantDetails()
        {
            InitializeComponent();
        }

        public RestaurantDetails(Restaurant res)
        {
            InitializeComponent();
            this.restaurant = res;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_restaurant.Text = restaurant.name;
            Task.Run(() =>
            {
                
                this.Dispatcher.Invoke((Action)(() =>
                {
                    getAllPrinters();
                    renderPrinters();
                }));
            });
            
        }



        private void getAllPrinters()
        {
            Printer printer;
            foreach (string p in PrinterSettings.InstalledPrinters)
            {
                printer = new Printer();
                printer.name = p;
                printers.Add(printer);
            }
        }

        private void renderPrinters()
        {
            ItemPrinter _item;
            foreach (Printer p in printers)
            {
                _item = new ItemPrinter(p);
                lst_printers.Items.Add(_item);

                foreach (Printer p1 in restaurant.printers)
                {
                    if (p.name == p1.name)
                    {
                        _item.chk_printer.IsChecked = true;
                        break;
                    }
                }
            }

           
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            List<Printer> selected_printers = new List<Printer>();
            foreach(ItemPrinter _item in lst_printers.Items)
            {
                if (_item.chk_printer.IsChecked == true)
                {
                    selected_printers.Add(_item.printer);
                }
            }

            DBRestaurant db_rest = new DBRestaurant();
            db_rest.savePrinters(restaurant, selected_printers);
            MessageBox.Show("اطلاعات ذخیره شد");
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            RegisterRestaurant _window = new RegisterRestaurant();
            _window.Show();
            this.Close();
        }

       
    }
}
