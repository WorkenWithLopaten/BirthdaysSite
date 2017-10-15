using BirthdaySite.Controllers;
using BirthdaySite.ViewModels.Friends;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests.BirthdayControllerTests
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_ShouldReturnViewWithModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        {
            var identityMocked = new Mock<IPrincipal>();
            identityMocked.Setup(m => m.Identity.Name).Returns("testUser@mail.bg");
            var friendListMocked = new Mock<IFriendListService>();
            var birthday = new DateTime(1994, 12, 15);

            var friend = new Friend()
            {
                Name = "testUser",
                Birthday = birthday,
                Gender = false
            };

            var friendViewModel = new FriendViewModel()
            {
                Name = friend.Name,
                Birthday = friend.Birthday,
                Gender = friend.Gender
            };

            friendListMocked.Setup(m => m.GetAllFriends("testUser")).Returns(
                new List<Friend>()
                {
                    friend
                });

            var controller = new BirthdaysController(friendListMocked.Object,
                identityMocked.Object);

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView()
                .WithModel<List<FriendViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.First().Name, friendViewModel.Name);
                    Assert.AreEqual(viewModel.First().Gender, friendViewModel.Gender);
                    Assert.AreEqual(viewModel.First().Birthday, friendViewModel.Birthday);
                });
        }

        [TestMethod]
        public void Index_ShouldCallGetAllFriends_Once()
        {
            var identityMocked = new Mock<IPrincipal>();
            identityMocked.Setup(m => m.Identity.Name).Returns("testUser@mail.bg");
            var friendListMocked = new Mock<IFriendListService>();
            var birthday = new DateTime(1994, 12, 15);

            var friend = new Friend()
            {
                Name = "testUser",
                Birthday = birthday,
                Gender = false
            };

            var friendViewModel = new FriendViewModel()
            {
                Name = friend.Name,
                Birthday = friend.Birthday,
                Gender = friend.Gender
            };

            friendListMocked.Setup(m => m.GetAllFriends("testUser")).Returns(
                new List<Friend>()
                {
                    friend
                });

            var controller = new BirthdaysController(friendListMocked.Object,
                identityMocked.Object);

            controller.Index();

            friendListMocked.Verify(m => m.GetAllFriends("testUser"),
                Times.Once);

        }

        [TestMethod]
        public void ReturnViewWithEmptyModel_WhenThereAreNoFriendLists()
        {
            var identityMocked = new Mock<IPrincipal>();

            identityMocked.Setup(m => m.Identity.Name).Returns("testUser@mail.bg");

            var friendListMocked = new Mock<IFriendListService>();
            var friendViewModel = new FriendViewModel();

            friendListMocked.Setup(m => m.GetAllFriends("testUser"))
                .Returns(new List<Friend>());

            var controller = new BirthdaysController(friendListMocked.Object,
                identityMocked.Object);

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView()
                .WithModel<List<FriendViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Count, 0);
                });
        }

        [TestMethod]
        public void ReturnViewWithEmptyModel_WhenParameterIsNull()
        {
            var identityMocked = new Mock<IPrincipal>();

            identityMocked.Setup(m => m.Identity.Name).Returns("");

            var friendListMocked = new Mock<IFriendListService>();
            var friendViewModel = new FriendViewModel();

            friendListMocked.Setup(m => m.GetAllFriends(""))
                .Returns(new List<Friend>());

            var controller = new BirthdaysController(friendListMocked.Object,
                identityMocked.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => controller.Index());
        }
    }
}
