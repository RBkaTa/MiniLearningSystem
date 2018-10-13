using System;
using System.ComponentModel.DataAnnotations;

namespace MiniLearningSystem.Models.ViewModels.Course
{
    public class CourseDetailsVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string TrainerId { get; set; }

        [Display(Name = "Trainer")]
        public string TrainerName { get; set; }

        [Display(Name = "Students enrolled")]
        public int StudentsCount { get; set; }

        public bool IsApplyed { get; set; }
    }
}
