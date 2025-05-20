using System;
using System.Text.Json.Serialization;

namespace Course_Project_Boyko.Users
{
    [JsonDerivedType(typeof(RegularUser), typeDiscriminator: "RegularUser")]
    [JsonDerivedType(typeof(Administrator), typeDiscriminator: "Administrator")]
    public abstract class BaseUser
    {
        private string _username;
        private string _password;

        public BaseUser() { }

        public BaseUser(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username
        {
            get => _username;
            set
            {
                
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                
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