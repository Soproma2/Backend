using HomeWork42___Asp.Data;
using HomeWork42___Asp.DTOs;
using HomeWork42___Asp.Models;
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
            var questions = _db.Questions.ToList();
            if (!questions.Any())
            {
                return NotFound();
            }
            return Ok(questions);
        }

        [HttpGet("question/{questionId}")]
        public IActionResult getQuestionById(int questionId)
        {
            var question = _db.Questions.Find(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public IActionResult CreateQuestion(CreateDto req)
        {
            Question question = new Question()
            {
                QuestionText = req.QuestionText,
                OptionA = req.OptionA,
                OptionB = req.OptionB,
                OptionC = req.OptionC,
                CorrectAnswer = req.CorrectAnswer
            };

            _db.Questions.Add(question);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("question/edit/{questionId}")]
        public IActionResult UpdateQuestion(int questionId, UpdateDto req)
        {
            Question question = _db.Questions.Find(questionId);
            if (question == null)
            {
                return NotFound();
            }

            if(!string.IsNullOrWhiteSpace(question.QuestionText)) question.QuestionText = req.QuestionText;
            if (!string.IsNullOrWhiteSpace(question.OptionA)) question.OptionA = req.OptionA;
            if (!string.IsNullOrWhiteSpace(question.OptionB)) question.OptionB = req.OptionB;
            if (!string.IsNullOrWhiteSpace(question.OptionC)) question.OptionC = req.OptionC;
            if (!string.IsNullOrWhiteSpace(question.CorrectAnswer)) question.CorrectAnswer = req.CorrectAnswer;

            _db.SaveChanges();
            return Ok(question);
        }

        [HttpDelete("question/delete/{questionId}")]
        public IActionResult DeleteQuestion(int questionId)
        {
            var question = _db.Questions.Find(questionId);
            if (question == null)
            {
                return NotFound();
            }

            _db.Questions.Remove(question);
            _db.SaveChanges();
            return Ok();
        }
    }
}
