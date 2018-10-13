using System;
using System.Collections.Generic;

namespace MiniLearningSystem.Models.EntityModels
{
    public class Chat
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public int RecieverId { get; set; }
        public ApplicationUser Reciever { get; set; }

        public DateTime SentDate { get; set; }

        public ICollection<Message> Messages{ get; set; }
    }
}
