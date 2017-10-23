using System.ComponentModel.DataAnnotations;

namespace BirthdaySite.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 9)]
        public string Email { get; set; }
    }
}
