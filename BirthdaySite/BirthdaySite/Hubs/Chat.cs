using Bytes2you.Validation;
using Microsoft.AspNet.SignalR;
using MVCTemplate.Services.Data;

namespace SignalRChat.Hubs
{
    public class Chat : Hub
    {
        private IGroupService groups;

        public Chat(IGroupService groups)
        {
            Guard.WhenArgument(groups, "groupService").IsNull().Throw();

            this.groups = groups;
        }

        public void JoinRoom(string room)
        {
            this.Groups.Add(Context.ConnectionId, room);
        }

        public void SendMessageToRoom(string message, string rooms)
        {
            var user = this.Context.User.Identity.Name;
            var index = user.IndexOf("@");
            var author = user.Substring(0, index);

            this.groups.AddMessageToGroup(rooms, author, message);

            this.Clients.Group(rooms).addMessage(message, author);
        }
    }
}