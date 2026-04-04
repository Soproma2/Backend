using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.DTOs.Requests.Registrations
{
    public record RegisterToActivityRequest(
        int ActivityId,
        RegistrationType RegistrationType,
        int? TeamId 
    );
}
