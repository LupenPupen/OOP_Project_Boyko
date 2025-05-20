using OOP_Project_Boyko.TransportRelated;
using OOP_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Interfaces
{
    public interface IDataProvider
    {
        ObservableCollection<BaseUser> LoadUsers();
        void SaveUsers(ObservableCollection<BaseUser> users);

        ObservableCollection<Transport> LoadTransports();
        void SaveTransports(ObservableCollection<Transport> transports);

        ObservableCollection<Rental> LoadRentals();
        void SaveRentals(ObservableCollection<Rental> rentals);
    }
}
