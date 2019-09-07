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
    /// Interaction logic for ItemCategory.xaml
    /// </summary>
    public partial class ItemCategory : UserControl
    {

        public Category category;
        public ItemCategory()
        {
            InitializeComponent();
        }

        public ItemCategory(Category c)
        {
            InitializeComponent();
            
            this.category = c;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_category.Text = category.name;
            //BitmapImage b = new BitmapImage();
            //b.BeginInit();
            //b.UriSource = new Uri("B:\\programing\\C#\\Kiosk\\Kiosk\\img\\ic_pasta.jpg");
            //b.EndInit();
            img_category.Source = null;
            img_category.ImageUrl = category.image;
        }



    }
}
