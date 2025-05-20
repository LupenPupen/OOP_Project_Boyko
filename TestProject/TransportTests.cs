using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.TransportRelated;
using System;

namespace TestProject
{
    [TestClass]
    public class TransportTests
    {
        [TestMethod]
        public void DefaultConstructor_InitializesWithDefaults()
        {
            var transport = new Transport();
            Assert.IsNull(transport.Name);
            Assert.AreEqual(default(TransportType), transport.Type);
            Assert.IsNull(transport.Address);
            Assert.AreEqual(default(TransportStatus), transport.Status);
            Assert.AreEqual(0, transport.Speed);
            Assert.AreEqual(0, transport.PricePerHour);
            Assert.AreEqual(0, transport.QualityCoef);
        }

        [TestMethod]
        public void ParameterizedConstructor_SetsAllProperties()
        {
            var transport = new Transport("Bike", TransportType.Bicycle, "Main St", TransportStatus.Free, 20, 100);

            Assert.AreEqual("Bike", transport.Name);
            Assert.AreEqual(TransportType.Bicycle, transport.Type);
            Assert.AreEqual("Main St", transport.Address);
            Assert.AreEqual(TransportStatus.Free, transport.Status);
            Assert.AreEqual(20, transport.Speed);
            Assert.AreEqual(100, transport.PricePerHour);
            Assert.AreEqual(0.6, transport.QualityCoef, 0.001);
        }

        [TestMethod]
        public void Setters_ThrowArgumentException_OnInvalidValues()
        {
            var transport = new Transport();

            Assert.ThrowsException<ArgumentException>(() => transport.Name = "");
            Assert.ThrowsException<ArgumentException>(() => transport.Address = null);
            Assert.ThrowsException<ArgumentException>(() => transport.Speed = -1);
            Assert.ThrowsException<ArgumentException>(() => transport.PricePerHour = -10);
        }

        [TestMethod]
        public void QualityCoef_ReturnsZero_IfPricePerHourIsZero()
        {
            var transport = new Transport
            {
                Speed = 10,
                PricePerHour = 0
            };
            Assert.AreEqual(0, transport.QualityCoef);
        }

        [TestMethod]
        public void GetTransportDetails_ReturnsCorrectString()
        {
            var transport = new Transport("Bike", TransportType.Bicycle, "Main St", TransportStatus.Free, 15, 90);
            var details = transport.GetTransportDetails();

            StringAssert.Contains(details, "Name: Bike");
            StringAssert.Contains(details, "Type: Bicycle");
            StringAssert.Contains(details, "Address: Main St");
            StringAssert.Contains(details, "Status: Free");
            StringAssert.Contains(details, "Speed: 15");
            StringAssert.Contains(details, "Price: 90");
            StringAssert.Contains(details, "Quality Coefficient: ");
        }
    }
}