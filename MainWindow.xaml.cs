using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            ImageBrush myImage= new ImageBrush();
            myImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Image_Bg\\Picture_Backg.jpg"));
            myImage.Stretch = Stretch.Fill;
            this.Background = myImage;
        }

       

        private void LandingPage_Space_Shoter(object sender, RoutedEventArgs e)
        {
           

           SpaceShotterLandingPage spaceShotterLandingPage = new SpaceShotterLandingPage();
            
            

            NavigationWindow window = new NavigationWindow();
            window.Content = spaceShotterLandingPage;
            window.Show();
           

            
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LandingPageXorO landingPageXorO = new LandingPageXorO();
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Content = landingPageXorO;
            navigationWindow.Show();
            this.Close();   
        }
    }
}