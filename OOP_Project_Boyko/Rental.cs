using OOP_Project_Boyko.TransportRelated;
using System;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace OOP_Project_Boyko
{
    public class Rental
    {
        private string _userName;
        private string _transportName;
        private TransportType _transportType;
        private int _hours;
        private double _totalCost;
        private string _fullName;
        private string _phoneNumber;
        private string _cardNumber;
        private string _expiryDate;
        private string _cvv;

        public Rental()
        {
            _userName = string.Empty;
            _transportName = string.Empty;
            _fullName = string.Empty;
            _phoneNumber = string.Empty;
            _cardNumber = string.Empty;
            _expiryDate = string.Empty;
            _cvv = string.Empty;
        }

        public Rental(string userName, string transportName, TransportType transportType, int hours, double totalCost, string fullName, string phoneNumber, string cardNumber, string expiryDate, string cvv)
        {
            UserName = userName;
            TransportName = transportName;
            _transportType = transportType;
            Hours = hours;
            TotalCost = totalCost;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            Cvv = cvv;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be empty.");
                _userName = value;
            }
        }

        public string TransportName
        {
            get => _transportName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Transport name cannot be empty.");
                _transportName = value;
            }
        }

        public TransportType Type
        {
            get => _transportType;
            set
            {
                _transportType = value;
            }
        }

        public int Hours
        {
            get => _hours;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Rental hours must be greater than zero.");
                _hours = value;
            }
        }

        public double TotalCost
        {
            get => _totalCost;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total cost cannot be negative.");
                _totalCost = value;
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be empty.");
                if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]+$"))
                    throw new ArgumentException("Full name must contain only letters and spaces.");
                _fullName = value;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone number cannot be empty.");
                if (!Regex.IsMatch(value, @"^\+?[\d\s\-]+$"))
                    throw new ArgumentException("Invalid phone number format.");
                _phoneNumber = value;
            }
        }

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Card number cannot be empty.");
                if (!Regex.IsMatch(value.Replace(" ", "").Replace("-", ""), @"^\d{16}$"))
                    throw new ArgumentException("Card number must be 16 digits.");
                _cardNumber = value;
            }
        }

        public string ExpiryDate
        {
            get => _expiryDate;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Expiry date cannot be empty.");
                // Check for dd.mm format
                if (!Regex.IsMatch(value, @"^\d{2}\.\d{2}$"))
                    throw new ArgumentException("Expiry date must be in dd.mm format.");
                _expiryDate = value;
            }
        }

        public string Cvv
        {
            get => _cvv;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CVV cannot be empty.");
                if (!Regex.IsMatch(value, @"^\d{3}$"))
                    throw new ArgumentException("CVV must be 3 digits.");
                _cvv = value;
            }
        }
    }
}