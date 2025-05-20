using System;
using System.Windows;
using System.Text.RegularExpressions;
using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko.Users;
using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.TransportRelated;

namespace OOP_Project_Boyko
    {
        

        public partial class PaymentWindow : Window
        {
            private readonly BaseUser _currentUser;
            private readonly Transport _selectedTransport;
            private readonly IPaymentValidator _validator;
            private readonly IPaymentService _paymentService;
            public RentalService RentalService { get; set; } = new RentalService(DataStore.Rentals);

            public PaymentWindow(BaseUser user, Transport transport)
            {
                InitializeComponent();
                _currentUser = user;
                _selectedTransport = transport;
                _validator = new PaymentValidator();
                _paymentService = new PaymentService();

                txtTransportInfo.Text = _selectedTransport.GetTransportDetails();
            }

            private void Pay_Click(object sender, RoutedEventArgs e)
            {
                var data = new PaymentData
                {
                    FullName = txtFullName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    CardNumber = txtCardNumber.Text,
                    ExpiryDate = txtExpiryDate.Text,
                    Cvv = txtCvv.Text,
                    Hours = int.TryParse(txtHours.Text, out int h) ? h : 0
                };

                var (isValid, errorMessage) = _validator.Validate(data, _selectedTransport);
                if (!isValid)
                {
                    lblMessage.Content = errorMessage;
                    return;
                }

                double totalCost = _paymentService.CalculateTotalCost(_selectedTransport, data.Hours);
                lblTotalCost.Content = $"Total cost: {totalCost:F2} UAH";

                try {
                Rental rental = _paymentService.CreateRental(_currentUser, _selectedTransport, data, totalCost);
                _selectedTransport.Status = TransportStatus.Rented;

                RentalService.AddRental(rental);
                DataStore.SaveData();
                } 
                catch (Exception ex) { MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }

                MessageBox.Show($"Sucsessfully rented!\nTotal cost: {totalCost:F2} UAH", "Sucsess");

                MainWindow mainWindow = new MainWindow(_currentUser);
                mainWindow.Show();
                this.Close();
            }

            private void Back_Click(object sender, RoutedEventArgs e)
            {
                MainWindow mainWindow = new MainWindow(_currentUser);
                mainWindow.Show();
                this.Close();
            }
        }
    }