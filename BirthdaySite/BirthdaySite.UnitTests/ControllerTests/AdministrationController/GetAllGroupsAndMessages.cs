using System.Collections.Generic;
using System.Linq;
using Moq;
using BirthdaySite.ViewModels.Forum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using TestStack.FluentMVCTesting;
using BirthdaySite.Areas.Administration.Controllers;

namespace BirthdaySite.UnitTests.ControllerTests.Tests
{
    [TestClass]
    public class GetAllGroupsAndMessages
    {
        [TestMethod]
        public void GetAllGroupsAndMessages_Should_CallMethod_GetAllGroups()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            var group = new Group()
            {
                Name = "testGroup",
                Messages = new List<Message>()
                {
                    new Message()
                    {
                        Author = "testAuthor",
                        Content = "testContent"
                    }
                }
            };

            groupsServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>()
                {
                    group
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller.GetAllGroupsAndMessages();

            groupsServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetAllGroupsAndMessages_Should_RenderCorrectView_WithCorrectParameters()
        {

            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            var group = new Group()
            {
                Name = "testGroup",
                Messages = new List<Message>()
                {
                    new Message()
                    {
                        Author = "testAuthor",
                        Content = "testContent"
                    }
                }
            };

            var groupViewModel = new GroupViewModel();

            groupViewModel.Name = "testGroup";
            groupViewModel.Messages = new List<MessageViewModel>()
            {
                new MessageViewModel()
                {
                    Author = "testAuthor",
                    Content = "testContent"
                }
            };


            groupsServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>()
                {
                    group
                });

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller
                .WithCallTo(m => m.GetAllGroupsAndMessages())
                .ShouldRenderDefaultView()
                .WithModel<List<GroupViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.First().Name,
                        groupViewModel.Name);

                    Assert.AreEqual(viewModel.First().Messages.First().Content,
                        groupViewModel.Messages.First().Content);

                    Assert.AreEqual(viewModel.First().Messages.First().Author,
                        groupViewModel.Messages.First().Author);
                });
        }

        [TestMethod]
        public void GetAllGroupsAndMessages_Should_RenderViewWithNullParameters_WhenThereAreNoSuch()
        {
            var userServiceMocked = new Mock<IUserService>();
            var groupsServiceMocked = new Mock<IGroupService>();
            var friendListServiceMocked = new Mock<IFriendListService>();

            groupsServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>());

            var controller = new AdministrationController(groupsServiceMocked.Object,
               friendListServiceMocked.Object, userServiceMocked.Object);

            controller
                .WithCallTo(m => m.GetAllGroupsAndMessages())
                .ShouldRenderDefaultView()
                .WithModel<List<GroupViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Count, 0);
                });
        }
    }
}

