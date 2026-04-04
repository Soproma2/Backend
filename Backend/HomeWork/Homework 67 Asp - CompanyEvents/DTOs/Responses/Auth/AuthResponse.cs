namespace Homework_67_Asp___CompanyEvents.DTOs.Responses.Auth
{
    public record AuthResponse(
        string Token,
        string FullName,
        string Email,
        string Role
    );
}
