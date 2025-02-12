using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ChoiceRepository : GenericRepository<Choice>, IChoiceRepository
    {
        private readonly QuizContext _db;
        public ChoiceRepository(QuizContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Choice> Update(Choice choice)
        {
            if (choice == null) { return null; }
            var choiceFromDb = await _db.Choices.FirstOrDefaultAsync(c => c.Id == choice.Id);
            if (choiceFromDb == null) { return null; }
            choiceFromDb.Text = choiceFromDb.Text;
            choiceFromDb.IsCorrect = choice.IsCorrect;
            return choiceFromDb;
        }
    }
}
