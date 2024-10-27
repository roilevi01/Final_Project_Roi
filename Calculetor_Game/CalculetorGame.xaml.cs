using System;
using System.Collections.Generic;
using System.Data;
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

namespace Final_Project_Roi
{
  
    public partial class CalculetorGame : Window
    {
        public CalculetorGame()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            txtDisplay.Text += button.Content.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }

      
        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(txtDisplay.Text);
                txtDisplay.Text = Math.Sqrt(number).ToString();
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
            }
        }

       
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = txtDisplay.Text;
                DataTable table = new DataTable();
                var result = table.Compute(expression, "");
                txtDisplay.Text = result.ToString();
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error"; 
            }
        }
    }
}
