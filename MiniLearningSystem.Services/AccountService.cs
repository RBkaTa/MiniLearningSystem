using MiniLearningSystem.Models.EntityModels;

namespace MiniLearningSystem.Services
{
    public class AccountService : Service
    {
        public bool RegisterStudent(string userId)
        {
            var success = false;

            using (this.Context)
            {
                var student = new Student();
                student.UserId = userId;

                this.Context.Students.Add(student);
                this.Context.SaveChanges();

                success = true;
            }

            return success;
        }
    }
}
