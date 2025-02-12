using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        private readonly QuizContext _db;
        public QuizRepository(QuizContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<ICollection<Quiz>> GetAll(Expression<Func<Quiz, bool>>? filter, bool include = false)
        {
            IQueryable<Quiz> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = query.Include(q => q.Questions).ThenInclude(q => q.Choices);
            return await query.ToListAsync();
        }

        public override async Task<Quiz?> Get(Expression<Func<Quiz, bool>> filter, bool include = false)
        {
            IQueryable<Quiz> query = dbSet;
            query = query.Where(filter);
            if (include)
            {
                query = query.Include(q => q.Questions).ThenInclude(q => q.Choices);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Quiz> Update(Quiz quiz)
        {
            if (quiz == null)
            {
                return null;
            }
            var quizFromDb = await _db.Quizzes.FirstOrDefaultAsync(q => q.Id == quiz.Id);
            if (quizFromDb == null)
            {
                return null;
            }
            quizFromDb.Name = quiz.Name;
            quizFromDb.Description = quiz.Description;
            quizFromDb.Date = quiz.Date;
            if (quiz.ImageData != null && quiz.ImageData.Length > 0)
            {
                quizFromDb.ImageType = quiz.ImageType;
                quizFromDb.ImageName = quiz.ImageName;
                quizFromDb.ImageData = quiz.ImageData;
            }
            return quizFromDb;
        }
    }
}
