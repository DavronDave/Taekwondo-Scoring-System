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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        MainWindow mainWindow = new MainWindow();       
        private void settingSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.StartStopBtn.Content = "START";
            Properties.Settings.Default.TimerStart = Int32.Parse(roundDurTxb.Text);
            Properties.Settings.Default.TimerStart1 = Int32.Parse(breakDurTxb.Text);
            Properties.Settings.Default.NumRound = Int32.Parse(numRoundTxb.Text);
            mainWindow.NumRound = Properties.Settings.Default.NumRound;
            mainWindow.matchTxb.Text = numRoundTxb.Text;
            this.Close();         
        }

        private void roundDurTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex InputChecker = new System.Text.RegularExpressions.Regex("[^0-9]+");
            e.Handled = InputChecker.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                roundDurTxb.Text = Properties.Settings.Default.TimerStart.ToString();
                breakDurTxb.Text = Properties.Settings.Default.TimerStart1.ToString();
                numRoundTxb.Text = Properties.Settings.Default.NumRound.ToString();
                helmetTxb.Text = Properties.Settings.Default.Helmet.ToString();
                protectionTxb.Text = Properties.Settings.Default.Protect.ToString();
                techniqueTxb.Text = Properties.Settings.Default.Fist.ToString();
                timeOutTxb.Text = Properties.Settings.Default.TimeOut.ToString();
                pointDifferTxb.Text = Properties.Settings.Default.PointDiffer.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Properties.Settings.Default.TimerStart = Convert.ToInt32(roundDurTxb.Text);
                Properties.Settings.Default.TimerStart1 = Convert.ToInt32(breakDurTxb.Text);
                Properties.Settings.Default.NumRound = Convert.ToInt32(numRoundTxb.Text);
                Properties.Settings.Default.Helmet = Convert.ToInt32(helmetTxb.Text);
                Properties.Settings.Default.Protect = Convert.ToInt32(protectionTxb.Text);
                Properties.Settings.Default.Fist = Convert.ToInt32(techniqueTxb.Text);
                Properties.Settings.Default.TimeOut = Convert.ToInt32(timeOutTxb.Text);
                Properties.Settings.Default.PointDiffer = Convert.ToInt32(pointDifferTxb.Text);
                Properties.Settings.Default.Save();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
