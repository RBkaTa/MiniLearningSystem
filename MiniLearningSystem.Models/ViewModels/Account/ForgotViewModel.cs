using System.ComponentModel.DataAnnotations;

namespace MiniLearningSystem.Models.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
