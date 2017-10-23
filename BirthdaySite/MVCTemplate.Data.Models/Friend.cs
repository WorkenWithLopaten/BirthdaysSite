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

        //[Required]
        //[Display(Name = "FriendName")]
        //[DataType(DataType.Text)]
        //[StringLength(20)]
        public string Name { get; set; }     
                  
        public int FriendListId { get; set; }

        public virtual FriendsList FriendList { get; set; }

        //[Required]
        //[Display(Name = "Birthday")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }
    }
}
