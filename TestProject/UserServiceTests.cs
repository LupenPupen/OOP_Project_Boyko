using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Service;
using OOP_Project_Boyko.Users;
using System.Collections.ObjectModel;
using OOP_Project_Boyko.RegisteredEventsArgs;
using System;

namespace TestProject
{
    [TestClass]
    public class UserServiceTests
    {
        private ObservableCollection<BaseUser> users;
        private UserService service;

        [TestInitialize]
        public void Setup()
        {
            users = new ObservableCollection<BaseUser>();
            service = new UserService(users);
        }

        [TestMethod]
        public void AddUser_AddsUserToCollection()
        {
            var user = new Administrator("admin", "1234");
            service.AddUser(user);

            Assert.AreEqual(1, users.Count);
            Assert.AreEqual(user, users[0]);
        }

        [TestMethod]
        public void AddUser_DoesNotAddNull()
        {
            service.AddUser(null);
            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        public void RemoveUser_RemovesUserFromCollection()
        {
            var user = new RegularUser("user1", "pass1");
            users.Add(user);

            service.RemoveUser(user);

            Assert.AreEqual(0, users.Count);
        }

        [TestMethod]
        public void RemoveUser_DoesNotThrowOnNull()
        {
            users.Add(new RegularUser("user1", "pass1"));
            service.RemoveUser(null);
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void AddUser_RaisesUserRegisteredEvent()
        {
            var user = new RegularUser("user2", "pass2");
            UserRegisteredEventArgs eventArgs = null;
            service.UserRegistered += (s, e) => eventArgs = e;

            service.AddUser(user);

            Assert.IsNotNull(eventArgs);
            Assert.AreEqual(user, eventArgs.RegisteredUser);
        }
    }
}