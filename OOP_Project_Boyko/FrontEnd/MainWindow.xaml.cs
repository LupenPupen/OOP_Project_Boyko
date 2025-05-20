using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko.TransportRelated;
using OOP_Project_Boyko.Users;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OOP_Project_Boyko
{
    public partial class MainWindow : Window
    {
        public TransportService TransportService { get; set; } = new TransportService(DataStore.Transports);
        private BaseUser _currentUser;
        private Transport _foundTransport;

        public MainWindow(BaseUser user)
        {
            InitializeComponent();
            _currentUser = user;

            lblWelcome.Content = _currentUser.GetGreeting();

            if (_currentUser is Administrator)
            {
                btnAdminMenu.Visibility = Visibility.Visible;
            }
        }

        private void SearchBicycle_Click(object sender, RoutedEventArgs e)
        {
            SearchAndDisplayTransport(TransportType.Bicycle);
        }

        private void SearchScooter_Click(object sender, RoutedEventArgs e)
        {
            SearchAndDisplayTransport(TransportType.Scooter);
        }

        private void SearchAndDisplayTransport(TransportType type)
        {
            _foundTransport = TransportService.FindBestFreeTransport(type);

            if (_foundTransport != null)
            {
                txtTransportDetails.Text = _foundTransport.GetTransportDetails();

                btnRent.IsEnabled = true;
            }
            else
            {
                txtTransportDetails.Text = $"No free {type}s finded.";
                btnRent.IsEnabled = false;
            }
        }

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            if (_foundTransport != null && _foundTransport.Status == TransportStatus.Free)
            {
                PaymentWindow paymentWindow = new PaymentWindow(_currentUser, _foundTransport);
                paymentWindow.Show();
                this.Close();
            }
        }

        private void AdminMenu_Click(object sender, RoutedEventArgs e)
        {
            AdminMenuWindow adminWindow = new AdminMenuWindow();
            adminWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}