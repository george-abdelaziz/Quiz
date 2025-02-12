using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Mappers;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuizController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        [Route("{x:int}")]
        public async Task<IActionResult> GetLastAddedQuizzes([FromRoute] int x)
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
            var httpContext = _httpContextAccessor.HttpContext;
            var url = httpContext?.Request?.Host.Value;
            //var url = Url.Action("GetPhoto", "Photo", null, Request.Scheme);

            var orderedQuizzes = quizzes.Select(q => q.ToQuizDto(url + q.Id.ToString())).OrderByDescending(q => q.Date).Take(x).ToList();
            return Ok(orderedQuizzes);
        }


    }
}
