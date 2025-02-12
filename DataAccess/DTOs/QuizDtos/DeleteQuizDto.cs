using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTOs.QuizDtos
{
    public class DeleteQuizDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
