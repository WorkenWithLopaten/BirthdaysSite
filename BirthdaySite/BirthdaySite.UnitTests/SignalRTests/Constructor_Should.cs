using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Services.Data;
using SignalRChat.Hubs;
using System;

namespace BirthdaySite.UnitTests.SignalRTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Constructor_ShouldInitializeCorrectly()
        {
            var service = new Mock<IGroupService>();

            var chat = new Chat(service.Object);

            Assert.IsNotNull(chat);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenGroupIsNull()
        {
            var service = new Mock<IGroupService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new Chat(null));
        }
    }
}
