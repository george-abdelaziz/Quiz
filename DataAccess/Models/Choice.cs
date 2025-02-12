using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public partial class Choice
{
    public int Id { get; set; }

    [MaxLength(250)]
    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; } = false;

    public int QuestionId { get; set; }

    [ValidateNever]
    public virtual Question Question { get; set; } = null!;
}
