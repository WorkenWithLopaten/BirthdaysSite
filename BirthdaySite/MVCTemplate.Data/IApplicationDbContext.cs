using MVCTemplate.Data.Models;
using System.Data.Entity;

namespace BirthdaySite.Models
{
    public interface IApplicationDbContext
    {
        IDbSet<Friend> Friends { get; set; }

        IDbSet<FriendsList> FriendsList { get; set; }

        IDbSet<Group> Groups { get; set; }

        IDbSet<Message> Messages { get; set; }

        int SaveChanges();
    }
}