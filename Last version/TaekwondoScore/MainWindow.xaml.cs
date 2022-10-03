using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using TaekwondoScore.ListPages;
using TaekwondoScore.Windows;

namespace TaekwondoScore
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timeout = new DispatcherTimer();
        DispatcherTimer timeout1 = new DispatcherTimer();
        public int start;
        private int start1;
        public int NumRound, l2, l1 = 1, r1 = 0, r2 = 0;
        private int change = 0;
        private int CheckPosition = 0;
        private bool ButtonStateCheck = false;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;

            timer1 = new DispatcherTimer();
            timer1.Interval = new TimeSpan(0, 0, 1);
            timer1.Tick += Timer1_Tick;

            timeout = new DispatcherTimer();
            timeout.Interval = new TimeSpan(0, 0, 1);
            timeout.Tick += Timeout_Tick;

            timeout1 = new DispatcherTimer();
            timeout1.Interval = new TimeSpan(0, 0, 1);
            timeout1.Tick += Timeout1_Tick;
        }

        private void Timeout1_Tick(object sender, EventArgs e)
        {          
            int m, s;
            m = time_out / 60;
            s = time_out % 60;
            if (time_out >= 0)
            {
                time_out--;
                //StartStopBtn.Foreground = new SolidColorBrush(Colors.Blue);
               // breakTimeLbl.Foreground = new SolidColorBrush(Colors.Blue);
                StartStopBtn.Content = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                breakTimeLbl.Content = "Time out";
            }
            else
            {
                if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    
                    //StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
                    WinBlue();
                    AllClear();
                    r1 = 0;
                    r2 = 0;
                    RoundWinBluelbl.Content = "";
                    RoundWinRedlbl.Content = "";
                    timeout1.Stop();
                    NumRound++;
                    change++;
                    l1 = 1;
                    round1Txb.Text = l1.ToString();
                    matchTxb.Text = NumRound.ToString();
                    breakTimeLbl.Content = "Time";
                }
                else
                {
                    AllClear();
                    timeout1.Stop();
                    //StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
                    breakTimeLbl.Content = "Time";
                }
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Content = "START";
            }                        
        }

        private void Timeout_Tick(object sender, EventArgs e)
        {
            int m, s;
            m = time_out / 60;
            s = time_out % 60;
            if (time_out >= 0)
            {
                //StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
               // breakTimeLbl.Foreground = new SolidColorBrush(Colors.Red);
                time_out--;
                StartStopBtn.Content = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                breakTimeLbl.Content = "Time out";
            }
            else
            {
                if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    WinRed();
                    AllClear();
                    r1 = 0;
                    r2 = 0;
                    RoundWinBluelbl.Content = "";
                    RoundWinRedlbl.Content = "";
                    timeout.Stop();
                    NumRound++;
                    change++;
                    l1 = 1;
                    round1Txb.Text = l1.ToString();
                    matchTxb.Text = NumRound.ToString();
                    breakTimeLbl.Content = "Time";
                }
                else
                {
                    AllClear();                   
                    timeout.Stop();
                    breakTimeLbl.Content = "Time";
                }
                StartStopBtn.Content = "START";
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
            }

            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (start1 > 0)
            {
                ButtonFalse();
                timeOutBlueBtn.IsEnabled = true;
                timeOutRedBtn.IsEnabled = true;
                StartStopBtn.IsEnabled = false;
                start1--;
                int m, s;
                m = start1 / 60;
                s = start1 % 60;
                StartStopBtn.Background = new SolidColorBrush(Colors.Black);
                StartStopBtn.Foreground = new SolidColorBrush(Colors.White);
                timeBorder.Background = new SolidColorBrush(Colors.Black);
                breakTimeLbl.Foreground = new SolidColorBrush(Colors.White);
                if (start1 <= 3)
                {
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnding);
                    player.Play();
                }
                breakTimeLbl.Content = "Break Time";
                StartStopBtn.Content = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }
            else if (start1 <= 0)
            {               
                SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                player.Play();
                timeOutBlueBtn.IsEnabled = true;
                timeOutRedBtn.IsEnabled = true;
                ButtonFalse();
                StartStopBtn.IsEnabled = true;
                timer1.Stop();
                ButtonOpenMenu.IsEnabled = true;
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                breakTimeLbl.Foreground = new SolidColorBrush(Colors.Red);
                breakTimeLbl.Content = "Time";
                start = Properties.Settings.Default.TimerStart;
                int m, s;
                m = start / 60;
                s = start % 60;

                StartStopBtn.Content = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                //if (Convert.ToInt16(tabloBlueLbl.Content) > Convert.ToInt16(tabloRedLbl.Content))
                //{
                //    if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                //    {
                //        RoundWinBluelbl.Content = 1.ToString();
                //    }
                    AllClear();
                //}
                // else
                //{
                //    WinRed();
                //    AllClear();
                //}

                //timer.Start();

                l1++;
                round1Txb.Text = l1.ToString();
                
                //NumRound++;
                //if (l1 >= l2 + 1)
                //{
                //    timer.Stop();
                //    ButtonOpenMenu.IsEnabled = true;
                //    ButtonFalse();
                //    NumRound++;
                //}

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (start > 0)
            {
                breakTimeLbl.Content = "Time";
                l2 = 300 / 100;
                start--;
                int m, s;
                m = start / 60;
                s = start % 60;
                if (start <= 3)
                {
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnding);
                    player.Play();
                }
                StartStopBtn.Content = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                round1Txb.Text = l1.ToString();
                round2Txb.Text = l2.ToString();
                matchTxb.Text = NumRound.ToString();
                timeOutBlueBtn.IsEnabled = false;
                timeOutRedBtn.IsEnabled = false;
            }
            else if (start <= 0)
            {
                timer.Stop();
                ButtonFalse();
                ButtonOpenMenu.IsEnabled = true;
                CheckPosition = 0;
                ButtonStateCheck = false;
                timeOutBlueBtn.IsEnabled = true;
                timeOutRedBtn.IsEnabled = true;
                if (Convert.ToInt16(tabloBlueLbl.Content) == Convert.ToInt16(tabloRedLbl.Content))
                {
                    if (MessageBox.Show("Do you want to change?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (l2 >= l1)
                        {
                            //RoundWinBluelbl.Content += "W";
                            ////AllClear();
                            //start1 = Properties.Settings.Default.TimerStart1;
                            //timer1.Start();

                            //r1++;
                        }
                    }
                }

                if (Convert.ToInt16(tabloBlueLbl.Content) > Convert.ToInt16(tabloRedLbl.Content))
                {
                    if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (l2 >= l1)
                        {
                            RoundWinBluelbl.Content += "W";
                            //AllClear();
                            start1 = Properties.Settings.Default.TimerStart1;
                            timer1.Start();
                            SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                            player.Play();
                            r1++;                            
                        }                                    
                    }                    
                    else 
                    {
                        ButtonOpenMenu.IsEnabled = true;
                    }
                }
                else if(Convert.ToInt16(tabloRedLbl.Content)>Convert.ToInt16(tabloBlueLbl.Content))
                {
                    if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (l2 >= l1)
                        {
                            RoundWinRedlbl.Content += "W";
                            //AllClear();
                            start1 = Properties.Settings.Default.TimerStart1;
                            timer1.Start();
                            SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                            player.Play();
                            r2++;
                        }
                        
                    }
                    else
                    {
                        ButtonOpenMenu.IsEnabled = true;
                    }
                }

                if (r1 - r2 == 2 || (r1 - r2 == 1 && r2 == 1))
                {
                    WinBlue();                   
                    NumRound++;
                    matchTxb.Text = NumRound.ToString();
                    l1 = 1;
                    round1Txb.Text = l1.ToString();
                    r1 = 0;
                    RoundWinBluelbl.Content = "";
                    RoundWinRedlbl.Content = "";
                    timer1.Stop();
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                    player.Play();
                    AllClear();
                    change++;
                    StartStopBtn.Content = "START";

                }
                if (r2 - r1 == 2 || (r2 - r1 == 1 && r1 == 1))
                {
                    WinRed();
                    NumRound++;
                    matchTxb.Text = NumRound.ToString();
                    l1 = 1;
                    round1Txb.Text = l1.ToString();
                    r2 = 0;
                    RoundWinBluelbl.Content = "";
                    RoundWinRedlbl.Content = "";
                    timer1.Stop();
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                    player.Play();
                    AllClear();
                    change++;
                    StartStopBtn.Content = "START";
                    timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                    StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                }
            }
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {           
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            MenuGrid.Visibility = Visibility.Visible;
            GridMenu.Background = new SolidColorBrush(Colors.White);
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            MenuGrid.Visibility = Visibility.Collapsed;
            GridMenu.Background = new SolidColorBrush(Colors.Green);
        }

        public void WinBlue()
        {

            r1 = 0;
            r2 = 0;
            MainGrid.Children.Clear();
            WinBlue winBlue = new WinBlue();
            MainGrid.Children.Add(winBlue);
            SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
            player.Play();
            winBlue.winNameBluelbl.Content = nameBlueTxt.Text;
        }
        public void WinRed()
        {
            r1 = 0;
            r2 = 0;
            MainGrid.Children.Clear();
            WinRed winRed = new WinRed();
            MainGrid.Children.Add(winRed);
            SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
            player.Play();
            winRed.winNameRedlbl.Content = nameRedTxt.Text;
        }

        WinBlue winBlue = new WinBlue();
       
        private void WinBlueBtn_Click(object sender, RoutedEventArgs e)
        {            

            if (MessageBox.Show("Do you confirm your decision? ", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (r1 ==1)
                {
                    ButtonOpenMenu.IsEnabled = true;
                    CheckPosition = 0;
                    ButtonStateCheck = false;
                    WinBlue();
                    //ButtonCloseMenu_Click(sender, e);
                    ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                   
                    AllClear();
                    RoundWinBluelbl.Content = "";
                    RoundWinRedlbl.Content = "";
                   // ButtonOpenMenu_Click(sender, e);
                    r1 = 0;
                    r2 = 0;
                    l1 = 1;
                    round1Txb.Text = l1.ToString();
                    NumRound++;
                    matchTxb.Text = NumRound.ToString();
                    timer1.Stop();
                  
                    change++;
                    StartStopBtn.Content = "START";
                    breakTimeLbl.Content = "Time";
                    timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                    StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                    breakTimeLbl.Foreground = new SolidColorBrush(Colors.Red);
                    StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    ButtonOpenMenu.IsEnabled = true;
                    CheckPosition = 0;
                    ButtonStateCheck = false;
                    RoundWinBluelbl.Content += "W";
                    start1 = Properties.Settings.Default.TimerStart1;
                    timer1.Start();
                    //timer.Stop(); // winnerdagi time xatoligi
                    change++;
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                    player.Play();

                    r1++;
                }
                
            }
            else
            {
                ButtonOpenMenu.IsEnabled = true;
            }
        }        
        public void AllClear()
        {
            counter = 0;
            count = 0;
            a = 0;
            b = 0;
            //round1Txb.Text = 1.ToString();
            tabloBlueLbl.Content = counter;
            tabloRedLbl.Content = count;
            blueGamlbl.Content = a;
            redGamlbl.Content = b;           
        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            AllClear();
            timeOutBlueBtn.IsEnabled = true;
            timeOutRedBtn.IsEnabled = true;
            StartStopBtn.Content = "START";
            timeBorder.Background = new SolidColorBrush(Colors.Yellow);
            StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
            //timer.Start();
            ButtonOpenMenu.IsEnabled = true;
            CheckPosition = 0;
            ButtonStateCheck = false;
        }

        private void NameLogoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            ChangeNameWindow changeNameWindow = new ChangeNameWindow();
            this.Opacity = 0.2;
            bool result = (bool)changeNameWindow.ShowDialog();
            if (true)
            {
                this.Opacity = 1;
            }
        }
        
        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            StartStopBtn.Content = "START";
            timeBorder.Background = new SolidColorBrush(Colors.Yellow);
            StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
            ButtonOpenMenu.IsEnabled = true;
            CheckPosition = 0;
            ButtonStateCheck = false;
            MainGrid.Children.Clear();
            settingsWindow = new SettingsWindow();
            this.Opacity = 0.2;
            bool result = (bool)settingsWindow.ShowDialog();
            if (true)
            {
                this.Opacity = 1;
            }
        }
        WinRed winRed = new WinRed();
        private void WinRedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you confirm your decision? ", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (r2 == 1)
                {
                    ButtonOpenMenu.IsEnabled = true;
                    CheckPosition = 0;
                    ButtonStateCheck = false;
                    WinRed();
                    ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    AllClear();
                    RoundWinBluelbl.Content = "";
                    RoundWinRedlbl.Content = "";
                    r2 = 0;
                    r1 = 0;
                    l1 = 1;
                    round1Txb.Text = l1.ToString();
                    NumRound++;
                    matchTxb.Text = NumRound.ToString();
                    timer1.Stop();
                    change++;
                    StartStopBtn.Content = "START";
                    breakTimeLbl.Content = "Time";
                    timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                    StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                    breakTimeLbl.Foreground = new SolidColorBrush(Colors.Red);
                    StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    ButtonOpenMenu.IsEnabled = true;
                    CheckPosition = 0;
                    ButtonStateCheck = false;
                    RoundWinRedlbl.Content += "W";
                    start1 = Properties.Settings.Default.TimerStart1;
                    timer1.Start();
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                    player.Play();
                    r2++;
                }

            }
            else
            {
                ButtonOpenMenu.IsEnabled = true;
            }
        }
        int counter;
        private void tabloBluePlusBtn_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            tabloBlueLbl.Content = counter;            
        }
       
        private void tabloBlueMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(tabloBlueLbl.Content)>0)
            {
                --counter;
                tabloBlueLbl.Content = counter;
            }            
        }
        int count = 0;
        private void tabloRedPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            count++;
            tabloRedLbl.Content = count;
        }

        private void tabloRedMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tabloRedLbl.Content) > 0)
            {
                --count;
                tabloRedLbl.Content = count;
            }
        }
        int a = 0;
        private void plusBtn_Click(object sender, RoutedEventArgs e)
        {
            count++;            
            a++;
            tabloRedLbl.Content = count;
            blueGamlbl.Content = a;
            if (Convert.ToInt32(blueGamlbl.Content)==5)
            {
                if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (r2 == 1)
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        WinRed();

                        AllClear();
                        ButtonFalse();
                        RoundWinBluelbl.Content = "";
                        RoundWinRedlbl.Content = "";
                        r2 = 0;
                        l1 = 1;

                        round1Txb.Text = l1.ToString();
                        NumRound++;
                        matchTxb.Text = NumRound.ToString();
                        timer1.Stop();
                        timer.Stop();
                        change++;
                        StartStopBtn.Content = "START";
                        timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                        StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                    }
                    else
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        RoundWinRedlbl.Content += "W";
                        timer.Stop();
                        start1 = Properties.Settings.Default.TimerStart1;
                        timer1.Start();
                        change++;
                        r2++;
                    }
                }
            }
        }

        private void minusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tabloRedLbl.Content) > 0 && Convert.ToInt32(blueGamlbl.Content)>0)
            {
                --count;
                --a;
                tabloRedLbl.Content = count;
                blueGamlbl.Content = a;
            }
        }
        int b;
        private void redPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            b++;
            tabloBlueLbl.Content = counter;
            redGamlbl.Content = b;
           
            if (Convert.ToInt32(redGamlbl.Content) == 5)
            {
                if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (r1 == 1)
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        WinBlue();
                        AllClear();
                        ButtonFalse();
                        RoundWinBluelbl.Content = "";
                        RoundWinRedlbl.Content = "";
                        r1 = 0;
                        l1 = 1;

                        round1Txb.Text = l1.ToString();
                        NumRound++;
                        matchTxb.Text = NumRound.ToString();
                        timer1.Stop();
                        timer.Stop();
                        change++;
                        StartStopBtn.Content = "START";
                        timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                        StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                    }
                    else
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        RoundWinBluelbl.Content += "W";
                        timer.Stop();
                        start1 = Properties.Settings.Default.TimerStart1;
                        timer1.Start();
                        change++;
                        r1++;
                    }
                }
            }
        }

        private void redMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tabloBlueLbl.Content) > 0 && Convert.ToInt32(redGamlbl.Content)>0)
            {
                --counter;
                --b;
                tabloBlueLbl.Content = counter;
                redGamlbl.Content = b;
            }
        }

        SettingsWindow settingsWindow;
        int i;
        static Stopwatch sw = new Stopwatch();
        static Stopwatch sw1 = new Stopwatch();
        static Stopwatch sw2 = new Stopwatch();
        static Stopwatch sw3 = new Stopwatch();
        static Stopwatch sw4 = new Stopwatch();
        static Stopwatch sw5 = new Stopwatch();
        public async void BlueHead()
        {
            if (this.settingsWindow != null) // check if window is initialized
            {
                if (sw.IsRunning)
                {
                    sw.Stop();

                    TimeSpan ts = sw.Elapsed;

                    string elapsedTime = String.Format("{0:0}", ts.Seconds);
                    if (Convert.ToInt16(elapsedTime) <= 1)
                    {
                        i = Properties.Settings.Default.Helmet;
                        counter += i;
                        tabloBlueLbl.Content = counter.ToString();
                    }
                }
                else
                {
                    sw = new Stopwatch();
                    sw.Start();
                    await Task.Delay(1000);
                    sw.Stop();
                }                
            }
        }

        public async void BlueProtect()
        {
            if (this.settingsWindow != null) // check if window is initialized
            {
                
                if (sw1.IsRunning)
                {
                    sw1.Stop();

                    TimeSpan ts = sw1.Elapsed;

                    string elapsedTime = String.Format("{0:0}", ts.Seconds);
                    if (Convert.ToInt16(elapsedTime) <= 1)
                    {
                        i = Properties.Settings.Default.Protect;
                        counter += i;
                        tabloBlueLbl.Content = counter.ToString();
                    }
                }
                else
                {
                    sw1 = new Stopwatch();
                    sw1.Start();
                    await Task.Delay(1000);
                    sw1.Stop();
                }
            }
        }

        public async void BlueFist()
        {
            if (this.settingsWindow != null) // check if window is initialized
            {
              
                if (sw2.IsRunning)
                {
                    sw2.Stop();

                    TimeSpan ts = sw2.Elapsed;

                    string elapsedTime = String.Format("{0:0}", ts.Seconds);
                    if (Convert.ToInt16(elapsedTime) <= 1)
                    {
                        i = Properties.Settings.Default.Fist;
                        counter += i;
                        tabloBlueLbl.Content = counter.ToString();
                    }
                }
                else
                {
                    sw2 = new Stopwatch();
                    sw2.Start();
                    await Task.Delay(1000);
                    sw2.Stop();
                }
            }
        }
        int Point;
        public void WinBluePoint()
        {
            Point = Properties.Settings.Default.PointDiffer;
            if ((Convert.ToInt32(tabloBlueLbl.Content) - Convert.ToInt32(tabloRedLbl.Content)) >= Point)
            {
                if (MessageBox.Show("Do you confirm your decision? ", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (r1 == 1)
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        WinBlue();
                        AllClear();
                        ButtonFalse();
                        RoundWinBluelbl.Content = "";
                        RoundWinRedlbl.Content = "";
                        r1 = 0;
                        l1 = 1;
                       
                        round1Txb.Text = l1.ToString();
                        NumRound++;
                        matchTxb.Text = NumRound.ToString();
                        timer1.Stop();
                        timer.Stop();
                        change++;
                        StartStopBtn.Content = "START";
                        timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                        StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                    }
                    else
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        RoundWinBluelbl.Content += "W";
                        timer.Stop();
                       
                        start1 = Properties.Settings.Default.TimerStart1;
                        timer1.Start();
                        change++;
                        r1++;
                    }

                }
                else
                {
                    ButtonOpenMenu.IsEnabled = true;
                }
                //WinBlue();
                //AllClear();
                //start = Properties.Settings.Default.TimerStart;
                //int m, s;
                //m = start / 60;
                //s = start % 60;

                //StartStopBtn.Content = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

            }
        }
        public void WinRedPoint()
        {
            Point = Properties.Settings.Default.PointDiffer;
            if ((Convert.ToInt32(tabloRedLbl.Content) - Convert.ToInt32(tabloBlueLbl.Content)) >= Point)
            {
                if (MessageBox.Show("Do you confirm your decision? 2", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (r2 == 1)
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        WinRed();
                        AllClear();
                        ButtonFalse();
                        RoundWinBluelbl.Content = "";
                        RoundWinRedlbl.Content = "";
                        r2 = 0;
                        l1 = 1;

                        round1Txb.Text = l1.ToString();
                        NumRound++;
                        matchTxb.Text = NumRound.ToString();
                        timer1.Stop();
                        timer.Stop();
                        change++;
                        StartStopBtn.Content = "START";
                        timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                        StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                    }
                    else
                    {
                        ButtonOpenMenu.IsEnabled = true;
                        CheckPosition = 0;
                        ButtonStateCheck = false;
                        RoundWinRedlbl.Content += "W";
                        timer.Stop();
                        start1 = Properties.Settings.Default.TimerStart1;
                        timer1.Start();
                        change++;
                        r2++;
                    }

                }
                else
                {
                    ButtonOpenMenu.IsEnabled = true;
                }
            }
        }
        public async void RedHead()
        {
            if (this.settingsWindow != null) // check if window is initialized
            {
              
                if (sw3.IsRunning)
                {
                    sw3.Stop();

                    TimeSpan ts = sw3.Elapsed;

                    string elapsedTime = String.Format("{0:0}", ts.Seconds);
                    if (Convert.ToInt16(elapsedTime) <= 1)
                    {
                        i = Properties.Settings.Default.Helmet;
                        count += i;
                        tabloRedLbl.Content = count.ToString();
                    }
                }
                else
                {
                    sw3 = new Stopwatch();
                    sw3.Start();
                    await Task.Delay(1000);
                    sw3.Stop();
                }
            }
        }
        public async void RedProtect()
        {
            if (this.settingsWindow != null) // check if window is initialized
            {
                
                if (sw4.IsRunning)
                {
                    sw4.Stop();

                    TimeSpan ts = sw4.Elapsed;

                    string elapsedTime = String.Format("{0:0}", ts.Seconds);
                    if (Convert.ToInt16(elapsedTime) <= 1)
                    {
                        i = Properties.Settings.Default.Protect;
                        count += i;
                        tabloRedLbl.Content = count.ToString();
                    }
                }
                else
                {
                    sw4 = new Stopwatch();
                    sw4.Start();
                    await Task.Delay(1000);
                    sw4.Stop();
                }
            }
        }
        public async void RedFist()
        {
            if (this.settingsWindow != null) // check if window is initialized
            {
               
                if (sw5.IsRunning)
                {
                    sw5.Stop();

                    TimeSpan ts = sw5.Elapsed;

                    string elapsedTime = String.Format("{0:0}", ts.Seconds);
                    if (Convert.ToInt16(elapsedTime) <= 1)
                    {
                        i = Properties.Settings.Default.Fist;
                        count += i;
                        tabloRedLbl.Content = count.ToString();
                    }
                }
                else
                {
                    sw5 = new Stopwatch();
                    sw5.Start();
                    await Task.Delay(1000);
                    sw5.Stop();
                }
            }
        }
        private async void blueHeadTopBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueHead();
            WinBluePoint();
            blueHeadTopBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueHeadTopBtn.IsEnabled = true;
        }

        private async void blueHeadLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueHead();
            WinBluePoint();
            blueHeadLeftBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueHeadLeftBtn.IsEnabled = true;
        }

        private async void blueHeadRightBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueHead();
            WinBluePoint();
            blueHeadRightBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueHeadRightBtn.IsEnabled = true;
        }

        private async void blueProtectTopBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueProtect();
            WinBluePoint();
            blueProtectTopBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueProtectTopBtn.IsEnabled = true;
        }

        private async void blueProtectLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueProtect();
            WinBluePoint();
            blueProtectLeftBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueProtectLeftBtn.IsEnabled = true;
        }

        private async void blueProtectRightBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueProtect();
            WinBluePoint();
            blueProtectRightBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueProtectRightBtn.IsEnabled = true;

        }

        private async void blueFistLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueFist();
            WinBluePoint();
            blueFistLeftBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueFistLeftBtn.IsEnabled = true;
        }

        private async void blueFistMiddBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueFist();
            WinBluePoint();
            blueFistMiddBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueFistMiddBtn.IsEnabled = true;
        }

        private async void blueRightBtn_Click(object sender, RoutedEventArgs e)
        {
            BlueFist();
            WinBluePoint();
            blueRightBtn.IsEnabled = false;
            await Task.Delay(1000);
            blueRightBtn.IsEnabled = true;
        }

        private async void redHeadTopBtn_Click(object sender, RoutedEventArgs e)
        {
            RedHead();
            WinRedPoint();
            redHeadTopBtn.IsEnabled = false;
            await Task.Delay(1000);
            redHeadTopBtn.IsEnabled = true;
        }

        private async void redHeadLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            RedHead();
            WinRedPoint();
            redHeadLeftBtn.IsEnabled = false;
            await Task.Delay(1000);
            redHeadLeftBtn.IsEnabled = true;
        }

        private async void redHeadRightBtn_Click(object sender, RoutedEventArgs e)
        {
            RedHead();
            WinRedPoint();
            redHeadRightBtn.IsEnabled = false;
            await Task.Delay(1000);
            redHeadRightBtn.IsEnabled = true;
        }

        private async void redProtectTopBtn_Click(object sender, RoutedEventArgs e)
        {
            RedProtect();
            WinRedPoint();
            redProtectTopBtn.IsEnabled = false;
            await Task.Delay(1000);
            redProtectTopBtn.IsEnabled = true;
        }

        private async void redProtectLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            RedProtect();
            WinRedPoint();
            redProtectLeftBtn.IsEnabled = false;
            await Task.Delay(1000);
            redProtectLeftBtn.IsEnabled = true;
        }

        private async void redProtectRightBtn_Click(object sender, RoutedEventArgs e)
        {
            RedProtect();
            WinRedPoint();
            redProtectRightBtn.IsEnabled = false;
            await Task.Delay(1000);
            redProtectRightBtn.IsEnabled = true;
        }

        private async void redFistLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            RedFist();
            WinRedPoint();
            redFistLeftBtn.IsEnabled = false;
            await Task.Delay(1000);
            redFistLeftBtn.IsEnabled = true;
        }

        private async void redFistMiddBtn_Click(object sender, RoutedEventArgs e)
        {
            RedFist();
            WinRedPoint();
            redFistMiddBtn.IsEnabled = false;
            await Task.Delay(1000);
            redFistMiddBtn.IsEnabled = true;
        }
        public void Load()
        {
            start = Properties.Settings.Default.TimerStart;
            int m, s;
            m = start / 60;
            s = start % 60;

            StartStopBtn.Content = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartStopBtn.Content = "START";
            ButtonFalse();

            settingsWindow = new SettingsWindow();
            try
            {
                settingsWindow.roundDurTxb.Text = Properties.Settings.Default.TimerStart.ToString();
                settingsWindow.breakDurTxb.Text = Properties.Settings.Default.TimerStart1.ToString();
                settingsWindow.numRoundTxb.Text = Properties.Settings.Default.NumRound.ToString();
                settingsWindow.helmetTxb.Text = Properties.Settings.Default.Helmet.ToString();
                settingsWindow.protectionTxb.Text = Properties.Settings.Default.Protect.ToString();
                settingsWindow.techniqueTxb.Text = Properties.Settings.Default.Fist.ToString();
                settingsWindow.timeOutTxb.Text = Properties.Settings.Default.TimeOut.ToString();
                settingsWindow.pointDifferTxb.Text = Properties.Settings.Default.PointDiffer.ToString();
                NumRound = Properties.Settings.Default.NumRound;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //try
            //{
            //    Properties.Settings.Default.TimerStart = Convert.ToInt32(settingsWindow.roundDurTxb.Text);
            //    Properties.Settings.Default.TimerStart1 = Convert.ToInt32(settingsWindow.breakDurTxb.Text);
            //    Properties.Settings.Default.NumRound = Convert.ToInt32(settingsWindow.numRoundTxb.Text);
            //    Properties.Settings.Default.Helmet = Convert.ToInt32(settingsWindow.helmetTxb.Text);
            //    Properties.Settings.Default.Protect = Convert.ToInt32(settingsWindow.protectionTxb.Text);
            //    Properties.Settings.Default.Fist = Convert.ToInt32(settingsWindow.techniqueTxb.Text);
            //    Properties.Settings.Default.TimeOut = Convert.ToInt32(settingsWindow.timeOutTxb.Text);
            //    Properties.Settings.Default.PointDiffer = Convert.ToInt32(settingsWindow.pointDifferTxb.Text);
            //    Properties.Settings.Default.Save();
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error");
            //}
        }

        private void Window_Closed(object sender, EventArgs e)
        {           
            Application.Current.Shutdown();
        }

        int time_out;

        private void timeOutBlueBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (this.settingsWindow != null) // check if window is initialized
            {
                time_out = Properties.Settings.Default.TimeOut;            
                timeout.Start();
                timer1.Stop();
                breakTimeLbl.Content = "Time out";
                breakTimeLbl.Foreground = new SolidColorBrush(Colors.Red);
                StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
            }
        }

        private void timeOutRedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.settingsWindow != null) // check if window is initialized
            {
                time_out = Properties.Settings.Default.TimeOut;                
                timeout1.Start();
                timer1.Stop();
                breakTimeLbl.Content = "Time out";
                breakTimeLbl.Foreground = new SolidColorBrush(Colors.Red);
                StartStopBtn.Foreground = new SolidColorBrush(Colors.Red);
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
            }
        }

        private async void redFistRightBtn_Click(object sender, RoutedEventArgs e)
        {
            
            RedFist();
            WinRedPoint();
            redFistRightBtn.IsEnabled = false;
            await Task.Delay(1000);
            redFistRightBtn.IsEnabled = true;
        }
        public void ButtonFalse()
        {
            blueHeadTopBtn.IsEnabled = false;
            blueHeadLeftBtn.IsEnabled = false;
            blueHeadRightBtn.IsEnabled = false;
            blueProtectTopBtn.IsEnabled = false;
            blueProtectLeftBtn.IsEnabled = false;
            blueProtectRightBtn.IsEnabled = false;
            blueFistLeftBtn.IsEnabled = false;
            blueFistMiddBtn.IsEnabled = false;
            blueRightBtn.IsEnabled = false;

            redHeadTopBtn.IsEnabled = false;
            redHeadLeftBtn.IsEnabled = false;
            redHeadRightBtn.IsEnabled = false;
            redProtectTopBtn.IsEnabled = false;
            redProtectLeftBtn.IsEnabled = false;
            redProtectRightBtn.IsEnabled = false;
            redFistLeftBtn.IsEnabled = false;
            redFistMiddBtn.IsEnabled = false;
            redFistRightBtn.IsEnabled = false;
        }

        private void blueHeadTopBtn_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private async void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                count++;
                a++;
                tabloRedLbl.Content = count;
                blueGamlbl.Content = a;
                if (Convert.ToInt32(blueGamlbl.Content) == 5)
                {
                    if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (r2 == 1)
                        {
                            ButtonOpenMenu.IsEnabled = true;
                            CheckPosition = 0;
                            ButtonStateCheck = false;
                            WinRed();
                            AllClear();
                            ButtonFalse();
                            RoundWinBluelbl.Content = "";
                            RoundWinRedlbl.Content = "";
                            r2 = 0;
                            l1 = 1;

                            round1Txb.Text = l1.ToString();
                            NumRound++;
                            matchTxb.Text = NumRound.ToString();
                            timer1.Stop();
                            timer.Stop();
                            change++;
                            StartStopBtn.Content = "START";
                        }
                        else
                        {
                            ButtonOpenMenu.IsEnabled = true;
                            CheckPosition = 0;
                            ButtonStateCheck = false;
                            RoundWinRedlbl.Content += "W";
                            timer.Stop();
                            start1 = Properties.Settings.Default.TimerStart1;
                            timer1.Start();
                            change++;
                            r2++;
                        }
                    }
                }
            }
            if (e.Key == Key.D)
            {
                if (Convert.ToInt32(tabloRedLbl.Content) > 0 && Convert.ToInt32(blueGamlbl.Content) > 0)
                {
                    --count;
                    --a;
                    tabloRedLbl.Content = count;
                    blueGamlbl.Content = a;
                }
            }
            if (e.Key == Key.L)
            {
                counter++;
                b++;
                tabloBlueLbl.Content = counter;
                redGamlbl.Content = b;

                if (Convert.ToInt32(redGamlbl.Content) == 5)
                {
                    if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (r1 == 1)
                        {
                            ButtonOpenMenu.IsEnabled = true;
                            CheckPosition = 0;
                            ButtonStateCheck = false;
                            WinBlue();
                            AllClear();
                            ButtonFalse();
                            RoundWinBluelbl.Content = "";
                            RoundWinRedlbl.Content = "";
                            r1 = 0;
                            l1 = 1;

                            round1Txb.Text = l1.ToString();
                            NumRound++;
                            matchTxb.Text = NumRound.ToString();
                            timer1.Stop();
                            timer.Stop();
                            change++;
                            StartStopBtn.Content = "START";
                        }
                        else
                        {
                            ButtonOpenMenu.IsEnabled = true;
                            CheckPosition = 0;
                            ButtonStateCheck = false;
                            RoundWinBluelbl.Content += "W";
                            timer.Stop();
                            start1 = Properties.Settings.Default.TimerStart1;
                            timer1.Start();
                            change++;
                            r1++;
                        }
                    }
                }
            }
            if (e.Key == Key.J)
            {
                if (Convert.ToInt32(tabloBlueLbl.Content) > 0 && Convert.ToInt32(redGamlbl.Content) > 0)
                {
                    --counter;
                    --b;
                    tabloBlueLbl.Content = counter;
                    redGamlbl.Content = b;
                }
            }
            if (e.Key == Key.W)
            {
                counter++;
                tabloBlueLbl.Content = counter;
            }
            if (e.Key == Key.S)
            {
                if (Convert.ToInt32(tabloBlueLbl.Content) > 0)
                {
                    --counter;
                    tabloBlueLbl.Content = counter;
                }
            }
            if (e.Key == Key.I)
            {
                count++;
                tabloRedLbl.Content = count;
            }
            if (e.Key == Key.K)
            {
                if (Convert.ToInt32(tabloRedLbl.Content) > 0)
                {
                    --count;
                    tabloRedLbl.Content = count;
                }
            }
            if (e.Key == Key.P)
            {
                if (this.settingsWindow != null) // check if window is initialized
                {
                    time_out = Properties.Settings.Default.TimeOut;
                    timeout.Start();
                }
            }
            if (e.Key == Key.H)
            {
                if (this.settingsWindow != null) // check if window is initialized
                {
                    time_out = Properties.Settings.Default.TimeOut;
                    timeout1.Start();
                }
            }
            if (e.Key == Key.Space)
            {
                if (ButtonStateCheck == false)
                {
                    ButtonOpenMenu.IsEnabled = false;
                    ButtonTrue();
                    SoundPlayer player = new SoundPlayer(Properties.Resources.pause);
                    player.Play();

                    if (CheckPosition == 0 && change == 0)
                    {
                        start = Properties.Settings.Default.TimerStart;
                        NumRound = Properties.Settings.Default.NumRound;

                    }
                    if (CheckPosition == 0 && change >= 0)
                    {
                        start = Properties.Settings.Default.TimerStart;

                    }
                    else if (CheckPosition != 0)
                    {
                        start = CheckPosition;
                    }
                    timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                    StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                    timer.Start();
                    timeout.Stop();
                    timeout1.Stop();
                    ButtonOpenMenu.IsEnabled = false;
                    ButtonStateCheck = true;
                }
                else if (ButtonStateCheck == true)
                {
                    timeBorder.Background = new SolidColorBrush(Colors.White);
                    StartStopBtn.Background = new SolidColorBrush(Colors.White);
                    SoundPlayer player = new SoundPlayer(Properties.Resources.pause);
                    player.Play();
                    ButtonOpenMenu.IsEnabled = true;
                    ButtonFalse();
                    CheckPosition = start;
                    ButtonStateCheck = false;
                    timer.Stop();
                }
            }
            if (e.Key == Key.Q)
            {
                if (blueHeadTopBtn.IsEnabled)
                {
                    BlueHead();
                    WinBluePoint();
                    blueHeadTopBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueHeadTopBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.E)
            {
                if (blueHeadLeftBtn.IsEnabled)
                {
                    BlueHead();
                    WinBluePoint();
                    blueHeadLeftBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueHeadLeftBtn.IsEnabled = true;
                }                
            }
            if (e.Key == Key.R)
            {
                if (blueHeadRightBtn.IsEnabled)
                {
                    BlueHead();
                    WinBluePoint();
                    blueHeadRightBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueHeadRightBtn.IsEnabled = true;
                }               
            }
            if (e.Key == Key.T)
            {
                if (blueProtectTopBtn.IsEnabled)
                {
                    BlueProtect();
                    WinBluePoint();
                    blueProtectTopBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueProtectTopBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.Y)
            {
                if (blueProtectLeftBtn.IsEnabled)
                {
                    BlueProtect();
                    WinBluePoint();
                    blueProtectLeftBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueProtectLeftBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.U)
            {
                if (blueProtectRightBtn.IsEnabled)
                {
                    BlueProtect();
                    WinBluePoint();
                    blueProtectRightBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueProtectRightBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.F)
            {
                if (blueFistLeftBtn.IsEnabled)
                {
                    BlueFist();
                    WinBluePoint();
                    blueFistLeftBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueFistLeftBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.G)
            {
                if (blueFistMiddBtn.IsEnabled)
                {
                    BlueFist();
                    WinBluePoint();
                    blueFistMiddBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueFistMiddBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.O)
            {
                if (blueRightBtn.IsEnabled)
                {
                    BlueFist();
                    WinBluePoint();
                    blueRightBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    blueRightBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.Z)
            {
                if (redHeadTopBtn.IsEnabled)
                {
                    RedHead();
                    WinRedPoint();
                    redHeadTopBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redHeadTopBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.X)
            {
                if (redHeadLeftBtn.IsEnabled)
                {
                    RedHead();
                    WinRedPoint();
                    redHeadLeftBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redHeadLeftBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.C)
            {
                if (redHeadRightBtn.IsEnabled)
                {
                    RedHead();
                    WinRedPoint();
                    redHeadRightBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redHeadRightBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.V)
            {
                if (redProtectTopBtn.IsEnabled)
                {
                    RedProtect();
                    WinRedPoint();
                    redProtectTopBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redProtectTopBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.B)
            {
                if (redProtectLeftBtn.IsEnabled)
                {
                    RedProtect();
                    WinRedPoint();
                    redProtectLeftBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redProtectLeftBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.N)
            {
                if (redProtectRightBtn.IsEnabled)
                {
                    RedProtect();
                    WinRedPoint();
                    redProtectRightBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redProtectRightBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.M)
            {
                if (redFistLeftBtn.IsEnabled)
                {
                    RedFist();
                    WinRedPoint();
                    redFistLeftBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redFistLeftBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.OemComma)
            {
                if (redFistMiddBtn.IsEnabled)
                {
                    RedFist();
                    WinRedPoint();
                    redFistMiddBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redFistMiddBtn.IsEnabled = true;
                }
            }
            if (e.Key == Key.OemPeriod)
            {
                if (redFistRightBtn.IsEnabled)
                {
                    RedFist();
                    WinRedPoint();
                    redFistRightBtn.IsEnabled = false;
                    await Task.Delay(1000);
                    redFistRightBtn.IsEnabled = true;
                }
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                //Your Logic
                e.Handled = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           
           

        }

        private void FinishRoundBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(tabloBlueLbl.Content) > Convert.ToInt16(tabloRedLbl.Content))
            {
                if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ButtonOpenMenu.IsEnabled = true;
                    CheckPosition = 0;
                    ButtonStateCheck = false;
                    RoundWinBluelbl.Content += "W";
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                    player.Play();
                    //AllClear();

                    start1 = Properties.Settings.Default.TimerStart1;
                    timer1.Start();
                    ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    r1++;                
                }
            }
            else if(Convert.ToInt16(tabloBlueLbl.Content) == Convert.ToInt16(tabloRedLbl.Content))
            {
                MessageBox.Show("Please, Select your decision! ");
            }
            else
            {
                if (MessageBox.Show("Do you confirm your decision?", "Determining the winner!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ButtonOpenMenu.IsEnabled = true;
                    CheckPosition = 0;
                    ButtonStateCheck = false;
                    RoundWinRedlbl.Content = "W";
                    SoundPlayer player = new SoundPlayer(Properties.Resources.RoundEnd);
                    player.Play();
                    //AllClear();                    
                    start1 = Properties.Settings.Default.TimerStart1;
                    timer1.Start();
                    ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    r2++;
                }
            }
            if (r1 - r2 == 2 || (r1 - r2 == 1 && r2 == 1))
            {
                ButtonOpenMenu.IsEnabled = true;
                CheckPosition = 0;
                ButtonStateCheck = false;
                WinBlue();
                StartStopBtn.Content = "START";
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                NumRound++;
                matchTxb.Text = NumRound.ToString();
                l1 = 1;
                round1Txb.Text = l1.ToString();
                r1 = 0;
                r2 = 0;
                RoundWinBluelbl.Content = "";
                RoundWinRedlbl.Content = "";
                timer1.Stop();
                tabloBlueLbl.Content = 0;
                change++;
            }
            if (r2 - r1 == 2 || (r2 - r1 == 1 && r1 == 1))
            {
                ButtonOpenMenu.IsEnabled = true;
                CheckPosition = 0;
                ButtonStateCheck = false;
                WinRed();
                StartStopBtn.Content = "START";
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                NumRound++;
                matchTxb.Text = NumRound.ToString();
                l1 = 1;
                round1Txb.Text = l1.ToString();
                r2 = 0;
                r1 = 0;
                RoundWinBluelbl.Content = "";
                RoundWinRedlbl.Content = "";
                timer1.Stop();
                tabloRedLbl.Content = 0;
                change++;
            }
        }

        public void ButtonTrue()
        {
            blueHeadTopBtn.IsEnabled = true;
            blueHeadLeftBtn.IsEnabled = true;
            blueHeadRightBtn.IsEnabled = true;
            blueProtectTopBtn.IsEnabled = true;
            blueProtectLeftBtn.IsEnabled = true;
            blueProtectRightBtn.IsEnabled = true;
            blueFistLeftBtn.IsEnabled = true;
            blueFistMiddBtn.IsEnabled = true;
            blueRightBtn.IsEnabled = true;

            redHeadTopBtn.IsEnabled = true;
            redHeadLeftBtn.IsEnabled = true;
            redHeadRightBtn.IsEnabled = true;
            redProtectTopBtn.IsEnabled = true;
            redProtectLeftBtn.IsEnabled = true;
            redProtectRightBtn.IsEnabled = true;
            redFistLeftBtn.IsEnabled = true;
            redFistMiddBtn.IsEnabled = true;
            redFistRightBtn.IsEnabled = true;
        }
        private void StartStopBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonStateCheck == false )
            {
                ButtonOpenMenu.IsEnabled = false;
                ButtonTrue();
                SoundPlayer player = new SoundPlayer(Properties.Resources.pause);
                player.Play();

                if (CheckPosition == 0 && change == 0)
                {
                    start = Properties.Settings.Default.TimerStart;
                    NumRound = Properties.Settings.Default.NumRound;
                   
                }
                if (CheckPosition == 0 && change > 0)
                {
                    start = Properties.Settings.Default.TimerStart;
                    
                }
                else if (CheckPosition != 0)
                {
                    start = CheckPosition;
                }
                timeBorder.Background = new SolidColorBrush(Colors.Yellow);
                StartStopBtn.Background = new SolidColorBrush(Colors.Yellow);
                timer.Start();
                timeout.Stop();
                timeout1.Stop();
                timeOutBlueBtn.IsEnabled = true;
                timeOutRedBtn.IsEnabled = true;
                ButtonOpenMenu.IsEnabled = false;
                ButtonStateCheck = true;
            }
            else if (ButtonStateCheck == true)
            {
                timeBorder.Background = new SolidColorBrush(Colors.White);
                StartStopBtn.Background = new SolidColorBrush(Colors.White);
                SoundPlayer player = new SoundPlayer(Properties.Resources.pause);
                player.Play();
                ButtonOpenMenu.IsEnabled = true;
                ButtonFalse();
                CheckPosition = start;
                ButtonStateCheck = false;
                timer.Stop();
            }
        }
    }
}
