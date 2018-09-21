using System;
using System.ComponentModel.DataAnnotations;

namespace MiniLearningSystem.Models.ViewModels.Course
{
    public class CourseIndexVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        
        public bool IsApplyed { get; set; }

        public string IconUrl { get; set; }
    }
}
