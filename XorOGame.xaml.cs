using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Final_Project_Roi
{
    public partial class XorOGame : Page
    {
        bool Checker = false;
        int plusone;

        public XorOGame()
        {
            InitializeComponent();
        }

        void Enable_False()
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            btn7.IsEnabled = false;
            btn8.IsEnabled = false;
            btn9.IsEnabled = false;
        }

        void Score()
        {
           
            if ((btn1.Content?.ToString() == "X" && btn2.Content?.ToString() == "X" && btn3.Content?.ToString() == "X") ||
                (btn1.Content?.ToString() == "X" && btn4.Content?.ToString() == "X" && btn7.Content?.ToString() == "X") ||
                (btn1.Content?.ToString() == "X" && btn5.Content?.ToString() == "X" && btn9.Content?.ToString() == "X") ||
                (btn3.Content?.ToString() == "X" && btn5.Content?.ToString() == "X" && btn7.Content?.ToString() == "X") ||
                (btn2.Content?.ToString() == "X" && btn5.Content?.ToString() == "X" && btn8.Content?.ToString() == "X") ||
                (btn4.Content?.ToString() == "X" && btn5.Content?.ToString() == "X" && btn6.Content?.ToString() == "X") ||
                (btn3.Content?.ToString() == "X" && btn6.Content?.ToString() == "X" && btn9.Content?.ToString() == "X") ||
                (btn7.Content?.ToString() == "X" && btn8.Content?.ToString() == "X" && btn9.Content?.ToString() == "X"))
            {
                btn1.Background = btn2.Background = btn3.Background = new SolidColorBrush(Colors.LightBlue);
                MessageBox.Show("The winner is player X", "Play Center", MessageBoxButton.OK, MessageBoxImage.Information);
                plusone = int.Parse(playerXScore.Content.ToString());
                playerXScore.Content = (plusone + 1).ToString();
                Enable_False();
            }
          
            else if ((btn1.Content?.ToString() == "O" && btn2.Content?.ToString() == "O" && btn3.Content?.ToString() == "O") ||
                     (btn1.Content?.ToString() == "O" && btn4.Content?.ToString() == "O" && btn7.Content?.ToString() == "O") ||
                     (btn1.Content?.ToString() == "O" && btn5.Content?.ToString() == "O" && btn9.Content?.ToString() == "O") ||
                     (btn3.Content?.ToString() == "O" && btn5.Content?.ToString() == "O" && btn7.Content?.ToString() == "O") ||
                     (btn2.Content?.ToString() == "O" && btn5.Content?.ToString() == "O" && btn8.Content?.ToString() == "O") ||
                     (btn4.Content?.ToString() == "O" && btn5.Content?.ToString() == "O" && btn6.Content?.ToString() == "O") ||
                     (btn3.Content?.ToString() == "O" && btn6.Content?.ToString() == "O" && btn9.Content?.ToString() == "O") ||
                     (btn7.Content?.ToString() == "O" && btn8.Content?.ToString() == "O" && btn9.Content?.ToString() == "O"))
            {
                btn1.Background = btn2.Background = btn3.Background = new SolidColorBrush(Colors.LightBlue);
                MessageBox.Show("The winner is player O", "Play Center", MessageBoxButton.OK, MessageBoxImage.Information);
                plusone = int.Parse(playerOScore.Content.ToString());
                playerOScore.Content = (plusone + 1).ToString();
                Enable_False();
            }
        }


        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn3);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn6);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn7);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonContent(btn9);
        }

        private void UpdateButtonContent(Button btn)
        {
            if (Checker == false)
            {
                btn.Content = "X";
                Checker = true;
            }
            else
            {
                btn.Content = "O";
                Checker = false;
            }

            btn.IsEnabled = false;
            Score();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            
            btn1.Content = btn2.Content = btn3.Content = btn4.Content = btn5.Content = btn6.Content = btn7.Content = btn8.Content = btn9.Content = "";
            btn1.IsEnabled = btn2.IsEnabled = btn3.IsEnabled = btn4.IsEnabled = btn5.IsEnabled = btn6.IsEnabled = btn7.IsEnabled = btn8.IsEnabled = btn9.IsEnabled = true;
            btn1.Background = btn2.Background = btn3.Background = btn4.Background = btn5.Background = btn6.Background = btn7.Background = btn8.Background = btn9.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
          MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close(); 
            
            


        }
    }
}
