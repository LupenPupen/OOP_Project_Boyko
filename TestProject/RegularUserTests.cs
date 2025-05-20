using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Users;

namespace TestProject
{
    [TestClass]
    public class RegularUserTests
    {
        [TestMethod]
        public void Constructor_SetsUsernameAndPassword()
        {
            var user = new RegularUser("user1", "pass1");
            Assert.AreEqual("user1", user.Username);
            Assert.AreEqual("pass1", user.Password);
        }

        [TestMethod]
        public void UserType_ReturnsRegularUser()
        {
            var user = new RegularUser("user2", "pass2");
            Assert.AreEqual("Regular user", user.UserType);
        }

        [TestMethod]
        public void GetGreeting_ReturnsCorrectGreeting()
        {
            var user = new RegularUser("Vasya", "123");
            Assert.AreEqual("Hello, Vasya!", user.GetGreeting());
        }
    }
}