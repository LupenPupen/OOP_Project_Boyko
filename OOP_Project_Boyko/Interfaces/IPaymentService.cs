using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.TransportRelated;
using OOP_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Interfaces
{
    public interface IPaymentService
    {
        double CalculateTotalCost(Transport transport, int hours);
        Rental CreateRental(BaseUser user, Transport transport, PaymentData data, double totalCost);
    }
}
