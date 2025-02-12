using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebAPI.DTOs.QuizDtos;
using WebAPI.DTOs.TakeQuizDtos;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        public HomeController(IUnitOfWork unitOfWork, IHttpClientFactory clientFactory, HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _clientFactory = clientFactory;
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7172/api/Frontend");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var apiData = JsonSerializer.Deserialize<List<QuizDto>>(jsonString, options);
                return Json(new { data = apiData });
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7172/api/Frontend/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var apiData = JsonSerializer.Deserialize<TakeQuizDto>(jsonString, options);
                return View(apiData);
            }
            return BadRequest("error");
        }

        [HttpPost]
        public async Task<IActionResult>Details(TakeQuizDto quizDto)
        {
            var jsonContent = JsonSerializer.Serialize(quizDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7172/api/Frontend", content);
            if(response == null || !response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return BadRequest($"Error: {errorContent}");
                //ModelState.AddModelError(string.Empty, "An error occurred while sending data.");
            }
            return RedirectToAction("Index", "Home");
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
