using DataAccess.Models;

namespace DataAccess.Interface
{
    public interface IQuizAnswerRepository : IGenericRepository<QuizAnswer>
    {
        void Update(QuizAnswer answer);
    }
}
