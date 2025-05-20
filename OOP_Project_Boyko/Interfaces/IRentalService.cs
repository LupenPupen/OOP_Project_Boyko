using OOP_Project_Boyko.RegisteredEventsArgs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Interfaces
{
    public interface IRentalService
    {
        ObservableCollection<Rental> Rental { get; }
        void AddRental(Rental rental);
        void RemoveRental(Rental rental);
        event EventHandler<RentalRegisteredEventArgs> RentalRegistered;
    }
}
