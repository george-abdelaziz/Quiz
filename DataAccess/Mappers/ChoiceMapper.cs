using DataAccess.DTOs.ChoiceDtos;
using DataAccess.Models;

namespace DataAccess.Mappers
{
    public static class ChoiceMapper
    {
        public static Choice ToChoice(this CreateChoiceDto createChoiceDto)
        {
            return new Choice
            {
                Text = createChoiceDto.Text,
                IsCorrect = createChoiceDto.IsCorrect,
                QuestionId = createChoiceDto.QuestionId
            };
        }
    }
}
