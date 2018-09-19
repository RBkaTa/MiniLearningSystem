using MiniLearningSystem.Models.EntityModels;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MiniLearningSystem.Services
{
    public class CourseService : Service
    {
        public ICollection<Course> GetAll()
        {
            using (this.Context)
            {
                return this.Context.Courses.Include(c => c.Trainer).Include(c => c.Students).ToList();
            }
        }
    }
}
