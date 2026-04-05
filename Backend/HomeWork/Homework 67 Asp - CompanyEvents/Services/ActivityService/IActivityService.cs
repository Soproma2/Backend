using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Activities;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Activities;
using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.Services.ActivityService
{
    public interface IActivityService
    {
        Result<List<ActivityResponse>> GetAll(ActivityType? type = null);
        Result<ActivityResponse> GetById(int id);
        Result<ActivityResponse> Create(CreateActivityRequest request);
        Result<ActivityResponse> Update(int id, UpdateActivityRequest request);
        Result Delete(int id);
    }
}
