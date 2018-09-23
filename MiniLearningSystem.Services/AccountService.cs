using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Services.Interfaces;

namespace MiniLearningSystem.Services
{
    public class AccountService : Service, IAccountService
    {
        public bool RegisterStudent(string userId)
        {
            var success = false;

            using (this.Context)
            {
                var student = new Student();
                student.UserId = userId;

                this.Context.Students.Add(student);
                this.Context.SaveChanges();

                success = true;
            }

            return success;
        }

        public ICollection<ApplicationUser> GetAll()
        {
            using (this.Context)
            {
                return this.Context.Users.ToList();
            }
        }

        public ICollection<ApplicationUser> GetTrainers()
        {
            using (this.Context)
            {
                var store = new UserStore<ApplicationUser>(this.Context);
                var manager = new UserManager<ApplicationUser>(store);

                var trainerRoleId = this.Context.Roles.SingleOrDefault(u => u.Name == "Trainer").Id;

                return this.Context.Users.Where(u => u.Roles.Any(r => r.RoleId == trainerRoleId)).ToList();
            }
        }
    }
}
