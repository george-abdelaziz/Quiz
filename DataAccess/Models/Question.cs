using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public partial class Question
{
    public int Id { get; set; }
    [MaxLength(500)]
    public string Text { get; set; } = string.Empty;
    public bool IsMCQ { get; set; } = false;
    public int QuizId { get; set; }
    [ValidateNever]
    public virtual Quiz Quiz { get; set; }
    [ValidateNever]
    public virtual ICollection<Choice> Choices { get; set; } = new List<Choice>();
}
