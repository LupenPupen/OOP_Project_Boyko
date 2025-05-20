using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project_Boyko.RegisteredEventsArgs;
using OOP_Project_Boyko.Users;

namespace TestProject
{
    [TestClass]
    public class UserRegisteredEventsArgsTests
    {
        [TestMethod]
        public void Constructor_SetsRegisteredUser()
        {
            var user = new Administrator("admin", "1234");
            var args = new UserRegisteredEventArgs(user);

            Assert.AreEqual(user, args.RegisteredUser);
        }

        [TestMethod]
        public void RegisteredUser_CanBeNull()
        {
            var args = new UserRegisteredEventArgs(null);
            Assert.IsNull(args.RegisteredUser);
        }
    }
}