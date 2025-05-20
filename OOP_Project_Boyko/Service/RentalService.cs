using Course_Project_Boyko.Interfaces;
using Course_Project_Boyko.RegisteredEventsArgs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Boyko.Service
{
    public class RentalService : IRentalService
    {
        public ObservableCollection<Rental> Rental { get; }

        public event EventHandler<RentalRegisteredEventArgs> RentalRegistered;

        public RentalService(ObservableCollection<Rental> rental)
        {
            Rental = rental;
        }

        public void AddRental(Rental rental)
        {
            throw new NotImplementedException();
        }

        public void RemoveRental(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
