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
            if (user == null) return;
            Users.Add(user);
            UserRegistered?.Invoke(this, new UserRegisteredEventArgs(user));
        }

        public void RemoveUser(BaseUser user)
        {
            if (user == null) return;
            Users.Remove(user);
        }
    }
}
