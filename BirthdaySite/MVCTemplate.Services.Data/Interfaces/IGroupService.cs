using MVCTemplate.Data.Models;
using System.Collections.Generic;

namespace MVCTemplate.Services.Data
{
    public interface IGroupService
    {
        ICollection<Group> GetAll();

        void AddMessageToGroup(string groupName, string messageAuthor, string messageContent);
    }
}
