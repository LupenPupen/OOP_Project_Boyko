using OOP_Project_Boyko.RegisteredEventsArgs;
using OOP_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.Service
{
    public class UserService : IUserService
    {
        public ObservableCollection<BaseUser> Users { get; }

        public event EventHandler<UserRegisteredEventArgs> UserRegistered;

        public UserService(ObservableCollection<BaseUser> users)
        {
            Users = users;
        }

        public void AddUser(BaseUser user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(BaseUser user)
        {
            throw new NotImplementedException();
        }
    }
}
