using MiniLearningSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MiniLearningSystem.Models.ViewModels.Admin
{
    public class SetRoleVm
    {
        public SetRole Role { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
