using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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



    /// <summary>
    /// Interaction logic for LandingPageXorO.xaml
    /// </summary>
   
    namespace Final_Project_Roi
    {
        public partial class LandingPageXorO : Page
        {
            public LandingPageXorO()
            {
                InitializeComponent();
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
              
                XorOGame page = new XorOGame();

                
                NavigationService.Navigate(page);
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            XorOGame xorOGame = new XorOGame();
            NavigationService.Navigate(xorOGame);

        }
    }
    }

