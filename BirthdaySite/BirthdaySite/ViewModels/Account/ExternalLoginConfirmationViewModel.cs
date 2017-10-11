﻿using System.ComponentModel.DataAnnotations;

namespace BirthdaySite.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
