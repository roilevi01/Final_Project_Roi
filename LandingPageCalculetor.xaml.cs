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

namespace Final_Project_Roi
{
    /// <summary>
    /// Interaction logic for LandingPageCalculetor.xaml
    /// </summary>
    public partial class LandingPageCalculetor : Page
    {
        public LandingPageCalculetor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CalculetorGame calculatorGameWindow = new CalculetorGame();

           
            calculatorGameWindow.Show();

            
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close(); 
            }






        }
    }
}
