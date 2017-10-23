using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Models;

namespace BirthdaySite.UnitTests.ModelTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestUser()
        {
            var user = new User();

            var store = new Mock<IUserStore<User>>();
            var manager = new UserManager<User>(store.Object) ;

            var result = user.GenerateUserIdentityAsync(manager);
        }
    }
}
