using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Data;

namespace TestProject
{
    [TestClass]
    public class PaymentDataTests
    {
        [TestMethod]
        public void CanSetAndGetProperties()
        {
            var payment = new PaymentData
            {
                FullName = "Иван Иванов",
                PhoneNumber = "1234567890",
                CardNumber = "1111222233334444",
                ExpiryDate = "12/25",
                Cvv = "123",
                Hours = 5
            };

            Assert.AreEqual("Иван Иванов", payment.FullName);
            Assert.AreEqual("1234567890", payment.PhoneNumber);
            Assert.AreEqual("1111222233334444", payment.CardNumber);
            Assert.AreEqual("12/25", payment.ExpiryDate);
            Assert.AreEqual("123", payment.Cvv);
            Assert.AreEqual(5, payment.Hours);
        }

        [TestMethod]
        public void DefaultValues_AreNullOrZero()
        {
            var payment = new PaymentData();
            Assert.IsNull(payment.FullName);
            Assert.IsNull(payment.PhoneNumber);
            Assert.IsNull(payment.CardNumber);
            Assert.IsNull(payment.ExpiryDate);
            Assert.IsNull(payment.Cvv);
            Assert.AreEqual(0, payment.Hours);
        }
    }
}