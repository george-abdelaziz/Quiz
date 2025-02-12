using DataAccess.DTOs.QuizDtos;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.TakeQuizDtos;
using WebAPI.Mappers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontendController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        public FrontendController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var quizzes = await _unitOfWork.Quizzes.GetAll(include: true);
            if (quizzes == null)
            {
                return NotFound("There is no quizzes");
            }
            var quizzesDto = quizzes.Select(q => q.ToQuizDto(q.Id.ToString())).ToList();
            return Ok(quizzesDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == id, include: true);
            if (quiz == null)
            {
                return NotFound("There is no quizzes");
            }
            var quizDto = quiz.ToTakeQuizDto();
            return Ok(quizDto);
        }

        [HttpPost]
        public async Task<IActionResult> Details([FromForm]TakeQuizDto quizDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}

