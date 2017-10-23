using Moq;
using MVCTemplate.Services.Data;
using BirthdaySite.Areas.Administration.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MVCTemplate.Data.Models;
using BirthdaySite.ViewModels.AdminViewModel;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.Controller.Tests
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_ShouldCall_GetAllGroups_Once()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            groupsServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>()
                {
                    new Group()
                    {
                        Messages = new List<Message>()
                        {
                            new Message()
                            {

                            },
                            new Message()
                            {

                            }
                        }
                    }
                });

            friendListServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<FriendsList>()
                {
                    new FriendsList()
                    {
                        Friends = new List<Friend>()
                        {
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            }
                        }
                    }
                });

            userServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<User>()
                {
                    new User()
                    {

                    },
                    new User()
                    {

                    }
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
                friendListServiceMocked.Object, userServiceMocked.Object);

            controller.Index();

            groupsServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Index_ShouldCall_GetAllUsers_Once()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            groupsServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>()
                {
                    new Group()
                    {
                        Messages = new List<Message>()
                        {
                            new Message()
                            {

                            },
                            new Message()
                            {

                            }
                        }
                    }
                });

            friendListServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<FriendsList>()
                {
                    new FriendsList()
                    {
                        Friends = new List<Friend>()
                        {
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            }
                        }
                    }
                });

            userServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<User>()
                {
                    new User()
                    {

                    },
                    new User()
                    {

                    }
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
                friendListServiceMocked.Object, userServiceMocked.Object);

            controller.Index();

           userServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Index_ShouldCall_GetAllFriendLists_Once()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            groupsServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>()
                {
                    new Group()
                    {
                        Messages = new List<Message>()
                        {
                            new Message()
                            {

                            },
                            new Message()
                            {

                            }
                        }
                    }
                });

            friendListServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<FriendsList>()
                {
                    new FriendsList()
                    {
                        Friends = new List<Friend>()
                        {
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            }
                        }
                    }
                });

            userServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<User>()
                {
                    new User()
                    {

                    },
                    new User()
                    {

                    }
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
                friendListServiceMocked.Object, userServiceMocked.Object);

            controller.Index();

            friendListServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Index_ShouldRender_ViewWithCorrectParameters()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            groupsServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>()
                {
                    new Group()
                    {
                        Messages = new List<Message>()
                        {
                            new Message()
                            {

                            },
                            new Message()
                            {

                            }
                        }
                    }
                });

            friendListServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<FriendsList>()
                {
                    new FriendsList()
                    {
                        Friends = new List<Friend>()
                        {
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            },
                            new Friend()
                            {

                            }
                        }
                    }
                });

            userServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<User>()
                {
                    new User()
                    {

                    },
                    new User()
                    {

                    }
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
                friendListServiceMocked.Object, userServiceMocked.Object);

            var adminViewModel = new AdminDataInitalViewModel();

            adminViewModel.FriendListsCount = 1;
            adminViewModel.GroupsCount = 1;
            adminViewModel.MessagesCount = 2;
            adminViewModel.UsersCount = 2;
            adminViewModel.FriendsCount = 3;

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView()
                .WithModel<AdminDataInitalViewModel>(viewModel =>
                {
                    Assert.AreEqual(viewModel.MessagesCount, adminViewModel.MessagesCount);
                    Assert.AreEqual(viewModel.GroupsCount, adminViewModel.GroupsCount);
                    Assert.AreEqual(viewModel.UsersCount, adminViewModel.UsersCount);
                    Assert.AreEqual(viewModel.FriendsCount, adminViewModel.FriendsCount);
                    Assert.AreEqual(viewModel.FriendListsCount, adminViewModel.FriendListsCount);
                });
        }
    }
}
