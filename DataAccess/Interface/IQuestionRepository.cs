using DataAccess.Models;

namespace DataAccess.Interface
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<Question> Update(Question question);
    }
}
