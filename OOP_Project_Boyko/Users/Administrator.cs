using System;

namespace OOP_Project_Boyko.Users
{
    public class Administrator : BaseUser
    {
        public Administrator(string username, string password) : base(username, password) { throw new NotImplementedException(); }

        public override string UserType => throw new NotImplementedException();

        public override string GetGreeting()
        {
            throw new NotImplementedException();
        }
    }
}