using Course_Project_Boyko.RegisteredEventsArgs;
using Course_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Boyko
{
    public interface IUserService
    {
        ObservableCollection<BaseUser> Users { get; }
        void AddUser(BaseUser user);
        void RemoveUser(BaseUser user);
        event EventHandler<UserRegisteredEventArgs> UserRegistered;
    }
}
