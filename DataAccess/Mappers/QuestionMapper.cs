using DataAccess.DTOs.QuestionDtos;
using DataAccess.Models;

namespace DataAccess.Mappers
{
    public static class QuestionMapper
    {
        public static Question ToQuestion(this CreateQuestionDto createQuestionDto)
        {
            return new Question
            {
                Text = createQuestionDto.Text,
                IsMCQ = createQuestionDto.IsMCQ,
                QuizId = createQuestionDto.QuizId,
            };
        }
    }
}
