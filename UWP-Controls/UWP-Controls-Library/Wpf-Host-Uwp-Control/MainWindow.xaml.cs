using Microsoft.Toolkit.Wpf.UI.XamlHost;
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

namespace Wpf_Host_Uwp_Control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowsXamlHost_ChildChanged(object sender, EventArgs e)
        {
            WindowsXamlHost windowsXamlHost = (WindowsXamlHost)sender;

            Windows.UI.Xaml.Controls.Button button =
                windowsXamlHost.Child as Windows.UI.Xaml.Controls.Button;

            if (button != null)
            {
                button.Content = "My UWP button";
                button.Click += Button_Click;
            }

            UWP_Controls_Library.FunkyButton button2 =
                windowsXamlHost.Child as UWP_Controls_Library.FunkyButton;

            if (button2 != null)
            {
                button.Content = "My Funky button";
                button.Click += Button_Click;
            }

        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageBox.Show("My UWP button works");
        }
    }
}
