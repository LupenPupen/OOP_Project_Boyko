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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be empty.");
                _username = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password cannot be empty.");
                _password = value;
            }
        }

        [JsonIgnore]
        public abstract string UserType { get; }

        public virtual string GetGreeting()
        {
            return $"Hello, {Username}!";
        }
    }
}