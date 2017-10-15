using BirthdaySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Services.Data;
using System;

namespace BirthdaySite.UnitTests.ControllerTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_ShouldInitialiseCorrectlyController()
        {
            var groupsMocked = new Mock<IGroupService>();
            var controller = new ForumController(groupsMocked.Object);

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenServiceIsNull()
        {
            var groupsMocked = new Mock<IGroupService>();
            Assert.ThrowsException<ArgumentNullException>(() =>
            new ForumController(null));
        }
    }
}
