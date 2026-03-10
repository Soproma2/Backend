using Homework_58_ASP___Library.Common;
using Homework_58_ASP___Library.DTOs.Responses;

namespace Homework_58_ASP___Library.Services.LoanService
{
    public interface ILoanService
    {
        Result<LoanResponse> BorrowBook(int bookId, int memberId);
        Result<LoanResponse> ReturnBook(int loanId, int memberId);
        Result<List<LoanResponse>> GetAll();
        Result<List<LoanResponse>> GetMyLoans(int memberId);
        Result<LoanResponse> GetById(int loanId, int memberId);
    }
}
