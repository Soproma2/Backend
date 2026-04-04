namespace Homework_67_Asp___CompanyEvents.DTOs.Responses.Registrations
{
    public record RegistrationResponse(
        int Id,
        int UserId,
        string UserFullName,
        int ActivityId,
        string ActivityTitle,
        string RegistrationType,
        string? TeamName,
        DateTime RegisteredAt
    );
}
