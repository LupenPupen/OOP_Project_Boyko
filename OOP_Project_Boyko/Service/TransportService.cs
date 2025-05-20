using Course_Project_Boyko.Interfaces;
using Course_Project_Boyko.RegisteredEventsArgs;
using Course_Project_Boyko.TransportRelated;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Boyko.Service
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
            throw new NotImplementedException();
        }

        public void RemoveTransport(Transport transport)
        {
            throw new NotImplementedException();
        }

        public Transport FindBestFreeTransport(TransportType type)
        {
            throw new NotImplementedException();
        }
    }
}
