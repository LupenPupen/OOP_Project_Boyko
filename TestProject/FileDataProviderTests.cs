using OOP_Project_Boyko;
using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.TransportRelated;
using OOP_Project_Boyko.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class FileDataProviderTests
    {
        private string usersFile;
        private string transportsFile;
        private string rentalsFile;
        private FileDataProvider provider;

        [TestInitialize]
        public void Setup()
        {
            usersFile = Path.GetTempFileName();
            transportsFile = Path.GetTempFileName();
            rentalsFile = Path.GetTempFileName();
            provider = new FileDataProvider(usersFile, transportsFile, rentalsFile);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(usersFile)) File.Delete(usersFile);
            if (File.Exists(transportsFile)) File.Delete(transportsFile);
            if (File.Exists(rentalsFile)) File.Delete(rentalsFile);
        }

        [TestMethod]
        public void SaveAndLoadUsers_WorksCorrectly()
        {
            var users = new ObservableCollection<BaseUser>
            {
                new Administrator("admin", "1234")
            };
            provider.SaveUsers(users);

            var loaded = provider.LoadUsers();
            Assert.AreEqual(1, loaded.Count);
            Assert.AreEqual("admin", loaded[0].Username);
            Assert.AreEqual("1234", loaded[0].Password);
            Assert.IsInstanceOfType(loaded[0], typeof(Administrator));
        }

        [TestMethod]
        public void LoadUsers_ReturnsEmptyIfFileNotExists()
        {
            File.Delete(usersFile);
            var loaded = provider.LoadUsers();
            Assert.AreEqual(0, loaded.Count);
        }

        [TestMethod]
        public void SaveAndLoadRentals_WorksCorrectly()
        {
            var rentals = new ObservableCollection<Rental>
            {
                new Rental
                {
                    UserName = "user1",
                    TransportName = "Bike",
                    Type = TransportType.Bicycle,
                    Hours = 2,
                    TotalCost = 100.0,
                    FullName = "Иван Иванов",
                    PhoneNumber = "1234567890",
                    CardNumber = "1111222233334444",
                    ExpiryDate = "12.25",
                    Cvv = "123"
                }
            };
            provider.SaveRentals(rentals);

            var loaded = provider.LoadRentals();
            Assert.AreEqual(1, loaded.Count);
            Assert.AreEqual("user1", loaded[0].UserName);
            Assert.AreEqual("Bike", loaded[0].TransportName);
            Assert.AreEqual(TransportType.Bicycle, loaded[0].Type);
            Assert.AreEqual(2, loaded[0].Hours);
            Assert.AreEqual(100.0, loaded[0].TotalCost);
        }

        [TestMethod]
        public void LoadTransports_ReturnsEmptyIfFileNotExists()
        {
            File.Delete(transportsFile);
            var loaded = provider.LoadTransports();
            Assert.AreEqual(0, loaded.Count);
        }

        [TestMethod]
        public void LoadRentals_ReturnsEmptyIfFileNotExists()
        {
            File.Delete(rentalsFile);
            var loaded = provider.LoadRentals();
            Assert.AreEqual(0, loaded.Count);
        }
    }
}