using System;
using System.Linq;
using MVCTemplate.Data.Models;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.SaveContext;

namespace MVCTemplate.Services.Data
{
    public class GroupService : IGroupService
    {
        private IDbRepository<Group> groups;
        private ISaveContext saveContext;

        public GroupService(IDbRepository<Group> groups, ISaveContext saveContext)
        {
            this.groups = groups;
            this.saveContext = saveContext;
        }

        public IQueryable<Group> GetAll()
        {
            return this.groups.All().Where(m => !m.IsDeleted);
        }

        public void AddMessageToGroup(string groupName, string messageAuthor, string messageContent)
        {
            var group = this.groups.All()
                .SingleOrDefault(g => g.Name == groupName && !g.IsDeleted);

            var message = new Message(messageAuthor, messageContent);

            message.CreatedOn = DateTime.Now;
            message.Group = group;
            message.GroupId = group.Id;

            group.Messages.Add(message);

            saveContext.Commit();
        }
    }
}
