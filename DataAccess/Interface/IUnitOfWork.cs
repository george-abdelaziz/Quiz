namespace DataAccess.Interface
{

    public interface IUnitOfWork
    {
        IQuizRepository Quizzes { get; }
        IQuestionRepository Questions { get; }
        IChoiceRepository Choices { get; }
        IUserDataRepository UserDatas { get; }
        IQuizAnswerRepository QuizzesAnswer { get; }
        //IAnswerRepository Answers { get; }
        Task Save();
    }
}
