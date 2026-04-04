namespace Homework_67_Asp___CompanyEvents.DTOs.Requests.Auth
{
    public record RegisterRequest(
        string FullName,
        string Email,
        string Password
    );
}
