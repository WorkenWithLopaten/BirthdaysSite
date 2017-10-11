using System.Collections.Generic;

namespace BirthdaySite.ViewModels.Friends
{
    public class FriendsViewModel
    {
       public string Name { get; set; }

       public ICollection<FriendViewModel> Friends { get; set; }
    }
}