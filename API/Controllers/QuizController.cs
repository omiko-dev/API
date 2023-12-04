using API.Repository.Quiz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository repository;

        public QuizController(IQuizRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult getAllQuiz()
        {
            return Ok(repository.GetAllQuizModels());
        }

        [HttpGet("id")]
        public IActionResult fun(int id)
        {
            return Ok(repository.GetQuizModel(id));
        }

    }
}
