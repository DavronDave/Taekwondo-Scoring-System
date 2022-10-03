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

namespace TaekwondoScore.ListPages
{
    /// <summary>
    /// Interaction logic for WinRed.xaml
    /// </summary>
    public partial class WinRed : UserControl
    {
        public WinRed()
        {
            InitializeComponent();
        }

        private void previousBtn_Click(object sender, RoutedEventArgs e)
        { 
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
