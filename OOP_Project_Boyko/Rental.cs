using Course_Project_Boyko.TransportRelated;
using System;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Course_Project_Boyko
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
                
            }
        }

        public string TransportName
        {
            get => _transportName;
            set
            {
                
            }
        }

        public TransportType Type
        {
            get => _transportType;
            set
            {
                
            }
        }

        public int Hours
        {
            get => _hours;
            set
            {
                
            }
        }

        public double TotalCost
        {
            get => _totalCost;
            set
            {
                
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                
            }
        }

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                
            }
        }

        public string ExpiryDate
        {
            get => _expiryDate;
            set
            {
                
            }
        }

        public string Cvv
        {
            get => _cvv;
            set
            {
                
            }
        }
    }
}