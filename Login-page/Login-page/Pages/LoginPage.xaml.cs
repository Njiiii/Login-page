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
            int x = 0;
            

            //Connection string for the local sql server
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Ohjelmointiprojektit\Login-page\Login-page\Login-page\Pages\UserDatabase.mdf;Integrated Security=True";


            using (conn)
            {

                conn.Open();
                
                //Write "connection open" to console, so that we know if and when connection is open
                Console.WriteLine("connection open");
                
                using (SqlCommand comm = new SqlCommand("SELECT * FROM UsersTable WHERE AccountName = '" + givenAccountName + "'", conn))
                {

                    using (SqlDataReader reader = comm.ExecuteReader())
                    {

                        reader.Read();
                           
                            //If accontname is incorrect/not found, write "Invalid accountname" (FOR NOW)
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Invalid accountname");
                            }


                            //If accountname is correct, direct user to UserPage or AdminPage depending on admin access
                            else
                            {
                            
                                Console.WriteLine("accountname correct");
                                    
                                    //Check if account has admin access. If yes, redirect user to AdminPage
                                    if (reader["Admin"].ToString() == "True")
                                    {
                                        NavigationService.Navigate(AdminPage);
                                    }

                                    else
                                    {
                                        NavigationService.Navigate(UserPage);
                                    }

                            }

                        reader.Close();
                        
                    }
                }
            }

            conn.Close();
            //Write "connection closed" to console when connection to the server is terminated
            Console.WriteLine("connection closed");
            
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
