using System.Collections.Generic;
using System.Linq;
using Moq;
using BirthdaySite.ViewModels.Forum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using TestStack.FluentMVCTesting;
using BirthdaySite.Areas.Administration.Controllers;
using BirthdaySite.ViewModels.Friends;
using System;

namespace BirthdaySite.UnitTests.ControllerTests.Tests
{
    [TestClass]
    public class GetAllFriendListsAndFriendsTests
    {
        [TestMethod]
        public void GetAllFriendListsAndFriendsTests_Should_CallMethod_GetAllFriendLists()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            var friendList = new FriendsList()
            {
                Name = "testGroup",
                Friends = new List<Friend>()
                {
                    new Friend()
                    {
                        Name = "testAuthor",
                        Gender = false
                    }
                }
            };

            friendListServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<FriendsList>()
                {
                    friendList
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller.GetAllFriendListsAndFriends();

            friendListServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetAllFriendListsAndFriendsTests_Should_RenderCorrectView_WithCorrectParameters()
        {

            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();
            var birthday = new DateTime(1994, 5, 5);

            var friendList = new FriendsList()
            {
                Name = "testFriendList",
                Friends = new List<Friend>()
                {
                    new Friend()
                    {
                        Name = "testAuthor",
                        Birthday = birthday,
                        Gender = false
                    }
                }
            };

            var friendListViewModel = new FriendsViewModel();

            friendListViewModel.Name = "testFriendList";
            friendListViewModel.Friends = new List<FriendViewModel>()
            {
                new FriendViewModel()
                {
                    Name = "testAuthor",
                    Gender = false,
                    Birthday = birthday
                }
            };


            friendListServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<FriendsList>()
                {
                    friendList
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller
                .WithCallTo(m => m.GetAllFriendListsAndFriends())
                .ShouldRenderDefaultView()
                .WithModel<List<FriendsViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.First().Name,
                        friendListViewModel.Name);

                    Assert.AreEqual(viewModel.First().Friends.Count, 1);

                    Assert.AreEqual(viewModel.First().Friends.First()
                        .Birthday, friendListViewModel.Friends.First().Birthday);

                    Assert.AreEqual(viewModel.First().Friends.First()
                        .Name, friendListViewModel.Friends.First().Name);

                    Assert.AreEqual(viewModel.First().Friends.First()
                        .Gender, friendListViewModel.Friends.First().Gender);
                });
        }

        [TestMethod]
        public void GetAllFriendListsAndFriendsTests_Should_RenderViewWithNullParameters_WhenThereAreNoSuch()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            friendListServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<FriendsList>());

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller
                .WithCallTo(m => m.GetAllFriendListsAndFriends())
                .ShouldRenderDefaultView()
                .WithModel<List<FriendsViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Count, 0);
                });
        }
    }
}

