namespace WebAPI.DTOs.ChoiceDtos
{
    public class ChoiceDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        //public int QuestionId { get; set; }
        //[ValidateNever]
        //public virtual Question Question { get; set; } = null!;
    }
}
