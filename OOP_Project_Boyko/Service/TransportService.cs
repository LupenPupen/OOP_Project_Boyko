using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.RegisteredEventsArgs;
using OOP_Project_Boyko.TransportRelated;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Service
{
    public class TransportService : ITransportService
    {
        public ObservableCollection<Transport> Transport { get; }

        public event EventHandler<TransportRegisteredEventArgs> TransportRegistered;

        public TransportService(ObservableCollection<Transport> transport)
        {
            Transport = transport;
        }

        public void AddTransport(Transport transport)
        {
            if (transport == null) return;
            Transport.Add(transport);
            TransportRegistered?.Invoke(this, new TransportRegisteredEventArgs(transport));
        }

        public void RemoveTransport(Transport transport)
        {
            if (transport == null) return;
            Transport.Remove(transport);
        }

        public Transport FindBestFreeTransport(TransportType type)
        {
            return Transport
                .Where(t => t.Type == type && t.Status == TransportStatus.Free)
                .OrderByDescending(t => t.QualityCoef)
                .FirstOrDefault();
        }
    }
}
