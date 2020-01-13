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
    /// Interaction logic for DialogTableSelect.xaml
    /// </summary>
    public partial class DialogTableSelect : Window
    {

        private EventHandler handler;
        public DialogTableSelect(EventHandler table_select_handler)
        {
            InitializeComponent();

            handler += table_select_handler;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ItemTable _item;
            for (int i = 1; i <= G.restaurant.table_count; i++)
            {
                _item = new ItemTable(i);
                lst_table.Items.Add(_item);
            }
        }

       
        private void lst_table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem == null) return;
            ItemTable _item = (ItemTable)(sender as ListView).SelectedItem;
            this.Close();
            handler(_item.table_number, new EventArgs());
            lst_table.SelectedItem = null;
        }

        
    }
}
