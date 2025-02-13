using DataAccess.Models;

namespace DataAccess.Interface
{
    public interface IUserDataRepository : IGenericRepository<UserData>
    {
        void Update(UserData data);
    }
}
