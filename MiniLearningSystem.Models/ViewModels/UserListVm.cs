using System.Collections.Generic;

namespace MiniLearningSystem.Models.ViewModels
{
    public class UserListVm
    {
        public UserListVm()
        {
            this.Users = new List<UserListDetailsVm>();
        }

        public IEnumerable<UserListDetailsVm> Users { get; set; }
    }
}
