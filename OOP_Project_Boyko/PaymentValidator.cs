using Course_Project_Boyko.Data;
using Course_Project_Boyko.Interfaces;
using Course_Project_Boyko.TransportRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Course_Project_Boyko
{
    public class PaymentValidator : IPaymentValidator
    {
        public (bool IsValid, string ErrorMessage) Validate(PaymentData data, Transport transport)
        {
            throw new NotImplementedException();
        }
    }
}
