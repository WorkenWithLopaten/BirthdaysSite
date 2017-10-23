using System;
using System.ComponentModel.DataAnnotations;

namespace BirthdaySite.ViewModels.Friends
{
    public class FriendViewModel
    {
        [Required]
        [Display(Name = "FriendName")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [DataType(DataType.Custom)]
        public bool Gender { get; set; }
    }
}