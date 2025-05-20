using System;
using System.Text.Json.Serialization;

namespace OOP_Project_Boyko.TransportRelated
{
    public class Transport
    {
        private string _name;
        private TransportType _type;
        private string _address;
        private TransportStatus _status;
        private double _speed;
        private double _pricePerHour;

        public Transport() { }

        public Transport(string name, TransportType type, string address, TransportStatus status, double speed, double pricePerHour)
        {
            Name = name;
            Type = type;
            Address = address;
            Status = status;
            Speed = speed;
            PricePerHour = pricePerHour;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Transport name cannot be empty.");
                _name = value;
            }
        }

        public TransportType Type
        {
            get => _type;
            set => _type = value;
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Transport address cannot be empty.");
                _address = value;
            }
        }

        public TransportStatus Status
        {
            get => _status;
            set => _status = value;
        }

        public double Speed
        {
            get => _speed;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Speed cannot be negative.");
                _speed = value;
            }
        }

        public double PricePerHour
        {
            get => _pricePerHour;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price per hour cannot be negative.");
                _pricePerHour = value;
            }
        }

        public double QualityCoef => PricePerHour > 0 ? Speed * 3 / PricePerHour : 0;

        public virtual string GetTransportDetails()
        {
            return $"Name: {Name}, Type: {Type}, Address: {Address}, Status: {Status}, Speed: {Speed} km/h, Price: {PricePerHour} UAH/h, Quality Coefficient: {QualityCoef:F2}";
        }
    }
}