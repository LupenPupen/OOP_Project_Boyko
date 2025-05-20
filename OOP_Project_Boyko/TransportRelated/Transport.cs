using System;
using System.Text.Json.Serialization;

namespace Course_Project_Boyko.TransportRelated
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
                
            }
        }

        public double PricePerHour
        {
            get => _pricePerHour;
            set
            {
                
            }
        }

        public double QualityCoef => PricePerHour > 0 ? Speed * 3 / PricePerHour : 0;

        public virtual string GetTransportDetails()
        {
            throw new NotImplementedException();
        }
    }
}