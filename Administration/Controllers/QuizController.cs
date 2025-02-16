using DataAccess.DTOs.QuizDtos;
using DataAccess.Interface;
using DataAccess.Mappers;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuizController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<Quiz> quizzes = await _unitOfWork.Quizzes.GetAll();
            return View(quizzes);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateQuizDto newQuiz)
        {
            if (!ModelState.IsValid)
            {
                return View(newQuiz);
            }
            if (newQuiz.FormFile == null || newQuiz.FormFile.Length == 0)
            {
                ModelState.AddModelError("photo", "Please select a photo to upload.");
                return View(newQuiz);
            }
            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                await newQuiz.FormFile.CopyToAsync(memoryStream);
                data = memoryStream.ToArray();
            }
            var quiz = newQuiz.ToQuiz(data);
            await _unitOfWork.Quizzes.Add(quiz);
            await _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound("quiz not found / quiz controller / edit httpget");
            }
            return View(quiz.ToEditQuizDto());
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Edit(EditQuizDto editQuizDto)
        {
            if (!ModelState.IsValid) { return View(editQuizDto); }
            byte[] data;
            Quiz quiz = editQuizDto.ToQuiz(null);
            if (editQuizDto.FormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await editQuizDto.FormFile.CopyToAsync(memoryStream);
                    data = memoryStream.ToArray();
                }
                quiz = editQuizDto.ToQuiz(data);
            }
            await _unitOfWork.Quizzes.Update(quiz);
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Quiz");
        }

        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"bad request / quiz controller / delete action httpget ${ModelState}");
            }
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound("quiz not found / quiz controller / delete action httpget");
            }

            return View(quiz.ToDeleteDto());
        }

        [HttpPost, ActionName("Delete")]
        //[Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"bad request / quiz controller / delete action httpget ${ModelState}");
            }
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound("quiz not found / quiz controller / delete action httpget");
            }
            _unitOfWork.Quizzes.Remove(quiz);
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Quiz");
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var quiz = await _unitOfWork.Quizzes.Get(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            if (quiz.ImageData == null)
            {
                return NotFound();
            }
            return File(quiz.ImageData, quiz.ImageType);
        }
    }
}
