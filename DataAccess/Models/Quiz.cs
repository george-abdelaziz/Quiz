using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public partial class Quiz
{
    public int Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now;

    [ValidateNever]
    [MaxLength(250)]
    public string ImageName { get; set; } = string.Empty;

    [ValidateNever]
    [MaxLength(50)]
    public string ImageType { get; set; } = string.Empty;

    [ValidateNever]
    public byte[]? ImageData { get; set; }

    [ValidateNever]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
