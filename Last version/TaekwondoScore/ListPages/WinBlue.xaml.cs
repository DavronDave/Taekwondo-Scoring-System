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
using TaekwondoScore;

namespace TaekwondoScore.ListPages
{
    /// <summary>
    /// Interaction logic for WinBlue.xaml
    /// </summary>
    public partial class WinBlue : UserControl
    {
        public WinBlue()
        {
            InitializeComponent();
        }        
        private void previousBtn_Click(object sender, RoutedEventArgs e)
        {           
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
