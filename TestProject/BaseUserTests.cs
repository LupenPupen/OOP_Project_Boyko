using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Users;
using System;

namespace TestProject
{
    public class TestUser : BaseUser
    {
        public TestUser() : base() { }
        public TestUser(string username, string password) : base(username, password) { }
        public override string UserType => "Test";
    }

    [TestClass]
    public class BaseUserTests
    {
        [TestMethod]
        public void Constructor_SetsUsernameAndPassword()
        {
            var user = new TestUser("user1", "pass1");
            Assert.AreEqual("user1", user.Username);
            Assert.AreEqual("pass1", user.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Username_ThrowsIfEmpty()
        {
            var user = new TestUser();
            user.Username = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Username_ThrowsIfNull()
        {
            var user = new TestUser();
            user.Username = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Password_ThrowsIfEmpty()
        {
            var user = new TestUser();
            user.Password = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Password_ThrowsIfNull()
        {
            var user = new TestUser();
            user.Password = null;
        }

        [TestMethod]
        public void GetGreeting_ReturnsCorrectGreeting()
        {
            var user = new TestUser("Vasya", "123");
            Assert.AreEqual("Hello, Vasya!", user.GetGreeting());
        }

        [TestMethod]
        public void UserType_ReturnsTest()
        {
            var user = new TestUser("test", "test");
            Assert.AreEqual("Test", user.UserType);
        }
    }
}