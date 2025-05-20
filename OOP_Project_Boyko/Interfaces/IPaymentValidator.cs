using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.TransportRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Interfaces
{
    public interface IPaymentValidator
    {
        (bool IsValid, string ErrorMessage) Validate(PaymentData data, Transport transport);
    }
}
