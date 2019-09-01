using Kiosk.control;
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

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for fortest.xaml
    /// </summary>
    public partial class fortest : Window
    {
        public fortest()
        {
            InitializeComponent();
        }
        private async void loadTexts()
        {
            TempItemTest item;
            for (int i = 0; i < 100; i++)
            {
                item = new TempItemTest();
                lstTexts.Items.Add(item);
                await Task.Delay(200);
                //TempItemText item3 = (TempItemText)lstTexts.Items[lstTexts.Items.Count - 1];

            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    lstTexts.Items.Add(new TempItemTest());
            //    await Task.Delay(200);
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadTexts();
        }
    }
}
