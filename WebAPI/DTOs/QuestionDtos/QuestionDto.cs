using WebAPI.DTOs.ChoiceDtos;

namespace WebAPI.DTOs.QuestionDtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public bool IsMCQ { get; set; }
        public string Text { get; set; } = string.Empty;
        public virtual ICollection<ChoiceDto> Choices { get; set; } = new List<ChoiceDto>();
    }
}
