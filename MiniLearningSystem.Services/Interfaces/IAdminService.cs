using MiniLearningSystem.Models.ViewModels.Admin;

namespace MiniLearningSystem.Services.Interfaces
{
    public interface IAdminService
    {
        (bool success, string username) SetRole(SetRoleVm model);
    }
}
