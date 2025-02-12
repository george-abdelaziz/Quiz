using DataAccess.Models;

namespace DataAccess.Interface
{
    public interface IChoiceRepository : IGenericRepository<Choice>
    {
        Task<Choice> Update(Choice choice);
    }
}
