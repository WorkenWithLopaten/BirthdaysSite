using BirthdaySite.Areas.Administration.Controllers;
using BirthdaySite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;
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
                .Returns(new List<User>());

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
                .Returns(new List<User>());

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller.WithCallTo(m => m.GetAllUsers())
                .ShouldRenderDefaultView()
                .WithModel<List<LoginViewModel>>();
        }

        [TestMethod]
        public void GetAllUsers_Should_RendersCorrectViewModel_CorrectValues()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            var user = new User()
            {
                Email = "test",
                PasswordHash = "1234"
            };

            userServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<User>() { user });

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller.WithCallTo(m => m.GetAllUsers())
                .ShouldRenderDefaultView()
                .WithModel<List<LoginViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.First().Email, "test");
                    Assert.AreEqual(viewModel.First().Password, "1234");
                });
        }
    }
}
