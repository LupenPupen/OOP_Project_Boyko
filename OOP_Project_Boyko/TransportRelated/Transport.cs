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

        public Transport() { throw new NotImplementedException(); }

        public Transport(string name, TransportType type, string address, TransportStatus status, double speed, double pricePerHour)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get => _name;
            set
            {
                throw new NotImplementedException();
            }
        }

        public TransportType Type
        {
            get => _type;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                throw new NotImplementedException();
            }
        }

        public TransportStatus Status
        {
            get => _status;
            set
            {
                throw new NotImplementedException();
            }
        }

        public double Speed
        {
            get => _speed;
            set
            {
                throw new NotImplementedException();
            }
        }

        public double PricePerHour
        {
            get => _pricePerHour;
            set
            {
                throw new NotImplementedException();
            }
        }

        public double QualityCoef => throw new NotImplementedException();

        public virtual string GetTransportDetails()
        {
            throw new NotImplementedException();
        }
    }
}