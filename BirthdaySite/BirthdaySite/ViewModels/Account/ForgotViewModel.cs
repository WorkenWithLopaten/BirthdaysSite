using System.ComponentModel.DataAnnotations;

namespace BirthdaySite.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
