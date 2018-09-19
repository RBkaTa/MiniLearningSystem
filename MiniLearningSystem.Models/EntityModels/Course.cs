using System;
using System.Collections.Generic;

namespace MiniLearningSystem.Models.EntityModels
{
    public class Course
    {
        public Course()
        {
            this.Students = new List<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TrainerId { get; set; }
        public ApplicationUser Trainer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
