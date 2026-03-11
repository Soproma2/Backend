using HomeWork_60___ASP_Cars.Common;
using HomeWork_60___ASP_Cars.DTOs.Responses;

namespace HomeWork_60___ASP_Cars.Services.PurchaseService
{
    public interface IPurchaseService
    {
        Result<PurchaseResponse> Buy(int carId, int buyerId);
        Result<List<PurchaseResponse>> GetMyPurchases(int buyerId);
    }
}
