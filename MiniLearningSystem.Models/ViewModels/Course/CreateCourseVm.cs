using System;
using System.ComponentModel.DataAnnotations;

namespace MiniLearningSystem.Models.ViewModels.Course
{
    public class CreateCourseVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public DateTime EndDate { get; set; }
    }
}
