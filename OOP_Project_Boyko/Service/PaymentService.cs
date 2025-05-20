using Course_Project_Boyko.Data;
using Course_Project_Boyko.Interfaces;
using Course_Project_Boyko.TransportRelated;
using Course_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Boyko.Service
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
