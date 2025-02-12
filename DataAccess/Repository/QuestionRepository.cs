using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly QuizContext _db;
        public QuestionRepository(QuizContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<ICollection<Question>> GetAll(Expression<Func<Question, bool>>? filter, bool include = false)
        {
            IQueryable<Question> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = query.Include(q => q.Choices);
            return await query.ToListAsync();
        }

        public override async Task<Question?> Get(Expression<Func<Question, bool>> filter, bool include = false)
        {
            IQueryable<Question> query = dbSet;
            query = query.Where(filter);
            if (include)
            {
                query = query.Include(q => q.Choices);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Question> Update(Question question)
        {
            if (question == null)
            {
                return null;
            }
            var questionFromDb = await _db.Questions.FirstOrDefaultAsync(q => q.Id == question.Id);
            if (questionFromDb == null) { return null; }
            questionFromDb.Text = question.Text;
            questionFromDb.IsMCQ = question.IsMCQ;
            return questionFromDb;
        }
    }
}
