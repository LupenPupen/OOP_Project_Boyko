using OOP_Project_Boyko.RegisteredEventsArgs;
using OOP_Project_Boyko.TransportRelated;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Interfaces
{
    public interface ITransportService
    {
        ObservableCollection<Transport> Transport { get; }
        void AddTransport(Transport transport);
        void RemoveTransport(Transport transport);
        event EventHandler<TransportRegisteredEventArgs> TransportRegistered;
    }
}
