using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhotoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPhoto([FromRoute] int id)
        {
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            return File(quiz.ImageData, quiz.ImageType);
        }
    }
}
