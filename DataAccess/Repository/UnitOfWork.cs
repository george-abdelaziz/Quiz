using DataAccess.Interface;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizContext _db;
        public UnitOfWork(QuizContext db)
        {
            _db = db;
            Quizzes = new QuizRepository(_db);
            Questions = new QuestionRepository(_db);
            Choices = new ChoiceRepository(_db);
            UserDatas = new UserDataRepository(_db);
            QuizzesAnswer = new QuizAnswerRepository(_db);
            //Answers = new AnswerRepository(_db);
        }
        public IQuizRepository Quizzes { set; get; }

        public IQuestionRepository Questions { set; get; }

        public IChoiceRepository Choices { set; get; }

        public IUserDataRepository UserDatas { set; get; }

        public IQuizAnswerRepository QuizzesAnswer { set; get; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
