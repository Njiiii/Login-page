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
using System.Data.SqlClient;

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
    

        //Window1 is used only to show UserCreationPage.
        Window1 Window1 = new Window1();


        //These are the pages we want show our user
        //UserCreationPage is shown in Window1, not in the MainWindow
        Pages.UserPage UserPage = new Pages.UserPage();
        Pages.AdminPage AdminPage = new Pages.AdminPage();
        Pages.UserCreationPage UserCreationPage = new Pages.UserCreationPage();


        //Connecation to the sql server
        SqlConnection conn = new SqlConnection();


        //When "login" is pressed, connect to the sql database and check if given userinfo is correct.
        //Normally user is redirected to the UserPage, but if user gives info for an admin account, they are redirected to the AdminPage.
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            String givenAccountName = UsernameBox.Text;
            String givenPassword = PasswordBox.Password;
            
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Ohjelmointiprojektit\Login-page\Login-page\Login-page\Pages\UserDatabase.mdf;Integrated Security=True";

            using (conn)
            {
                conn.Open();
                Console.WriteLine("connection open");

                using(SqlCommand comm = new SqlCommand("SELECT AccountName FROM UsersTable", conn))
                {

                    if(comm.Equals(givenAccountName))
                    {
                        Console.WriteLine("accountname correct");
                    }
                    else
                    {
                        Console.WriteLine("accountname incorrect");
                    }
                }
            }
            conn.Close();
            Console.WriteLine("connection closed");
            

            //conn.Open();
            //Console.WriteLine("connection open");
            




        }


        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {

            //Connnction to the database is closed here to avoid conflicts.
            //Connection needs to be reopened in user creation to save new user information.
            conn.Close();
            Console.WriteLine("Closed connection to access user creation");

            Window1.Show();
            Window1.Content = UserCreationPage;
        }

     
        
    }
}
