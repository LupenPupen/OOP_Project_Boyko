using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko;
using OOP_Project_Boyko.TransportRelated;
using System.Collections.ObjectModel;
using OOP_Project_Boyko.RegisteredEventsArgs;
using System;

namespace TestProject
{
    [TestClass]
    public class RentalServiceTests
    {
        private ObservableCollection<Rental> rentals;
        private RentalService service;

        [TestInitialize]
        public void Setup()
        {
            rentals = new ObservableCollection<Rental>();
            service = new RentalService(rentals);
        }

        [TestMethod]
        public void AddRental_AddsRentalToCollection()
        {
            var rental = new Rental
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
            };

            service.AddRental(rental);

            Assert.AreEqual(1, rentals.Count);
            Assert.AreEqual(rental, rentals[0]);
        }

        [TestMethod]
        public void AddRental_DoesNotAddNull()
        {
            service.AddRental(null);
            Assert.AreEqual(0, rentals.Count);
        }

        [TestMethod]
        public void RemoveRental_RemovesRentalFromCollection()
        {
            var rental = new Rental { UserName = "user1" };
            rentals.Add(rental);

            service.RemoveRental(rental);

            Assert.AreEqual(0, rentals.Count);
        }

        [TestMethod]
        public void RemoveRental_DoesNotThrowOnNull()
        {
            rentals.Add(new Rental { UserName = "user1" });
            service.RemoveRental(null);
            Assert.AreEqual(1, rentals.Count);
        }

        [TestMethod]
        public void AddRental_RaisesRentalRegisteredEvent()
        {
            var rental = new Rental { UserName = "user1" };
            RentalRegisteredEventArgs eventArgs = null;
            service.RentalRegistered += (s, e) => eventArgs = e;

            service.AddRental(rental);

            Assert.IsNotNull(eventArgs);
            Assert.AreEqual(rental, eventArgs.RegisteredRental);
        }
    }
}