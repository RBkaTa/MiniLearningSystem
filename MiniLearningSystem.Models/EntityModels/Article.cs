using System;

namespace MiniLearningSystem.Models.EntityModels
{
    public class Article
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
    }
}
