using DataAccess.Interface;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class QuizAnswerRepository : GenericRepository<QuizAnswer>, IQuizAnswerRepository
    {
        private readonly QuizContext _db;
        public QuizAnswerRepository(QuizContext db) : base(db)
        {
            _db = db;
        }

        public void Update(QuizAnswer answer)
        {
            if (answer == null) { return; }
            _db.QuizAnswers.Update(answer);
        }
    }
}
