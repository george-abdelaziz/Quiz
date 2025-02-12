using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTOs.QuestionDtos
{
    public class CreateQuestionDto
    {
        [Required]
        [MaxLength(255)]
        [StringLength(255, MinimumLength = 1)]
        [DisplayName("Question Text")]
        public string Text { get; set; } = string.Empty;

        [Required]
        public bool IsMCQ { set; get; }

        [Required]
        public int QuizId { set; get; }
    }
}
