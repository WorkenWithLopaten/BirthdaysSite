using MVCTemplate.Data.Common.Models;
using System.Collections.Generic;

namespace MVCTemplate.Data.Models
{
    public class FriendsList : BaseModel<int>
    {
        public FriendsList()
        {
            this.Friends = new List<Friend>();
        }

        public FriendsList(string name)
        {
            this.Name = name;
            this.Friends = new List<Friend>();
        }

        public string Name { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }
    }
}
