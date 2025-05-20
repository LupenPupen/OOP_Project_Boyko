using OOP_Project_Boyko.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Boyko.RegisteredEventsArgs
{
    public class UserRegisteredEventArgs : EventArgs
    {
        public BaseUser RegisteredUser { get; }
        public UserRegisteredEventArgs(BaseUser user)
        {
            throw new NotImplementedException();
        }
    }
}
