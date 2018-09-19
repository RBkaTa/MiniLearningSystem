using MiniLearningSystem.Data;

namespace MiniLearningSystem.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new ApplicationDbContext();
        }

        protected ApplicationDbContext Context { get; }
    }
}
