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
            throw new NotImplementedException();
        }

        public Rental(string userName, string transportName, TransportType transportType, int hours, double totalCost, string fullName, string phoneNumber, string cardNumber, string expiryDate, string cvv)
        {
            throw new NotImplementedException();
        }

        public string UserName
        {
            get => _userName;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string TransportName
        {
            get => _transportName;
            set
            {
                throw new NotImplementedException();
            }
        }

        public TransportType Type
        {
            get => _transportType;
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Hours
        {
            get => _hours;
            set
            {
                throw new NotImplementedException();
            }
        }

        public double TotalCost
        {
            get => _totalCost;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ExpiryDate
        {
            get => _expiryDate;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Cvv
        {
            get => _cvv;
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}