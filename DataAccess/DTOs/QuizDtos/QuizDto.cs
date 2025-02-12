using DataAccess.Models;

namespace DataAccess.DTOs.QuizDtos
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public string ImageName { get; set; }

        public string ImageType { get; set; }

        public byte[] Image { get; set; }


        //public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    }
}
