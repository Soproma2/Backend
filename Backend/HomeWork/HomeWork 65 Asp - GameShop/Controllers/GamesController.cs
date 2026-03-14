using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Requests;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Enums;
using HomeWork_65_Asp___GameShop.Services.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_65_Asp___GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gameService;
        public GamesController(IGamesService gameService) => _gameService = gameService;

        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpGet]
        [ProducesResponseType(typeof(Result<List<GameResponse>>), 200)]
        public IActionResult GetAll()
            => StatusCode(_gameService.GetAll().Status, _gameService.GetAll());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<GameResponse>), 200)]
        [ProducesResponseType(typeof(Result<GameResponse>), 404)]
        public IActionResult GetById(int id)
        {
            var result = _gameService.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(Result<List<GameResponse>>), 200)]
        public IActionResult Search([FromQuery] string query)
        {
            var result = _gameService.Search(query);
            return StatusCode(result.Status, result);
        }

        [HttpGet("filter")]
        [ProducesResponseType(typeof(Result<List<GameResponse>>), 200)]
        public IActionResult Filter([FromQuery] string? genre, [FromQuery] string? platform,
            [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var result = _gameService.Filter(genre, platform, minPrice, maxPrice);
            return StatusCode(result.Status, result);
        }

        [HttpGet("my")]
        [Authorize(Roles = nameof(UserRole.Seller))]
        [ProducesResponseType(typeof(Result<List<GameResponse>>), 200)]
        public IActionResult GetMyGames()
        {
            var result = _gameService.GetMyGames(GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Seller))]
        [ProducesResponseType(typeof(Result<GameResponse>), 200)]
        [ProducesResponseType(typeof(Result<GameResponse>), 400)]
        public IActionResult Create([FromBody] CreateGameReq req)
        {
            var result = _gameService.Create(req, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Seller))]
        [ProducesResponseType(typeof(Result<GameResponse>), 200)]
        [ProducesResponseType(typeof(Result<GameResponse>), 400)]
        public IActionResult Update(int id, [FromBody] UpdateGameReq req)
        {
            var result = _gameService.Update(id, req, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Seller))]
        [ProducesResponseType(typeof(Result<GameResponse>), 200)]
        [ProducesResponseType(typeof(Result<GameResponse>), 404)]
        public IActionResult Delete(int id)
        {
            var result = _gameService.Delete(id, GetUserId());
            return StatusCode(result.Status, result);
        }
    }
}
