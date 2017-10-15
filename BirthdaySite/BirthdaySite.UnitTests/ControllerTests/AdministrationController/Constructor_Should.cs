using BirthdaySite.Areas.Administration.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Services.Data;
using System;

namespace BirthdaySite.UnitTests.ControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Constructor_Should_InitializeCorrectly()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            var controller = new AdministrationController(groupsServiceMocked.Object,
                friendListServiceMocked.Object, userServiceMocked.Object);

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenGroupsAreNull()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
            new AdministrationController(null, friendListServiceMocked.Object,
            userServiceMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenFriendListsAreNull()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
            new AdministrationController(groupsServiceMocked.Object, null,
            userServiceMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenUsersAreNull()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
            new AdministrationController(groupsServiceMocked.Object, friendListServiceMocked.Object,
            null));
        }
    }
}
