using BirthdaySite.Areas.Administration.Controllers;
using BirthdaySite.Data.Models;
using BirthdaySite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests.Tests
{
    [TestClass]
    public class GetAllUsersTests
    {
        [TestMethod]
        public void GetAllUsers_Should_Call_UsersGetAllOnce()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            userServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<ApplicationUser>());

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller.GetAllUsers();

            userServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetAllUsers_Should_RendersCorrectViewWithCorrectViewModel()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            userServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<ApplicationUser>());

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller.WithCallTo(m => m.GetAllUsers())
                .ShouldRenderDefaultView()
                .WithModel<List<LoginViewModel>>();
        }
    }
}
