using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko;
using OOP_Project_Boyko.TransportRelated;

namespace TestProject
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void ParameterizedConstructor_SetsAllProperties()
        {
            var rental = new Rental(
                "user1",
                "Bike",
                TransportType.Bicycle,
                3,
                150.0,
                "Иван Иванов",
                "1234567890",
                "1111222233334444",
                "12.25",
                "123"
            );

            Assert.AreEqual("user1", rental.UserName);
            Assert.AreEqual("Bike", rental.TransportName);
            Assert.AreEqual(TransportType.Bicycle, rental.Type);
            Assert.AreEqual(3, rental.Hours);
            Assert.AreEqual(150.0, rental.TotalCost);
            Assert.AreEqual("Иван Иванов", rental.FullName);
            Assert.AreEqual("1234567890", rental.PhoneNumber);
            Assert.AreEqual("1111222233334444", rental.CardNumber);
            Assert.AreEqual("12.25", rental.ExpiryDate);
            Assert.AreEqual("123", rental.Cvv);
        }

        [TestMethod]
        public void Properties_CanBeSetAndGet()
        {
            var rental = new Rental();
            rental.UserName = "user2";
            rental.TransportName = "Scooter";
            rental.Type = TransportType.Scooter;
            rental.Hours = 5;
            rental.TotalCost = 500.0;
            rental.FullName = "Петр Петров";
            rental.PhoneNumber = "0987654321";
            rental.CardNumber = "5555666677778888";
            rental.ExpiryDate = "01.30";
            rental.Cvv = "456";

            Assert.AreEqual("user2", rental.UserName);
            Assert.AreEqual("Scooter", rental.TransportName);
            Assert.AreEqual(TransportType.Scooter, rental.Type);
            Assert.AreEqual(5, rental.Hours);
            Assert.AreEqual(500.0, rental.TotalCost);
            Assert.AreEqual("Петр Петров", rental.FullName);
            Assert.AreEqual("0987654321", rental.PhoneNumber);
            Assert.AreEqual("5555666677778888", rental.CardNumber);
            Assert.AreEqual("01.30", rental.ExpiryDate);
            Assert.AreEqual("456", rental.Cvv);
        }
    }
}