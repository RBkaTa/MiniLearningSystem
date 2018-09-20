using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Admin;
using MiniLearningSystem.Services.Interfaces;

namespace MiniLearningSystem.Services
{
    public class AdminService : Service, IAdminService
    {
        public (bool success, string username) SetRole(SetRoleVm model)
        {
            var success = false;
            ApplicationUser user;

            using (this.Context)
            {
                user = this.Context.Users.SingleOrDefault(u => u.UserName == model.Username);
                var store = new UserStore<ApplicationUser>(this.Context);
                var manager = new UserManager<ApplicationUser>(store);
                manager.AddToRole(user.Id, model.Role.ToString());

                success = true;
            }

            return (success, user.UserName);
        }
    }
}
