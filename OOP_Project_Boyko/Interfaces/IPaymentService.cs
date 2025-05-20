using Course_Project_Boyko.Data;
using Course_Project_Boyko.TransportRelated;
using Course_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Boyko.Interfaces
{
    public interface IPaymentService
    {
        double CalculateTotalCost(Transport transport, int hours);
        Rental CreateRental(BaseUser user, Transport transport, PaymentData data, double totalCost);
    }
}
