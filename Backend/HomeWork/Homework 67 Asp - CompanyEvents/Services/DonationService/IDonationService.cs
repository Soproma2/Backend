using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Donations;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Donations;

namespace Homework_67_Asp___CompanyEvents.Services.DonationService
{
    public interface IDonationService
    {
        Result<DonationResponse> CreateDonation(int userId, CreateDonationRequest request);
        Result CancelSubscription(int userId, int donationId);
        Result<List<DonationResponse>> GetByUser(int userId);
        Result<List<DonationResponse>> GetAll();
        void ProcessSubscriptions();
    }
}
