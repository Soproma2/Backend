using Homework_58_ASP___Library.Common;
using Homework_58_ASP___Library.Data;
using Homework_58_ASP___Library.DTOs.Responses;
using Homework_58_ASP___Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_58_ASP___Library.Services.LoanService
{
    public class LoanService : ILoanService
    {
        private readonly DataContext _context;

        public LoanService(DataContext context)
        {
            _context = context;
        }

        public Result<LoanResponse> BorrowBook(int bookId, int userId)
        {
            if (bookId <= 0)
                return Result<LoanResponse>.BadRequest("Invalid book ID");

            var book = _context.Books.Find(bookId);
            if (book == null)
                return Result<LoanResponse>.NotFound("Book not found");

            if (!book.IsAvailable)
                return Result<LoanResponse>.BadRequest("Book is not available");

            var user = _context.Users.Find(userId);
            if (user == null)
                return Result<LoanResponse>.NotFound("Member not found");

            var activeLoans = _context.Loans.Count(l => l.UserId == userId && !l.IsReturned);
            if (activeLoans >= 3)
                return Result<LoanResponse>.BadRequest("You have reached maximum loan limit (3)");

            var alreadyBorrowed = _context.Loans.Any(l => l.BookId == bookId && l.UserId == userId && !l.IsReturned);
            if (alreadyBorrowed)
                return Result<LoanResponse>.BadRequest("You already have this book");

            var loan = new Loan
            {
                BookId = bookId,
                UserId = userId,
                LoanDate = DateTime.Now,
            };

            book.IsAvailable = false;

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return Result<LoanResponse>.success("Book borrowed successfully", ToResponse(loan, book, user));
        }

        public Result<LoanResponse> ReturnBook(int loanId, int userId)
        {
            if (loanId <= 0)
                return Result<LoanResponse>.BadRequest("Invalid loan ID");

            var loan = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefault(l => l.Id == loanId);

            if (loan == null)
                return Result<LoanResponse>.NotFound("Loan not found");

            if (loan.UserId != userId)
                return Result<LoanResponse>.BadRequest("This loan does not belong to you");

            if (loan.IsReturned)
                return Result<LoanResponse>.BadRequest("Book already returned");

            loan.IsReturned = true;
            loan.ReturnDate = DateTime.Now;
            loan.Book.IsAvailable = true;

            _context.SaveChanges();

            return Result<LoanResponse>.success("Book returned successfully", ToResponse(loan, loan.Book, loan.User));
        }

        public Result<List<LoanResponse>> GetAll()
        {
            var loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToList();

            if (!loans.Any())
                return Result<List<LoanResponse>>.NotFound("No loans found");

            return Result<List<LoanResponse>>.success(null, loans.Select(l => ToResponse(l, l.Book, l.User)).ToList());
        }

        public Result<List<LoanResponse>> GetMyLoans(int memberId)
        {
            var loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .Where(l => l.UserId == memberId)
                .ToList();

            if (!loans.Any())
                return Result<List<LoanResponse>>.NotFound("No loans found");

            return Result<List<LoanResponse>>.success(null, loans.Select(l => ToResponse(l, l.Book, l.User)).ToList());
        }

        public Result<LoanResponse> GetById(int loanId, int userId)
        {
            if (loanId <= 0)
                return Result<LoanResponse>.BadRequest("Invalid loan ID");

            var loan = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefault(l => l.Id == loanId);

            if (loan == null)
                return Result<LoanResponse>.NotFound("Loan not found");

            if (loan.UserId != userId)
                return Result<LoanResponse>.BadRequest("Access denied");

            return Result<LoanResponse>.success(null, ToResponse(loan, loan.Book, loan.User));
        }

        private LoanResponse ToResponse(Loan loan, Book book, User user) => new LoanResponse
        {
            Id = loan.Id,
            BookId = book.Id,
            BookTitle = book.Title,
            BookAuthor = book.Author,
            MemberId = user.Id,
            MemberName = user.FullName,
            LoanDate = loan.LoanDate,
            ReturnDate = loan.ReturnDate,
            IsReturned = loan.IsReturned
        };
    }
}
