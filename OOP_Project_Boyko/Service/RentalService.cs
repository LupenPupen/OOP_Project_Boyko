﻿using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.RegisteredEventsArgs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Service
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
            if (rental == null) return;
            Rental.Add(rental);
            RentalRegistered?.Invoke(this, new RentalRegisteredEventArgs(rental));
        }

        public void RemoveRental(Rental rental)
        {
            if (rental == null) return;
            Rental.Remove(rental);
        }
    }
}
