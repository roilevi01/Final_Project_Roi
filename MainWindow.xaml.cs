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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LandingPageCalculetor landingPageCalculetor = new LandingPageCalculetor();
            NavigationWindow navigationWindow = new NavigationWindow();
             navigationWindow.Content=landingPageCalculetor;
            navigationWindow.Show();
            this.Close();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LandingPageSnakesAndLadders landingPageSnakesAndLandders= new LandingPageSnakesAndLadders();
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Content= landingPageSnakesAndLandders;
            navigationWindow.Show();
         this.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LandingPageCountryList landingPageCountryList = new LandingPageCountryList();
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Content=landingPageCountryList;
            navigationWindow.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            LandingPageToDoList landingPageToDoList = new LandingPageToDoList();    
            NavigationWindow navigationWindow = new NavigationWindow(); 
            navigationWindow.Content= landingPageToDoList;
            navigationWindow.Show();
            this.Close();

        }


        public class CustomButton : Button
        {
            public static readonly DependencyProperty ImageSourceProperty =
                DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CustomButton), new PropertyMetadata(null));

            public ImageSource ImageSource
            {
                get { return (ImageSource)GetValue(ImageSourceProperty); }
                set { SetValue(ImageSourceProperty, value); }
            }
        }




    }
  

}