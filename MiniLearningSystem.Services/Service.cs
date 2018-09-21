using MiniLearningSystem.Data;
using System.Data.Entity;
using System.Linq;
using MiniLearningSystem.Models.EntityModels;
using System.Web;

namespace MiniLearningSystem.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new ApplicationDbContext();
        }

        protected ApplicationDbContext Context { get; }

        protected Student GetCurrentStudentInfo()
        {
            var userName = HttpContext.Current.User.Identity.Name;
            Student user = this.Context.Students.Include(s => s.Courses).SingleOrDefault(s => s.User.UserName == userName);

            return user;
        }
    }
}
