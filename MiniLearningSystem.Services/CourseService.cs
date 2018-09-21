using MiniLearningSystem.Models.EntityModels;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using MiniLearningSystem.Models.ViewModels.Course;
using System.Web;
using AutoMapper;
using MiniLearningSystem.Services.Interfaces;

namespace MiniLearningSystem.Services
{
    public class CourseService : Service, ICourseService
    {
        public (bool success, string courseName) AddStudent(int courseId)
        {
            var success = false;

            using (this.Context)
            {
                var user = this.GetCurrentStudentInfo();

                var course = this.Context.Courses.SingleOrDefault(c => c.Id == courseId);
                course.Students.Add(user);

                user.Courses.Add(course);

                this.Context.SaveChanges();

                success = true;

                return (success, course.Name);
            }

        }

        public bool Create(CreateCourseVm model)
        {
            var success = false;

            var course = Mapper.Map<Course>(model);

            using (this.Context)
            {
                this.Context.Courses.Add(course);
                this.Context.SaveChanges();

                success = true;
            }

            return success;
        }

        public ICollection<Course> GetAll()
        {
            using (this.Context)
            {
                return this.Context.Courses.Include(c => c.Trainer).Include(c => c.Students).ToList();
            }
        }

        public Course GetById(int id)
        {
            using (this.Context)
            {
                return this.Context.Courses.Include(c => c.Trainer).Include(c => c.Students).FirstOrDefault(c => c.Id == id);
            }
        }

        public IList<CourseIndexVm> SetApplyedCourses()
        {

            var userName = HttpContext.Current.User.Identity.Name;

            using (this.Context)
            {
                var courses = Mapper.Map<ICollection<Course>, IList<CourseIndexVm>>(this.Context.Courses.Include(c => c.Trainer).Include(c => c.Students).ToList());

                var student = this.Context.Students.Include(s => s.Courses).Include(s => s.User).SingleOrDefault(s => s.User.UserName == userName);

                for (int i = 0; i < courses.Count; i++)
                {
                    courses[i].IsApplyed = student.Courses.Any(c => c.Id == courses[i].Id);
                }

                return courses;
            }
        }

        public void SetIcons(IList<CourseIndexVm> courses)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name.ToLower().Contains("php"))
                {
                    courses[i].IconUrl = "/Library/php-7-up-and-running.jpg";
                }
                else if (courses[i].Name.ToLower().Contains("java"))
                {
                    courses[i].IconUrl = "/Library/outdated-java-windows-10.jpg";
                }
                else if (courses[i].Name.ToLower().Contains("network"))
                {
                    courses[i].IconUrl = "/Library/computer-hacking-during-divorce_600x400.jpeg";
                }
                else if (courses[i].Name.ToLower().Contains("c#"))
                {
                    //courses[i].IconUrl = "https://cdn3.macworld.co.uk/cmsdata/features/3640347/learn_c_sharp_mac_osx_thumb800.jpg";
                    courses[i].IconUrl = "/Library/cSharp.jpg";
                }
                else if(courses[i].Name.ToLower().Contains("html"))
                {
                    courses[i].IconUrl = "/Library/html.png";
                }
                else if (courses[i].Name.ToLower().Contains("ruby"))
                {
                    courses[i].IconUrl = "/Library/Ruby.png";
                }
                else if (courses[i].Name.ToLower().Contains("python"))
                {
                    courses[i].IconUrl = "/Library/Python.png";
                }
                else if (courses[i].Name.ToLower().Contains(".net"))
                {
                    courses[i].IconUrl = "/Library/.Net.jpg";
                }
                else if (courses[i].Name.ToLower().Contains("sql"))
                {
                    courses[i].IconUrl = "/Library/SQL.jpg";
                }
            }
        }
    }
}
