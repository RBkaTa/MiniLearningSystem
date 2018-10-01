using MiniLearningSystem.Models.EntityModels;
using System;
using System.Collections.Generic;

namespace MiniLearningSystem.Services.Interfaces
{
    public interface IAccountService
    {
        ICollection<ApplicationUser> GetAll();

        bool RegisterStudent(string userId);

        ICollection<ApplicationUser> GetTrainers();
    }
}
