using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Details([FromBody] List<QuizAnswer> quizAnswers)
        {
            if (!ModelState.IsValid || quizAnswers == null || quizAnswers.Count == 0)
            {
                return BadRequest(ModelState);
            }
            var simpleUser = await _unitOfWork.UserDatas.Get(u => u.Email == quizAnswers[0].UserDataEmail);
            if (simpleUser == null)
            {
                simpleUser = await _unitOfWork.UserDatas.Add(new UserData { Email = quizAnswers[0].UserDataEmail });
                await _unitOfWork.Save();
            }
            foreach (var answer in quizAnswers)
            {
                QuizAnswer userAnswer = await _unitOfWork.QuizzesAnswer.Get(a => a.UserDataEmail == answer.UserDataEmail && a.QuizId == answer.QuizId && a.QuestionId == answer.QuestionId);
                if (userAnswer == null)
                {
                    await _unitOfWork.QuizzesAnswer.Add(answer);
                }
                else
                {
                    userAnswer.QuestionAnswer = answer.QuestionAnswer;
                }

            }
            await _unitOfWork.Save();
            return Ok();
        }
    }
}

