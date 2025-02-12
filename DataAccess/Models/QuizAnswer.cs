using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class QuizAnswer
    {
        [ForeignKey("Email")]
        [ValidateNever]
        public string Email { get; set; }
        [ValidateNever]
        public int QuizId { get; set; }
        [ValidateNever]
        public int QuestionId { get; set; }
        [ValidateNever]
        public string QuestionAnswer { get; set; }
    }
}
