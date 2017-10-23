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
    public class MessageTests
    {
        [TestMethod]
        public void Message_Should_CallMethod_GetAllGroups()
        {
            var groupServiceMocked = new Mock<IGroupService>();

            var groupViewModel = new GroupViewModel();

            groupServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>());

            var controller = new ForumController(groupServiceMocked.Object);

            controller.Message("testGroup");

            groupServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Message_Should_RenderCorrectView_WithCorrectParameters()
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
                .WithCallTo(m => m.Message("testGroup"))
                .ShouldRenderPartialView("Message")
                .WithModel<GroupViewModel>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Name,
                        groupViewModel.Name);

                    Assert.AreEqual(viewModel.Messages.First().Content,
                        groupViewModel.Messages.First().Content);

                    Assert.AreEqual(viewModel.Messages.First().Author,
                        groupViewModel.Messages.First().Author);
                });
        }
    }
}
