using DataAccess.Models;
using WebAPI.DTOs.QuestionDtos;

namespace WebAPI.DTOs.QuizDtos
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public string ImageName { get; set; } = string.Empty;
        public string ImageType { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
        public List<QuizAnswer> Answers { get; set; }
    }
}
