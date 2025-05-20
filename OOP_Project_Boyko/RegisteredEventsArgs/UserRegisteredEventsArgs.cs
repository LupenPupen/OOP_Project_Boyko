using Course_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Boyko.RegisteredEventsArgs
{
    public class UserRegisteredEventArgs : EventArgs
    {
        public BaseUser RegisteredUser { get; }
        public UserRegisteredEventArgs(BaseUser user)
        {
            RegisteredUser = user;
        }
    }
}
