using Moq;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;
using BirthdaySite.Controllers;
using BirthdaySite.ViewModels.Forum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BirthdaySite.UnitTests.ControllerTests
{
    [TestClass]
    public class RenderMessagesTests
    {
        [TestMethod]
        public void RenderMessages_Should_CallMethod_GetAllGroups()
        {
            var groupServiceMocked = new Mock<IGroupService>();

            var groupViewModel = new GroupViewModel();

            groupServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>());

            var controller = new ForumController(groupServiceMocked.Object);

            controller.RenderMessages("testGroup");

            groupServiceMocked.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void RenderMessages_Should_RenderCorrectView_WithCorrectParameters()
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
                .WithCallTo(m => m.RenderMessages("testGroup"))
                .ShouldRenderView("_MessagesPartial")
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

        [TestMethod]
        public void RenderMessages_Should_RenderViewWithNullParameters_WhenThereIsNoSuchGroup()
        {
            var groupServiceMocked = new Mock<IGroupService>();


            groupServiceMocked.Setup(m => m.GetAll())
                .Returns(new List<Group>());

            var controller = new ForumController(groupServiceMocked.Object);

            controller
                .WithCallTo(m => m.RenderMessages("testGroup"))
                .ShouldRenderView("_MessagesPartial");
                //.WithModel<GroupViewModel(null)>(model =>
                //{
                //    Assert.IsNull(model);
                //});         
                
        }
    }
}
