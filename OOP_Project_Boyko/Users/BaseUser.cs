using System;
using System.Text.Json.Serialization;

namespace OOP_Project_Boyko.Users
{
    [JsonDerivedType(typeof(RegularUser), typeDiscriminator: "RegularUser")]
    [JsonDerivedType(typeof(Administrator), typeDiscriminator: "Administrator")]
    public abstract class BaseUser
    {
        private string _username;
        private string _password;

        public BaseUser() { throw new NotImplementedException(); }

        public BaseUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string Username
        {
            get => _username;
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                throw new NotImplementedException();
            }
        }

        [JsonIgnore]
        public abstract string UserType { get; }

        public virtual string GetGreeting()
        {
            throw new NotImplementedException();
        }
    }
}