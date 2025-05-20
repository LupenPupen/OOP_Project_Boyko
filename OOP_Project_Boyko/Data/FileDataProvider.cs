using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Course_Project_Boyko.Interfaces;
using Course_Project_Boyko.Users;
using Course_Project_Boyko.TransportRelated;

namespace Course_Project_Boyko.Data
{
    public class FileDataProvider : IDataProvider
    {
        private readonly string usersFile;
        private readonly string transportsFile;
        private readonly string rentalsFile;

        public FileDataProvider(string usersFile, string transportsFile, string rentalsFile)
        {
            this.usersFile = usersFile;
            this.transportsFile = transportsFile;
            this.rentalsFile = rentalsFile;
        }

        public ObservableCollection<BaseUser> LoadUsers()
        {
            throw new NotImplementedException();
        }

        public void SaveUsers(ObservableCollection<BaseUser> users)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Transport> LoadTransports()
        {
            throw new NotImplementedException();
        }

        public void SaveTransports(ObservableCollection<Transport> transports)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Rental> LoadRentals()
        {
            throw new NotImplementedException();
        }

        public void SaveRentals(ObservableCollection<Rental> rentals)
        {
            throw new NotImplementedException();
        }
    }
}
