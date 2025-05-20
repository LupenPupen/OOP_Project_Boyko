using OOP_Project_Boyko.Data;
using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.TransportRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_Project_Boyko
{
    public class PaymentValidator : IPaymentValidator
    {
        public (bool IsValid, string ErrorMessage) Validate(PaymentData data, Transport transport)
        {
            throw new NotImplementedException();
        }
    }
}
