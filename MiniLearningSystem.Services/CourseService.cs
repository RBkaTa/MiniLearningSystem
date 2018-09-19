using MiniLearningSystem.Models.EntityModels;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using MiniLearningSystem.Models.ViewModels.Course;
using System;
using System.Web;

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

        public IList<CourseIndexVm> SetApplyedCourses()
        {

            var userName = HttpContext.Current.User.Identity.Name;

            using (this.Context)
            {
                var courses = this.Context.Courses.Include(c => c.Trainer).Include(c => c.Students).Select(c => new CourseIndexVm()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                }).ToList();

                var student = this.Context.Students.Include(s => s.Courses).Include(s => s.User).SingleOrDefault(s => s.User.UserName == userName);

                for (int i = 0; i < courses.Count; i++)
                {
                    courses[i].IsApplyed = student.Courses.Any(c => c.Id == courses[i].Id);
                }

                return courses;
            }
        }
    }
}
