using DataAccess.DTOs.QuizDtos;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace DataAccess.Mappers
{
    public static class QuizMapper
    {
        public static DeleteQuizDto ToDeleteDto(this Quiz quiz)
        {
            return new DeleteQuizDto
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                Date = quiz.Date,
            };
        }
        public static Quiz ToQuiz(this EditQuizDto editQuizDto, byte[]? imageData)
        {
            string imageType = string.Empty;
            string imageName = string.Empty;
            if (editQuizDto.FormFile != null)
            {
                imageName = editQuizDto.FormFile.FileName;
                imageType = editQuizDto.FormFile.ContentType;
            }
            return new Quiz
            {
                Id = editQuizDto.Id,
                Name = editQuizDto.Name,
                Description = editQuizDto.Description,
                Date = editQuizDto.Date,
                ImageData = imageData,
                ImageName = imageName,
                ImageType = imageType
            };
        }

        public static EditQuizDto ToEditQuizDto(this Quiz quiz)
        {
            return new EditQuizDto
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                Date = quiz.Date,
            };
        }

        public static CreateQuizDto ToCreateQuizDto(this Quiz quiz)
        {

            byte[] imageData = quiz.ImageData;
            var stream = new MemoryStream(imageData);
            IFormFile reconstructedFile = new FormFile(stream, 0, stream.Length, "file", quiz.ImageName)
            {
                Headers = new HeaderDictionary(),
                ContentType = quiz.ImageType
            };
            return new CreateQuizDto
            {
                Name = quiz.Name,
                Description = quiz.Description,
                Date = quiz.Date,
                FormFile = reconstructedFile,
            };
        }

        public static Quiz ToQuiz(this CreateQuizDto createQuizDto, byte[] imageData)
        {
            return new Quiz
            {
                Name = createQuizDto.Name,
                Description = createQuizDto.Description,
                Date = createQuizDto.Date,
                ImageData = imageData,
                ImageName = createQuizDto.FormFile.FileName,
                ImageType = createQuizDto.FormFile.ContentType,
            };
        }
        public static QuizDto ToQuizDto(this Quiz quiz)
        {
            return new QuizDto
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                Date = quiz.Date,
                Image = quiz.ImageData,
                ImageName = quiz.ImageName,
                ImageType = quiz.ImageType,
                //Questions = quiz.Questions.Select(q => q.T()).ToList()
            };
        }
    }
}
