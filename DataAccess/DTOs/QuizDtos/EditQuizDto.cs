using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTOs.QuizDtos
{
    public class EditQuizDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        [Display(Name = "Quiz Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(999, MinimumLength = 1)]
        [Display(Name = "Quiz Description")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Quiz Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        [Display(Name = "Upload Image")]
        [ValidateNever]
        public IFormFile? FormFile { get; set; } = null;
    }
}
