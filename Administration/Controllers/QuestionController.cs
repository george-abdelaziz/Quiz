using DataAccess.DTOs.QuestionDtos;
using DataAccess.Interface;
using DataAccess.Mappers;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model is not valid / question controller / index action  \n ${ModelState}");
            }
            ICollection<Question> questions = await _unitOfWork.Questions.GetAll();
            if (questions == null)
            {
                return NotFound("questions not found / question controller / index action");
            }
            return View(questions);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model is not valid / question controller / create httpget action  \n ${ModelState}");
            }
            return View(new CreateQuestionDto { QuizId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionDto newQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View(newQuestion);
            }
            await _unitOfWork.Questions.Add(newQuestion.ToQuestion());
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Quiz");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model is not valid / question controller / edit httpget action  \n ${ModelState}");
            }
            var question = await _unitOfWork.Questions.Get(q => q.Id == id);
            if (question == null)
            {
                return NotFound("question not found / question controller / edit httpget action");
            }
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model is not valid / question controller / edit httppost action  \n ${ModelState}");
            }
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == question.QuizId);
            if (quiz == null)
            {
                return NotFound("quiz not found / question conttroller / edit httppost action");
            }
            if (!question.IsMCQ)
            {
                //var questionFromDb = await _unitOfWork.Questions.;
                var choiceList = await _unitOfWork.Choices.GetAll(c => c.QuestionId == question.Id);
                if (choiceList != null)
                {
                    _unitOfWork.Choices.RemoveRange(choiceList);
                }
            }
            await _unitOfWork.Questions.Update(question);
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Question");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model is not valid / question controller / delete httpget action  \n ${ModelState}");
            }
            var question = await _unitOfWork.Questions.Get(q => q.Id == id);
            if (question == null)
            {
                return NotFound("question not found / question controller / delete httpget action");
            }
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Model is not valid / question controller / edit httppost action  \n ${ModelState}");
            }
            var question = await _unitOfWork.Questions.Get(q => q.Id == id);
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == question.QuizId);
            if (quiz == null)
            {
                return NotFound("quiz not found(meaning: the question doesnt have quiz,how?) / question conttroller / edit httppost action");
            }
            _unitOfWork.Questions.Remove(question);
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Question");
        }
    }
}
