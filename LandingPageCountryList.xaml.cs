﻿using System;
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
    /// Interaction logic for LandingPageCountryList.xaml
    /// </summary>
    public partial class LandingPageCountryList : Page
    {
     
            public LandingPageCountryList()
            {
                InitializeComponent();
            }

            private void NavigateToCountryListPage(object sender, RoutedEventArgs e)
            {
                
                NavigationService.Navigate(new Uri("Country.xaml", UriKind.Relative));
            }
        
    }
}
