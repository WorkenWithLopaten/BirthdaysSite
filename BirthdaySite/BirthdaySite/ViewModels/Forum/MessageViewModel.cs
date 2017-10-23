using System.ComponentModel.DataAnnotations;

namespace BirthdaySite.ViewModels.Forum
{
    public class MessageViewModel
    {
        [Required]
        [Display(Name = "Author")]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Content")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string Content { get; set; }
    }
}