using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.SaveContext;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;

namespace BirthdaySite.UnitTests.ServiceTests.GroupServiceTests
{
    [TestClass]
    public class AddMessageToGroupTests
    {
        [TestMethod]
        public void AddMessageToGroup_ShouldCallGetAll_Once()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            var group = new Group()
            {
                Name = "testGroup"
            };

            var groups = new List<Group>()
            {
                group
            };

            repoMocked.Setup(m => m.All()).Returns(groups.AsQueryable());
            repoMocked.Setup(m => m.Add(group));

            var service = new GroupService(repoMocked.Object, contextMocked.Object);

            service.AddMessageToGroup("testGroup", "testAuthor", "testContent");

            repoMocked.Verify(m => m.All(), Times.Once);
        }

        [TestMethod]
        public void AddMessageToGroup_ShouldCallCommit_Once()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            var group = new Group()
            {
                Name = "testGroup"
            };

            var groups = new List<Group>()
            {
                group
            };

            repoMocked.Setup(m => m.All()).Returns(groups.AsQueryable());
            repoMocked.Setup(m => m.Add(group));

            var service = new GroupService(repoMocked.Object, contextMocked.Object);

            service.AddMessageToGroup("testGroup", "testAuthor", "testContent");

            contextMocked.Verify(m => m.Commit(), Times.Once);
        }

        [TestMethod]
        public void AddMessageToGroup_ShouldAddMessageToGroup()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            var group = new Group()
            {
                Name = "testGroup"
            };

            var groups = new List<Group>()
            {
                group
            };

            repoMocked.Setup(m => m.All()).Returns(groups.AsQueryable());
            repoMocked.Setup(m => m.Add(group));

            var service = new GroupService(repoMocked.Object, contextMocked.Object);

            service.AddMessageToGroup("testGroup", "testAuthor", "testContent");

            Assert.AreEqual(group.Messages.First().Author,
                "testAuthor");
            Assert.AreEqual(group.Messages.First().Content, "testContent");
        }

        [TestMethod]
        public void AddMessageToGroup_ShouldNotAddMessageToGroup_IfSuchDoesNotExist()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            var group = new Group()
            {
                Name = "testGroup"
            };

            var groups = new List<Group>()
            {
                group
            };

            repoMocked.Setup(m => m.All()).Returns(groups.AsQueryable());
            repoMocked.Setup(m => m.Add(group));

            var service = new GroupService(repoMocked.Object, contextMocked.Object);

            service.AddMessageToGroup("testGroup1", "testAuthor", "testContent");

            Assert.AreEqual(group.Messages.Count, 0);
        }
    }
}
