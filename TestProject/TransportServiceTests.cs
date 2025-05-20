using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko.TransportRelated;
using System.Collections.ObjectModel;
using OOP_Project_Boyko.RegisteredEventsArgs;
using System;

namespace TestProject
{
    [TestClass]
    public class TransportServiceTests
    {
        private ObservableCollection<Transport> transports;
        private TransportService service;

        [TestInitialize]
        public void Setup()
        {
            transports = new ObservableCollection<Transport>();
            service = new TransportService(transports);
        }

        [TestMethod]
        public void AddTransport_AddsTransportToCollection()
        {
            var transport = new Transport
            {
                Name = "Bike",
                Type = TransportType.Bicycle,
                Status = TransportStatus.Free,
                PricePerHour = 75,
                Speed = 20,
            };

            service.AddTransport(transport);

            Assert.AreEqual(1, transports.Count);
            Assert.AreEqual(transport, transports[0]);
        }

        [TestMethod]
        public void AddTransport_DoesNotAddNull()
        {
            service.AddTransport(null);
            Assert.AreEqual(0, transports.Count);
        }

        [TestMethod]
        public void RemoveTransport_RemovesTransportFromCollection()
        {
            var transport = new Transport { Name = "Bike" };
            transports.Add(transport);

            service.RemoveTransport(transport);

            Assert.AreEqual(0, transports.Count);
        }

        [TestMethod]
        public void RemoveTransport_DoesNotThrowOnNull()
        {
            transports.Add(new Transport { Name = "Bike" });
            service.RemoveTransport(null);
            Assert.AreEqual(1, transports.Count);
        }

        [TestMethod]
        public void AddTransport_RaisesTransportRegisteredEvent()
        {
            var transport = new Transport { Name = "Bike" };
            TransportRegisteredEventArgs eventArgs = null;
            service.TransportRegistered += (s, e) => eventArgs = e;

            service.AddTransport(transport);

            Assert.IsNotNull(eventArgs);
            Assert.AreEqual(transport, eventArgs.RegisteredTransport);
        }

        [TestMethod]
        public void FindBestFreeTransport_ReturnsBestByQualityCoef()
        {
            var t1 = new Transport { Name = "T1", Type = TransportType.Bicycle, Status = TransportStatus.Free, PricePerHour = 10, Speed = 15,};
            var t2 = new Transport { Name = "T2", Type = TransportType.Bicycle, Status = TransportStatus.Free, PricePerHour = 33, Speed = 110,};
            var t3 = new Transport { Name = "T3", Type = TransportType.Bicycle, Status = TransportStatus.Rented, PricePerHour = 20, Speed = 60,};
            transports.Add(t1);
            transports.Add(t2);
            transports.Add(t3);

            var best = service.FindBestFreeTransport(TransportType.Bicycle);

            Assert.AreEqual(t2, best);
        }

        [TestMethod]
        public void FindBestFreeTransport_ReturnsNullIfNoneFree()
        {
            var t1 = new Transport { Name = "T1", Type = TransportType.Bicycle, Status = TransportStatus.Rented, PricePerHour = 20, Speed = 30, };
            transports.Add(t1);

            var best = service.FindBestFreeTransport(TransportType.Bicycle);

            Assert.IsNull(best);
        }
    }
}