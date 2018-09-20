using MiniLearningSystem.Models.EntityModels;
using System.Collections.Generic;

namespace MiniLearningSystem.Services.Interfaces
{
    public interface IAccountService
    {
        ICollection<ApplicationUser> GetAll();

        bool RegisterStudent(string userId);
    }
}
