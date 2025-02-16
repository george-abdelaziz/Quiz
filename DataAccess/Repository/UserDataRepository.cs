using DataAccess.Interface;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class UserDataRepository : GenericRepository<UserData>, IUserDataRepository
    {
        private readonly QuizContext _db;
        public UserDataRepository(QuizContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserData data)
        {
            if (data == null) { return; }
            _db.UserDatas.Update(data);
        }
    }
}
