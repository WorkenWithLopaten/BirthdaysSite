using System;
using System.Collections.Generic;
using MVCTemplate.Data.Models;
using MVCTemplate.Data.Common;
using System.Linq;

namespace MVCTemplate.Services.Data
{
    public class FriendListService : IFriendListService
    {
        private IDbRepository<FriendsList> friends;

        public FriendListService(IDbRepository<FriendsList> friends)
        {
            this.friends = friends;
        }

        public ICollection<FriendsList> GetAll()
        {
            return this.friends.All().ToList();
        }

        public ICollection<Friend> GetAllFriends(string friendListName)
        {
            var friendList = this.friends.All()
                .SingleOrDefault(g => g.Name.ToLower() == friendListName.ToLower()
                && !g.IsDeleted);

            if (friendList == null)
            {
                return new List<Friend>();
            }
            else
            {
                return friendList.Friends
                    .OrderBy(x => Math.Abs(DateTime.Now.Month - x.Birthday.Month))
                    .ThenBy(y => Math.Abs(DateTime.Now.Day - y.Birthday.Day))
                    .ToList();
            }
        }
    }
}
