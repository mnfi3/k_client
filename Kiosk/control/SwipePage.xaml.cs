using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SwipePage.xaml
    /// </summary>
    public partial class SwipePage : UserControl
    {
        public SwipePage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            Task.Run(() => webview.Source = new Uri(String.Format("file:///{0}/zz.html", curDir)));
        }

        private void webview_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string script = "document.body.style.overflow ='hidden'";
            Task.Run(() => webview.InvokeScript("execScript", new Object[] { script, "JavaScript" }));
        }
    }
}
