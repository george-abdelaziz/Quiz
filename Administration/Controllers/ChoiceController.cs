using DataAccess.DTOs.ChoiceDtos;
using DataAccess.Interface;
using DataAccess.Mappers;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    [Authorize]
    public class ChoiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChoiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<Choice> choices = await _unitOfWork.Choices.GetAll();
            return View(choices);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Question");
            }
            return View(new CreateChoiceDto { QuestionId = id });
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateChoiceDto createChoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createChoiceDto);
            }

            var question = await _unitOfWork.Questions.Get(q => q.Id == createChoiceDto.QuestionId, true);
            if (question == null)
            {
                return NotFound("question not found / choice controller/ create action");
            }
            if (question.Choices.Count == 0)
            {
                createChoiceDto.IsCorrect = true;
            }
            question.IsMCQ = true;
            if (createChoiceDto.IsCorrect)
            {
                foreach (Choice questionChoice in question.Choices)
                {
                    questionChoice.IsCorrect = false;
                }
            }
            var choice = await _unitOfWork.Choices.Add(createChoiceDto.ToChoice());
            if (choice == null)
            {
                return NotFound("choice not found / choice controller / create action");
            }
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Question");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model invalid / choice controller / edit action / httpget");
            }
            var choice = await _unitOfWork.Choices.Get(q => q.Id == id);
            if (choice == null)
            {
                return NotFound("choice not found / choice controller / edit action / httpget");
            }
            return View(choice);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not valid / choice controller / edit action / httppost");
            }
            var question = await _unitOfWork.Questions.Get(q => q.Id == choice.QuestionId, true);
            if (question == null)
            {
                return NotFound("question not found / choice controller / edit action / httppost");
            }
            question.IsMCQ = true;
            if (choice.IsCorrect)
            {
                foreach (Choice questionChoice in question.Choices)
                {
                    questionChoice.IsCorrect = false;
                }
            }
            else
            {
                bool condi = false;
                foreach (Choice questionChoice in question.Choices)
                {
                    if (questionChoice.IsCorrect && questionChoice.Id != choice.Id)
                    {
                        condi = true;
                        break;
                    }
                }
                if (!condi)
                {
                    ModelState.AddModelError("Choice", "Choice can be false because it is the only true choice");
                    return View(choice);
                }
            }
            var updatedChoice = await _unitOfWork.Choices.Update(choice);
            if (updatedChoice == null) { return NotFound("Choice Not Found/Choice/Edit/post"); }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not valid / choice controller / delete action / httpget");
            }
            var choice = await _unitOfWork.Choices.Get(q => q.Id == id);
            if (choice == null)
            {
                return NotFound("choice not found / choice controller / delete action / httpget");
            }
            return View(choice);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not valid / choice controller / delete action / httpget");
            }
            var choice = await _unitOfWork.Choices.Get(c => c.Id == id);
            if (choice == null)
            {
                return NotFound("choice not found / choice controller / delete action / httpget");
            }
            var question = await _unitOfWork.Questions.Get(q => q.Id == choice.QuestionId);
            if (question != null)
            {
                if (question.Choices.Count == 1)
                {
                    question.IsMCQ = false;
                }
                if (choice.IsCorrect)
                {
                    foreach (Choice questionChoice in question.Choices)
                    {
                        if (questionChoice.Id != choice.Id)
                        {
                            questionChoice.IsCorrect = true;
                            break;
                        }
                    }
                }
            }
            _unitOfWork.Choices.Remove(choice);
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Choice");
        }
    }
}
