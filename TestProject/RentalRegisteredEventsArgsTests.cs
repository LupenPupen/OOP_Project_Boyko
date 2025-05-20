using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.RegisteredEventsArgs;
using OOP_Project_Boyko;
using OOP_Project_Boyko.TransportRelated;

namespace TestProject
{
    [TestClass]
    public class RentalRegisteredEventsArgsTests
    {
        [TestMethod]
        public void Constructor_SetsRegisteredRental()
        {
            // Arrange
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

            // Act
            var args = new RentalRegisteredEventArgs(rental);

            // Assert
            Assert.AreEqual(rental, args.RegisteredRental);
        }

        [TestMethod]
        public void RegisteredRental_CanBeNull()
        {
            var args = new RentalRegisteredEventArgs(null);
            Assert.IsNull(args.RegisteredRental);
        }
    }
}