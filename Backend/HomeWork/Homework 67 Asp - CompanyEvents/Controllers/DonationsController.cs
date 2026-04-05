using Homework_67_Asp___CompanyEvents.DTOs.Requests.Donations;
using Homework_67_Asp___CompanyEvents.Services.DonationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homework_67_Asp___CompanyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IDonationService _donationService;
        public DonationsController(IDonationService donationService) => _donationService = donationService;
        private int CurrentUserId =>
       int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost]
        public IActionResult Create([FromBody] CreateDonationRequest request)
        {
            var result = _donationService.CreateDonation(CurrentUserId, request);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return Ok(result.Data);
        }

        [HttpDelete("{donationId}/cancel")]
        public IActionResult CancelSubscription(int donationId)
        {
            var result = _donationService.CancelSubscription(CurrentUserId, donationId);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return Ok();
        }

        [HttpGet("my")]
        public IActionResult MyDonations()
        {
            var result = _donationService.GetByUser(CurrentUserId);
            return Ok(result.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _donationService.GetAll();
            return Ok(result.Data);
        }
    }
}
