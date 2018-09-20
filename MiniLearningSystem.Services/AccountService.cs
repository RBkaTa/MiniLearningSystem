using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
