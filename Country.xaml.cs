using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for Country.xaml
    /// </summary>
    public partial class Country : Page
    {
        public ObservableCollection<CountryList> Countries { get; set; } = new ObservableCollection<CountryList>();
        private ObservableCollection<CountryList> _allCountries = new ObservableCollection<CountryList>();

        public static HttpClient client = new HttpClient();
        public Country()
        {
            InitializeComponent();
            LoadCountriesDataAsync();

        }
        private async Task LoadCountriesDataAsync()
        {
            string json = await client.GetStringAsync("https://restcountries.com/v3.1/all");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Countries = JsonSerializer.Deserialize<ObservableCollection<CountryList>>(json, options);

            foreach (CountryList c in Countries)
            {
                _allCountries.Add(c);
            }
            CountriesDataGrid.ItemsSource = Countries;

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            List<CountryList> filteredCountries = _allCountries
                .Where(c => c.Name.Common.ToLower().Contains(searchText))
                .ToList();

            UpdateCountriesCollection(filteredCountries);
        }

        private void RegionFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRegion = (RegionFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedRegion == "All Regions")
            {
                UpdateCountriesCollection(_allCountries.ToList());
            }
            else
            {
                List<CountryList> filteredCountries = _allCountries
                    .Where(c => c.Region.ToLower() == selectedRegion.ToLower())
                    .ToList();

                UpdateCountriesCollection(filteredCountries);
            }
        }



        private void UpdateCountriesCollection(List<CountryList> countries)
        {
            Countries.Clear();
            foreach (CountryList country in countries)
            {
                Countries.Add(country);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
