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

namespace Login_page.Pages
{
    /// <summary>
    /// Interaction logic for UserCreationPage.xaml
    /// </summary>
    public partial class UserCreationPage : Page
    {

        public UserCreationPage()
        {
            InitializeComponent();
        }

        private void SaveNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            AccountSavedNotification.Visibility = Visibility.Visible;
        }
        
    }
}
