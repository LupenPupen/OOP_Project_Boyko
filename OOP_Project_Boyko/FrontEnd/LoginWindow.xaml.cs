using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko.Users;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OOP_Project_Boyko
{
    public partial class LoginWindow : Window
    {
        public UserService UserService { get; set; } = new UserService(DataStore.Users);
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            BaseUser? user = DataStore.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                lblMessage.Content = "Incorrent login or password.";
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Content = "Login and password must be filled.";
                return;
            }

            if (DataStore.Users.Any(u => u.Username == username))
            {
                lblMessage.Content = "User with same name already exists.";
                return;
            }

            BaseUser newUser = new RegularUser(username, password);
            UserService.AddUser(newUser);

            lblMessage.Content = "Account sucsessfully registered! Now you can login.";
            lblMessage.Foreground = System.Windows.Media.Brushes.Green;

            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}