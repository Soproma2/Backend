namespace Homework_58_ASP___Library.DTOs.Responses
{
    public class LoanResponse
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
