using Microsoft.AspNet.Identity.EntityFramework;
using MiniLearningSystem.Models.EntityModels;

namespace MiniLearningSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")//, throwIfV1Schema: false
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
