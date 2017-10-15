using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Moq;
using MVCTemplate.Services.Data;
using SignalRChat.Hubs;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace BirthdaySite.UnitTests.SignalRTests.Helpers
{
    public class TestableChatHub : Chat
    {
        public Mock<IGroupService> MockChatRepository { get; private set; }

        public TestableChatHub(Mock<IGroupService> mockChatRepository)
          : base(mockChatRepository.Object)
        {
            const string connectionId = "1234";
            const string hubName = "Chat";
            var mockConnection = new Mock<IConnection>();
            var mockUser = new Mock<IPrincipal>();
            var mockCookies = new Mock<IRequestCookieCollection>();

            var mockRequest = new Mock<IRequest>();
            mockRequest.Setup(r => r.User).Returns(mockUser.Object);
            mockRequest.Setup(r => r.Cookies).Returns(mockCookies.Object);

            Clients = new ClientAgent(mockConnection.Object, hubName);
            Context = new HubCallerContext(mockRequest.Object, connectionId);

            var trackingDictionary = new TrackingDictionary();
            Caller = new StatefulSignalAgent(mockConnection.Object, connectionId, hubName, trackingDictionary);
        }
    }
}
