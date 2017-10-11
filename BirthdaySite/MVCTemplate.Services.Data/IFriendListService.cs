using MVCTemplate.Data.Models;
using System.Collections.Generic;

namespace MVCTemplate.Services.Data
{
    public interface IFriendListService
    {
        ICollection<Friend> GetAllFriends(string friendListName);

        ICollection<FriendsList> GetAll();
    }
}
