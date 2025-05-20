using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Data;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko.Users;
using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.TransportRelated;

namespace OOP_Project_Boyko
{
    public partial class AdminMenuWindow : Window
    {
        public UserService UserService { get; set; } = new UserService(DataStore.Users);
        public TransportService TransportService { get; set; } = new TransportService(DataStore.Transports);
        public RentalService RentalService { get; set; } = new RentalService(DataStore.Rentals);
        public AdminMenuWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgUsers.ItemsSource = DataStore.Users;
            dgTransports.ItemsSource = DataStore.Transports;
            dgRentals.ItemsSource = DataStore.Rentals;

            dgUsers.AutoGeneratingColumn += DgUsers_AutoGeneratingColumn;
            dgTransports.AutoGeneratingColumn += DgTransports_AutoGeneratingColumn;
        }

        private void DgUsers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Role")
            {
                e.Cancel = true;
            }
            else if (e.PropertyName == "User Type")
            {
                var originalColumn = e.Column as DataGridTextColumn;
                if (originalColumn != null)
                {
                    originalColumn.IsReadOnly = true;
                    originalColumn.Header = "User Type";
                }
            }
            else if (e.PropertyName == "Password")
            {
                e.Cancel = true;
            }
        }

        private void DgTransports_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Type")
            {
                var originalColumn = e.Column as DataGridTextColumn;
                if (originalColumn != null)
                {
                    DataGridComboBoxColumn typeComboBoxColumn = new DataGridComboBoxColumn();
                    typeComboBoxColumn.Header = originalColumn.Header;
                    typeComboBoxColumn.ItemsSource = Enum.GetValues(typeof(TransportType)).Cast<TransportType>();
                    typeComboBoxColumn.SelectedItemBinding = new Binding("Type");
                    e.Column = typeComboBoxColumn;
                }
            }

            else if (e.PropertyName == "Status")
            {
                var originalColumn = e.Column as DataGridTextColumn;
                if (originalColumn != null)
                {
                    DataGridComboBoxColumn statusComboBoxColumn = new DataGridComboBoxColumn();
                    statusComboBoxColumn.Header = originalColumn.Header;
                    statusComboBoxColumn.ItemsSource = Enum.GetValues(typeof(TransportStatus)).Cast<TransportStatus>();
                    statusComboBoxColumn.SelectedItemBinding = new Binding("Status");
                    e.Column = statusComboBoxColumn;
                }
            }

            else if (e.PropertyName == "QualityCoef")
            {
                var originalColumn = e.Column as DataGridTextColumn;
                if (originalColumn != null)
                {
                    originalColumn.IsReadOnly = true;
                    originalColumn.Header = "Quality coefficent";
                }
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            BaseUser newUser = new RegularUser("user", "user");
            UserService.AddUser(newUser);
            dgUsers.SelectedItem = newUser;
            dgUsers.ScrollIntoView(newUser);
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem is BaseUser selectedUser)
            {
                if (selectedUser is Administrator admin && admin.Username == "admin")
                {
                    MessageBox.Show("Can't delete administrator.", "Delete error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                UserService.RemoveUser(selectedUser);
            }
            else
            {
                MessageBox.Show("Choose user to delete.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveUsers_Click(object sender, RoutedEventArgs e)
        {
            DataStore.SaveData();
            MessageBox.Show("Users saved.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddTransport_Click(object sender, RoutedEventArgs e)
        {
            Transport newTransport = new Transport("New transport", TransportType.Bicycle, "Adress", TransportStatus.Free, 0, 0);
            TransportService.AddTransport(newTransport);
            dgTransports.SelectedItem = newTransport;
            dgTransports.ScrollIntoView(newTransport);
        }

        private void DeleteTransport_Click(object sender, RoutedEventArgs e)
        {
            if (dgTransports.SelectedItem is Transport selectedTransport)
            {
                TransportService.RemoveTransport(selectedTransport);
            }
            else
            {
                MessageBox.Show("Choose transpot to delete.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveTransports_Click(object sender, RoutedEventArgs e)
        {
            DataStore.SaveData();
            MessageBox.Show("Transport saved.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void CloseAdminMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}