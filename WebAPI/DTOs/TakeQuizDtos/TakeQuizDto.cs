using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using WebAPI.DTOs.QuestionDtos;

namespace WebAPI.DTOs.TakeQuizDtos
{
    public class TakeQuizDto
    {
        [ValidateNever]
        public int Id { get; set; }
        [ValidateNever]
        public string Name { get; set; } = string.Empty;
        [ValidateNever]
        public string Description { get; set; } = string.Empty;
        [ValidateNever]
        public DateTime Date { get; set; } = DateTime.Now;
        [ValidateNever]
        public string ImageName { get; set; } = string.Empty;
        [ValidateNever]
        public string ImageType { get; set; } = string.Empty;
        [ValidateNever]
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
        [ValidateNever]
        public List<QuizAnswer> Answers { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
