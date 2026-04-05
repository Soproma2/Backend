using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Registrations;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Registrations;

namespace Homework_67_Asp___CompanyEvents.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Result<RegistrationResponse> Register(int userId, RegisterToActivityRequest request);
        Result Unregister(int userId, int activityId);
        Result<List<RegistrationResponse>> GetByActivity(int activityId);
        Result<List<RegistrationResponse>> GetByUser(int userId);
    }
}
