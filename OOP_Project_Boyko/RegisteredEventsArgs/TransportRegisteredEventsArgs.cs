using OOP_Project_Boyko.TransportRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.RegisteredEventsArgs
{
    public class TransportRegisteredEventArgs : EventArgs
    {
        public Transport RegisteredTransport { get; }
        public TransportRegisteredEventArgs(Transport transport)
        {
            RegisteredTransport = transport;
        }
    }
}