using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DataAccess.Models
{
    public class QuizAnswer
    {
        [ValidateNever]
        public string UserDataEmail { get; set; }
        [ValidateNever]
        public int QuizId { get; set; }
        [ValidateNever]
        public int QuestionId { get; set; }
        [ValidateNever]
        public string? QuestionAnswer { get; set; } = null;
    }
}
