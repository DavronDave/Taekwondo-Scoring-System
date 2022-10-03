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



namespace TaekwondoScore.Windows
{
    /// <summary>
    /// Interaction logic for ChangeNameWindow.xaml
    /// </summary>
    public partial class ChangeNameWindow : Window
    {
        
        public ChangeNameWindow()
        {
            InitializeComponent();
        }

        MainWindow wnd = (MainWindow)Application.Current.MainWindow;
        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameBlueTxb.Text != "" && nameRedTxb.Text != "")
            {
                wnd.nameBlueTxt.Text = nameBlueTxb.Text.ToUpper();
                wnd.nameRedTxt.Text = nameRedTxb.Text.ToUpper();
            }
            else 
                MessageBox.Show("Iltimos ism to'ldirilsin!");
           
        }
    }
}
