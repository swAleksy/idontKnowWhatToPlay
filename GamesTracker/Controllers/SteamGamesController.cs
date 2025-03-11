using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using GamesTracker.Data;
using GamesTracker.DTOs.Steam;
using GamesTracker.Mappers;
using GamesTracker.Models;
using GamesTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GamesTracker.Controllers
{
    [ApiController]
    [Route("api/steam")]
    public class SteamGamesController : ControllerBase
    {
        private readonly ISteamService _steamService;

        public SteamGamesController(ISteamService steamService)
        {
            _steamService = steamService;
        }

        [HttpGet("{steamId}")] 
        public async Task<ActionResult<IEnumerable<OwnedGame>>> GetOwnedGames(string steamId)
        {
            try
            {
                if( string.IsNullOrEmpty(steamId))
                    return BadRequest("Steam id is requred");

                var games = await _steamService.GetOwnedGamesAsync(steamId);
                return Ok(games);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(503, "Unable to communicate with Steam API");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error retrieving Steam library: {e.Message}");
            }
        }

        [HttpGet("wishlist/{steamId}")]
        public async Task<ActionResult<IEnumerable<WishlistItem>>> GetWishlist(string steamId)
        {
            try
            {
                if( string.IsNullOrEmpty(steamId))
                    return BadRequest("Steam id is requred");

                var wishlistGames = await _steamService.GetWishlistAsync(steamId);
                return Ok(wishlistGames);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(503, $"Unable to communicate with Steam API: {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error retrieving Steam library: {e.Message}");
            }
        }

    }
}