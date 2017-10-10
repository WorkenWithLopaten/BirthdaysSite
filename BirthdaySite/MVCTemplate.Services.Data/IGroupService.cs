using MVCTemplate.Data.Models;
using System.Linq;

namespace MVCTemplate.Services.Data
{
    public interface IGroupService
    {
        IQueryable<Group> GetAll();

        void AddMessageToGroup(string groupName, string messageAuthor, string messageContent);
    }
}
