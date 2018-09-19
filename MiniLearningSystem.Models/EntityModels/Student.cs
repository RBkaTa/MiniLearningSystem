using System.Collections.Generic;

namespace MiniLearningSystem.Models.EntityModels
{
    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
