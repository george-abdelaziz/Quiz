using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class QuizAnswerRepository : GenericRepository<QuizAnswer>,IQuizAnswerRepository
    {
        public QuizAnswerRepository(QuizContext db) : base(db)
        {
        }

        public void Update(QuizAnswer answer)
        {
            throw new NotImplementedException();
        }
    }
}
