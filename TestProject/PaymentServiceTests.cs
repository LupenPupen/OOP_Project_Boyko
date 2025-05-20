using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko.TransportRelated;
using OOP_Project_Boyko.Users;
using OOP_Project_Boyko.Data;

namespace TestProject
{
    [TestClass]
    public class PaymentServiceTests
    {
        [TestMethod]
        public void CalculateTotalCost_ReturnsCorrectValue()
        {
            var service = new PaymentService();
            var transport = new Transport { PricePerHour = 50.0 };
            int hours = 3;

            double result = service.CalculateTotalCost(transport, hours);

            Assert.AreEqual(150.0, result);
        }

        [TestMethod]
        public void CreateRental_CreatesRentalWithCorrectData()
        {
            var service = new PaymentService();
            var user = new Administrator("admin", "1234");
            var transport = new Transport { Name = "Bike", Type = TransportType.Bicycle, PricePerHour = 100.0 };
            var paymentData = new PaymentData
            {
                FullName = "Иван Иванов",
                PhoneNumber = "1234567890",
                CardNumber = "1111222233334444",
                ExpiryDate = "12.25",
                Cvv = "123",
                Hours = 2
            };
            double totalCost = 200.0;

            var rental = service.CreateRental(user, transport, paymentData, totalCost);

            Assert.AreEqual("admin", rental.UserName);
            Assert.AreEqual("Bike", rental.TransportName);
            Assert.AreEqual(TransportType.Bicycle, rental.Type);
            Assert.AreEqual(2, rental.Hours);
            Assert.AreEqual(200.0, rental.TotalCost);
            Assert.AreEqual("Иван Иванов", rental.FullName);
            Assert.AreEqual("1234567890", rental.PhoneNumber);
            Assert.AreEqual("1111222233334444", rental.CardNumber);
            Assert.AreEqual("12.25", rental.ExpiryDate);
            Assert.AreEqual("123", rental.Cvv);
        }
    }
}