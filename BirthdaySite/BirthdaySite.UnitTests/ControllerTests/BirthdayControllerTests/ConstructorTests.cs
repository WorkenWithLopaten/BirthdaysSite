using BirthdaySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Services.Data;
using System;

namespace BirthdaySite.UnitTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeCorretly()
        {
            var service = new Mock<IFriendListService>();
            var controller = new BirthdaysController(service.Object);

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Constructor_Throw_WhenServiceIsNull()
        {
            var service = new Mock<IFriendListService>();
            Assert.ThrowsException<ArgumentNullException>(() => new BirthdaysController(null));
        }
    }
}
