using HomeWork42___Asp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork42___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly DataContext _db;
        public QuestionsController(DataContext db) { _db = db; }

        [HttpGet]
        public IActionResult getAllQuestion()
        {
            return Ok();
        }

        [HttpGet("question/{questionId}")]
        public IActionResult getQuestionById(int questionId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateQuestion()
        {
            return Ok();
        }

        [HttpPut("question/edit/{questionId}")]
        public IActionResult UpdateQuestion(int questionId)
        {
            return Ok();
        }

        [HttpDelete("question/delete/{questionId}")]
        public IActionResult DeleteQuestion(int questionId)
        {
            return Ok();
        }
    }
}
