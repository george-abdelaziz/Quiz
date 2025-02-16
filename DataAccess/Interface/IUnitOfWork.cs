using DataAccess.Models;

namespace DataAccess.Interface
{

    public interface IUnitOfWork
    {
        QuizContext _db { get; }
        IQuizRepository Quizzes { get; }
        IQuestionRepository Questions { get; }
        IChoiceRepository Choices { get; }
        IUserDataRepository UserDatas { get; }
        IQuizAnswerRepository QuizzesAnswer { get; }
        //IAnswerRepository Answers { get; }
        Task Save();
    }
}
