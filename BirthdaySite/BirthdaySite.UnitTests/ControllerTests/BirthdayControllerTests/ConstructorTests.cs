using BirthdaySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Services.Data;
using System;
using System.Security.Principal;

namespace BirthdaySite.UnitTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeCorretly()
        {
            var serviceMocked = new Mock<IFriendListService>();
            var identityMocked = new Mock<IPrincipal>();
            var controller = new BirthdaysController(serviceMocked.Object, identityMocked.Object);

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Constructor_Throw_WhenServiceIsNull()
        {
            var identityMocked = new Mock<IPrincipal>();
            Assert.ThrowsException<ArgumentNullException>(()
                => new BirthdaysController(null, identityMocked.Object));
        }

        [TestMethod]
        public void Constructor_Throw_WhenPrincipalIsNull()
        {
            var serviceMocked = new Mock<IFriendListService>();
            Assert.ThrowsException<ArgumentNullException>(()
                => new BirthdaysController(serviceMocked.Object, null));
        }
    }
}
