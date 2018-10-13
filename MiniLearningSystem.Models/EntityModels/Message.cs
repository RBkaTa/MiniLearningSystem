namespace MiniLearningSystem.Models.EntityModels
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public int RecieverId { get; set; }
        public ApplicationUser Reciever { get; set; }

        public string Content { get; set; }
    }
}