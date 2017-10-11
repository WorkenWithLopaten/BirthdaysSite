using System;
using MVCTemplate.Data.Common.Models;

namespace MVCTemplate.Data.Models
{
    public class Friend : BaseModel<int>
    {          
        public Friend()
        {

        }

        public Friend(string name, bool gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        public string Name { get; set; }     
                  
        public int FriendListId { get; set; }

        public virtual FriendsList FriendList { get; set; }

        public DateTime Birthday { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }
    }
}
