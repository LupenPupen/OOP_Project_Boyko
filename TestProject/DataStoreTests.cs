using OOP_Project_Boyko;
using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.TransportRelated;
using OOP_Project_Boyko.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

[assembly:DoNotParallelize] 

namespace TestProject
{
    public class MockDataProvider : IDataProvider
    {

        public bool UsersSaved { get; private set; }
        public bool TransportsSaved { get; private set; }
        public bool RentalsSaved { get; private set; }

        public ObservableCollection<BaseUser> LoadUsers() =>
            new ObservableCollection<BaseUser>();

        public ObservableCollection<Transport> LoadTransports() =>
            new ObservableCollection<Transport>();

        public ObservableCollection<Rental> LoadRentals() =>
            new ObservableCollection<Rental>();

        public void SaveUsers(ObservableCollection<BaseUser> users) =>
            UsersSaved = true;

        public void SaveTransports(ObservableCollection<Transport> transports) =>
            TransportsSaved = true;

        public void SaveRentals(ObservableCollection<Rental> rentals) =>
            RentalsSaved = true;
    }

    [TestClass]
    public class DataStoreTests
    {
        [TestInitialize]
        public void Setup()
        {
            DataStore.DataProvider = new MockDataProvider();
            DataStore.Users = new ObservableCollection<BaseUser>();
            DataStore.Transports = new ObservableCollection<Transport>();
            DataStore.Rentals = new ObservableCollection<Rental>();
        }

        [TestMethod]
        public void LoadData_AddsAdminIfNotExists()
        {
            DataStore.Users.Clear();
            DataStore.LoadData();
            Assert.IsTrue(DataStore.Users.Any(u => u is Administrator && u.Username == "admin"));
        }

        [TestMethod]
        public void LoadData_DoesNotDuplicateAdmin()
        {
            DataStore.Users.Clear();
            DataStore.Users.Add(new Administrator("admin", "admin"));
            DataStore.LoadData();
            int adminCount = DataStore.Users.Count(u => u is Administrator && u.Username == "admin");
            Assert.AreEqual(1, adminCount);
        }

        [TestMethod]
        public void SaveData_CallsProviderSaveMethods()
        {
            var mockProvider = new MockDataProvider();
            DataStore.DataProvider = mockProvider;
            DataStore.SaveData();
            Assert.IsTrue(mockProvider.UsersSaved);
            Assert.IsTrue(mockProvider.TransportsSaved);
            Assert.IsTrue(mockProvider.RentalsSaved);
        }

        [TestMethod]
        public void LoadData_RaisesDataLoadedEvent()
        {
            bool eventRaised = false;
            DataStore.DataLoaded += (s, e) => eventRaised = true;
            DataStore.LoadData();
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void SaveData_RaisesDataSavedEvent()
        {
            bool eventRaised = false;
            DataStore.DataSaved += (s, e) => eventRaised = true;
            DataStore.SaveData();
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadData_ThrowsIfProviderNull()
        {
            DataStore.DataProvider = null;
            DataStore.LoadData();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SaveData_ThrowsIfProviderNull()
        {
            DataStore.DataProvider = null;
            DataStore.SaveData();
        }
    }
}