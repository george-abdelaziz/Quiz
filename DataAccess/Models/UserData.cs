using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UserData
    {
        [Key]
        public string Email { get; set; }
        public List<QuizAnswer> QuizAnswers { get; set; }
    }
}
