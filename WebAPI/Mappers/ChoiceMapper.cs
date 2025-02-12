using DataAccess.Models;
using WebAPI.DTOs.ChoiceDtos;

namespace WebAPI.Mappers
{
    public static class ChoiceMapper
    {
        public static ChoiceDto ToChoiceDto(this Choice choice)
        {
            return new ChoiceDto
            {
                Id = choice.Id,
                Text = choice.Text,
                IsCorrect = choice.IsCorrect,
            };
        }
    }
}
