using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.RegisteredEventsArgs;
using OOP_Project_Boyko.TransportRelated;

namespace TestProject
{
    [TestClass]
    public class TransportRegisteredEventsArgsTests
    {
        [TestMethod]
        public void Constructor_SetsRegisteredTransport()
        {
            var transport = new Transport
            {
                Name = "Bike",
                Type = TransportType.Bicycle,
                Status = TransportStatus.Free,
                PricePerHour = 100
            };

            var args = new TransportRegisteredEventArgs(transport);

            Assert.AreEqual(transport, args.RegisteredTransport);
        }
    }
}