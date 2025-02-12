using DataAccess.Models;
using WebAPI.DTOs.TakeQuizDtos;

namespace WebAPI.Mappers
{
    public static class TakeQuizMapper
    {
        public static TakeQuizDto ToTakeQuizDto(this Quiz quiz)
        {
            return new TakeQuizDto
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                Date = quiz.Date,
                ImageName = quiz.ImageName,
                ImageType = quiz.ImageType,
                Questions = quiz.Questions.Select(q => q.ToQuestionDto()).ToList(),
                //Answers = quiz.Questions.Select(q=> new QuizAnswer { 
                //    QuestionId = q.Id,
                //    QuizId = quiz.Id,
                //}).ToList(),
            };
        }
    }
}
