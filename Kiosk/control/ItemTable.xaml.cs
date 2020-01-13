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
    /// Interaction logic for ItemTable.xaml
    /// </summary>
    public partial class ItemTable : UserControl
    {
        public int table_number;
        public ItemTable(int table)
        {
            InitializeComponent();

            this.table_number = table;
            txt_table.Text = "میز " + table;
        }
    }
}
