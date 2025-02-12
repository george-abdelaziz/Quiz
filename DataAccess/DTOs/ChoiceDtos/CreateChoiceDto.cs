using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTOs.ChoiceDtos
{
    public class CreateChoiceDto
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        [MaxLength(255)]
        [DisplayName("Choice Text")]
        public string Text { get; set; } = string.Empty;
        [Required]
        public bool IsCorrect { get; set; } = false;
        [Required]
        public int QuestionId { get; set; }
    }
}
