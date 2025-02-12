using DataAccess.Models;
using WebAPI.DTOs.QuizDtos;

namespace WebAPI.Mappers
{
    public static class QuizMapper
    {
        public static QuizDto ToQuizDto(this Quiz quiz, string url)
        {
            return new QuizDto
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                Date = quiz.Date,
                ImageName = quiz.ImageName,
                ImageType = quiz.ImageType,
                ImageUrl = url,
                Questions = quiz.Questions.Select(q => q.ToQuestionDto()).ToList(),
                //Answers = quiz.Questions.Select(q=> new QuizAnswer { 
                //    QuestionId = q.Id,
                //    QuizId = quiz.Id,
                //}).ToList(),
            };
        }
    }
}
