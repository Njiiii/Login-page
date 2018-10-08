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

namespace Login_page.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        
        Window1 Window1 = new Window1();

        Pages.UserPage UserPage = new Pages.UserPage();
        Pages.AdminPage AdminPage = new Pages.AdminPage();
        Pages.UserCreationPage UserCreationPage = new Pages.UserCreationPage();


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            String givenAccountName = UsernameBox.Text;
            String givenPassword = PasswordBox.Password;


            if(givenAccountName != "" && givenPassword != "")
            {
                NavigationService.Navigate(UserPage);
            }

            if(givenAccountName == "admin" && givenPassword != "")
            {
                NavigationService.Navigate(AdminPage);
            }
        }


        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            Window1.Show();
            Window1.Content = UserCreationPage;
        }

        
    }
}
