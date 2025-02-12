using DataAccess.Models;

namespace DataAccess.Interface
{
    public interface IQuizRepository : IGenericRepository<Quiz>
    {
        Task<Quiz> Update(Quiz quiz);
    }
}
