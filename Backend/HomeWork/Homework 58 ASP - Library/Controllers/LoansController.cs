using Homework_58_ASP___Library.Enums;
using Homework_58_ASP___Library.Services.LoanService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homework_58_ASP___Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult GetAll()
        {
            var result = _loanService.GetAll();
            return StatusCode(result.Status, result);
        }

        [HttpGet("my")]
        [Authorize(Roles = nameof(UserRole.User))]
        public IActionResult GetMyLoans()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _loanService.GetMyLoans(userId);
            return StatusCode(result.Status, result);
        }

        [HttpGet("{loanId}")]
        [Authorize]
        public IActionResult GetById(int loanId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _loanService.GetById(loanId, userId);
            return StatusCode(result.Status, result);
        }

        [HttpPost("borrow/{bookId}")]
        [Authorize(Roles = nameof(UserRole.User))]
        public IActionResult BorrowBook(int bookId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _loanService.BorrowBook(bookId, userId);
            return StatusCode(result.Status, result);
        }

        [HttpPut("return/{loanId}")]
        [Authorize(Roles = nameof(UserRole.User))]
        public IActionResult ReturnBook(int loanId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _loanService.ReturnBook(loanId, userId);
            return StatusCode(result.Status, result);
        }
    }
}
