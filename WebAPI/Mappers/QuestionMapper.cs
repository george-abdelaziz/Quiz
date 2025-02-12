using DataAccess.Models;
using WebAPI.DTOs.QuestionDtos;

namespace WebAPI.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDto ToQuestionDto(this Question question)
        {
            return new QuestionDto
            {
                Id = question.Id,
                IsMCQ = question.IsMCQ,
                Text = question.Text,
                Choices = question.Choices.Select(c => c.ToChoiceDto()).ToList()
            };
        }
    }
}
