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
    /// Interaction logic for LandingPageToDoList.xaml
    /// </summary>
    public partial class LandingPageToDoList : Page
    {
        public LandingPageToDoList()
        {
            InitializeComponent();
        }

        private void GoToToDoList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("ToDoList.xaml", UriKind.Relative));




        }
    
    }
}
