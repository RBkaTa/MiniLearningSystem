﻿using System;
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

            var student = new Student();
            student.UserId = userId;

            try
            {
                this.Context.Students.Add(student);
                this.Context.SaveChanges();

                success = true;
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public ICollection<ApplicationUser> GetAll()
        {
            return this.Context.Users.ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return this.Context.Users.Find(id);
        }

        public ICollection<ApplicationUser> GetTrainers()
        {
            var store = new UserStore<ApplicationUser>(this.Context);
            var manager = new UserManager<ApplicationUser>(store);

            var trainerRoleId = this.Context.Roles.SingleOrDefault(u => u.Name == "Trainer").Id;

            return this.Context.Users.Where(u => u.Roles.Any(r => r.RoleId == trainerRoleId)).ToList();
        }

        public ApplicationUser GetByName(string name)
        {
            return this.Context.Users.SingleOrDefault(u => u.UserName == name);
        }
    }
}
