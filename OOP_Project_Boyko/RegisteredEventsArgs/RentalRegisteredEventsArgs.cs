using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.RegisteredEventsArgs
{
    public class RentalRegisteredEventArgs : EventArgs
    {
        public Rental RegisteredRental { get; }
        public RentalRegisteredEventArgs(Rental Rental)
        {
            throw new NotImplementedException();
        }
    }
}
