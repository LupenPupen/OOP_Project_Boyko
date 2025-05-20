using System;

namespace Course_Project_Boyko.Users
{
    public class RegularUser : BaseUser
    {
        public RegularUser() : base() { }

        public RegularUser(string username, string password) : base(username, password) { }

        public override string UserType => "Regular user";
    }
}