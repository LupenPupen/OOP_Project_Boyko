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
            if (string.IsNullOrWhiteSpace(data.FullName) || !Regex.IsMatch(data.FullName, @"^[a-zA-Zа-яА-Я\s]+$"))
                return (false, "Incorrect name! Please, use letters only.");

            if (string.IsNullOrWhiteSpace(data.PhoneNumber) || !Regex.IsMatch(data.PhoneNumber, @"^\+?\d{1,3}[\s-]?\(?\d{1,4}\)?[\s-]?\d{1,4}([\s-]?\d{2,4})*$"))
                return (false, "Please, enter correct phone number.");

            string cleanCardNumber = data.CardNumber.Replace(" ", "").Replace("-", "");
            if (string.IsNullOrWhiteSpace(cleanCardNumber) || !Regex.IsMatch(cleanCardNumber, @"^\d{16}$"))
                return (false, "Please, enter correct card number (16 digits).");

            if (string.IsNullOrWhiteSpace(data.ExpiryDate) || !Regex.IsMatch(data.ExpiryDate, @"^\d{2}\.\d{2}$"))
                return (false, "Please, enter correct expiry date (dd.mm)");

            if (int.TryParse(data.ExpiryDate.Substring(3, 2), out int month) && (month < 1 || month > 12))
                return (false, "Incorrect month in expiry date.");
            if (int.TryParse(data.ExpiryDate.Substring(0, 2), out int day) && (day < 1 || day > 31))
                return (false, "Incorrect day in expiry date.");

            if (string.IsNullOrWhiteSpace(data.Cvv) || !Regex.IsMatch(data.Cvv, @"^\d{3}$"))
                return (false, "Please, enter 3 digit CVV.");

            if (data.Hours <= 0)
                return (false, "Please, enter positive hours quantity.");

            if (transport.Status == TransportStatus.Rented)
                return (false, "Sorry, this transport just have been booked.");

            return (true, string.Empty);
        }
    }
}
