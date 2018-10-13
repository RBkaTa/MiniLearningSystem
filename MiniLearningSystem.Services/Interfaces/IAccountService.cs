using MiniLearningSystem.Models.EntityModels;
using System.Collections.Generic;

namespace MiniLearningSystem.Services.Interfaces
{
    public interface IAccountService
    {
        ICollection<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);

        ApplicationUser GetByName(string name);

        bool RegisterStudent(string userId);

        ICollection<ApplicationUser> GetTrainers();
    }
}
