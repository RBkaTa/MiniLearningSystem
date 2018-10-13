using System.Collections.Generic;

namespace MiniLearningSystem.Models.ViewModels.Chat
{
    public class ChatVm
    {
        public string Id { get; set; }
        public string SenderName { get; set; }
        public ICollection<MessageVm> Messages { get; set; }
    }
}
