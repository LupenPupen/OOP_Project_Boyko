using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko;
using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.TransportRelated;

namespace TestProject
{
    [TestClass]
    public class PaymentValidatorTests
    {
        private PaymentValidator validator;
        private PaymentData validData;
        private Transport validTransport;

        [TestInitialize]
        public void Setup()
        {
            validator = new PaymentValidator();
            validData = new PaymentData
            {
                FullName = "Иван Иванов",
                PhoneNumber = "+79991234567",
                CardNumber = "1234567812345678",
                ExpiryDate = "15.12",
                Cvv = "123",
                Hours = 2
            };
            validTransport = new Transport
            {
                Status = TransportStatus.Free
            };
        }

        [TestMethod]
        public void Validate_ReturnsTrue_ForValidData()
        {
            var result = validator.Validate(validData, validTransport);
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForInvalidFullName()
        {
            validData.FullName = "12345";
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Incorrect name! Please, use letters only.", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForInvalidPhoneNumber()
        {
            validData.PhoneNumber = "abc";
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Please, enter correct phone number.", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForInvalidCardNumber()
        {
            validData.CardNumber = "1234";
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Please, enter correct card number (16 digits).", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForInvalidExpiryDateFormat()
        {
            validData.ExpiryDate = "12/25";
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Please, enter correct expiry date (dd.mm)", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForInvalidExpiryDateMonth()
        {
            validData.ExpiryDate = "15.99";
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Incorrect month in expiry date.", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForInvalidExpiryDateDay()
        {
            validData.ExpiryDate = "99.12";
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Incorrect day in expiry date.", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForInvalidCvv()
        {
            validData.Cvv = "12";
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Please, enter 3 digit CVV.", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_ForNonPositiveHours()
        {
            validData.Hours = 0;
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Please, enter positive hours quantity.", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_ReturnsFalse_IfTransportIsRented()
        {
            validTransport.Status = TransportStatus.Rented;
            var result = validator.Validate(validData, validTransport);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Sorry, this transport just have been booked.", result.ErrorMessage);
        }
    }
}