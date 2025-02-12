using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTOs.QuizDtos
{
    public class CreateQuizDto
    {
        [Required]
        [StringLength(250, MinimumLength = 1)]
        [Display(Name = "Quiz Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(500, MinimumLength = 1)]
        [Display(Name = "Quiz Description")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Quiz Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please select an image file.")]
        [Display(Name = "Upload Image")]
        public IFormFile FormFile { get; set; }
    }
}
