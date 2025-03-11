using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.DTOs.Steam;
using GamesTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GamesTracker.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("fetch-and-save/{steamId}")]
        public async Task<IActionResult> FetchAndSaveGames(string steamId)
        {
            await _gameService.FetchAndSaveGamesAsync(steamId);
            return Ok("Games fetched and saved successfully!");
        }
    }

}