using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.TransportRelated;
using OOP_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Service
{
    public class PaymentService : IPaymentService
    {
        public double CalculateTotalCost(Transport transport, int hours)
        {
            throw new NotImplementedException();
        }

        public Rental CreateRental(BaseUser user, Transport transport, PaymentData data, double totalCost)
        {
            throw new NotImplementedException();
        }
    }
}
