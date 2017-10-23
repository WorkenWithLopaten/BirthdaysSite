using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BirthdaySite.ViewModels.Forum
{
    public class GroupViewModel
    {
        [Required]
        [Display(Name = "GroupName")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }
    }
}