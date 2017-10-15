using BirthdaySite.Controllers;
using BirthdaySite.ViewModels.Forum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_Should_CallMethod_GetAllGroups()
        {
            var groupServiceMocked = new Mock<IGroupService>();

            var groupViewModel = new GroupViewModel();

            groupServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>());

            var controller = new ForumController(groupServiceMocked.Object);

            controller.Index();

            groupServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Index_Should_RenderCorrectView_WithCorrectParameters()
        {
            var groupServiceMocked = new Mock<IGroupService>();

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


            groupServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>()
                {
                    group
                });

            var controller = new ForumController(groupServiceMocked.Object);

            controller
                .WithCallTo(m => m.Index())
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
        public void Index_Should_RenderViewWithNullParameters_WhenThereAreNoSuch()
        {
            var groupServiceMocked = new Mock<IGroupService>();


            groupServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>());

            var controller = new ForumController(groupServiceMocked.Object);

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView()
                .WithModel<List<GroupViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Count, 0);

                    Assert.AreEqual(viewModel.Count, 0);

                    Assert.AreEqual(viewModel.Count, 0);
                });
        }
    }
}
