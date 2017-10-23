using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BirthdaySite.ViewModels.Friends
{
    public class FriendsViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Name { get; set; }

       public ICollection<FriendViewModel> Friends { get; set; }
    }
}