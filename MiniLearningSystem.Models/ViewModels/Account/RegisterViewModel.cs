﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MiniLearningSystem.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
