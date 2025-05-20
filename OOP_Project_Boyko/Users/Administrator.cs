using System;

namespace Course_Project_Boyko.Users
{
    public class Administrator : BaseUser
    {
        public Administrator(string username, string password) : base(username, password) { }

        public override string UserType => "Admin";

        public override string GetGreeting()
        {
            throw new NotImplementedException();
        }
    }
}