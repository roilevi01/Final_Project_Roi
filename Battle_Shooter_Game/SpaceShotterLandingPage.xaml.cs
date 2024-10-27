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
    /// Interaction logic for SpaceShotterLandingPage.xaml
    /// </summary>
    public partial class SpaceShotterLandingPage : Page
    {
        public SpaceShotterLandingPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        Battle_Shooter_Game battle_Shooter_Game  = new Battle_Shooter_Game();
            battle_Shooter_Game.Show();

            Window.GetWindow(this).Close();  
           
           
        }
    }
}
