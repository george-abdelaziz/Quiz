using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserDataRepository : GenericRepository<UserData>, IUserDataRepository
    {
        public UserDataRepository(QuizContext db) : base(db)
        {
        }

        public void Update(UserData data)
        {
            throw new NotImplementedException();
        }
    }
}
