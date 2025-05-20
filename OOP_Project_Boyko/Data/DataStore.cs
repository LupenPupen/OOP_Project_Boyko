using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.Users;
using OOP_Project_Boyko.TransportRelated;

namespace OOP_Project_Boyko.Data
{

    public static class DataStore
    {
        public static IDataProvider DataProvider { get; set; } = new FileDataProvider(
            "C:\\Users\\Admin\\source\\repos\\OOP_Project_Boyko\\JsonData\\users.json",
            "C:\\Users\\Admin\\source\\repos\\OOP_Project_Boyko\\JsonData\\transports.json",
            "C:\\Users\\Admin\\source\\repos\\OOP_Project_Boyko\\JsonData\\rentals.json"
        );

        public static ObservableCollection<BaseUser> Users { get; set; } = [];
        public static ObservableCollection<Transport> Transports { get; set; } = [];
        public static ObservableCollection<Rental> Rentals { get; set; } = [];

        public static event EventHandler? DataLoaded;
        public static event EventHandler? DataSaved;

        public static void LoadData()
        {
            if (DataProvider == null)
                throw new InvalidOperationException("DataProvider is not set.");

            Users = DataProvider.LoadUsers();
            Transports = DataProvider.LoadTransports();
            Rentals = DataProvider.LoadRentals();

            if (!Users.OfType<Administrator>().Any(u => u.Username == "admin"))
                Users.Add(new Administrator("admin", "admin"));

            OnDataLoaded();
        }
        public static void SaveData()
        {
            if (DataProvider == null)
                throw new InvalidOperationException("DataProvider is not set.");

            DataProvider.SaveUsers(Users);
            DataProvider.SaveTransports(Transports);
            DataProvider.SaveRentals(Rentals);

            OnDataSaved();
        }

        private static void OnDataLoaded()
        {
            DataLoaded?.Invoke(null, EventArgs.Empty);
        }

        private static void OnDataSaved()
        {
            DataSaved?.Invoke(null, EventArgs.Empty);
        }
    }
}
