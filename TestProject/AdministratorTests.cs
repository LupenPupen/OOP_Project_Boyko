using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.Users;

namespace TestProject
{
    [TestClass]
    public class AdministratorTests
    {
        [TestMethod]
        public void Constructor_SetsUsernameAndPassword()
        {
            var admin = new Administrator("adminUser", "securePass");
            Assert.AreEqual("adminUser", admin.Username);
            Assert.AreEqual("securePass", admin.Password);
        }

        [TestMethod]
        public void UserType_ReturnsAdmin()
        {
            var admin = new Administrator("admin", "pass");
            Assert.AreEqual("Admin", admin.UserType);
        }

        [TestMethod]
        public void GetGreeting_ReturnsCorrectGreeting()
        {
            var admin = new Administrator("superadmin", "pass");
            var greeting = admin.GetGreeting();
            Assert.AreEqual("Welcome, admin superadmin!", greeting);
        }
    }
}