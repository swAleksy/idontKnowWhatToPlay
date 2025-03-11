using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.Data;
using GamesTracker.DTOs.Game;
using GamesTracker.Models;

namespace GamesTracker.Services
{
    public interface IGameService
    {
        // Task SaveGamesAsync(List<GameDto> gameDtos);
        Task FetchAndSaveGamesAsync(string steamId);
    }

    public class GameService : IGameService
    {
        private readonly ApplicationDBContext _context;
        private readonly ISteamService _steamService;
        private readonly IDtoConvertService _dtoConvertService;

        public GameService (ApplicationDBContext context, ISteamService steamService, IDtoConvertService dtoConvertService)
        {
            _context = context;
            _steamService = steamService;
            _dtoConvertService = dtoConvertService;
        }

        public async Task FetchAndSaveGamesAsync(string steamId)
        {
            //var ownedGames = await _steamService.GetOwnedGamesAsync(steamId);
            var wishlistGames = await _steamService.GetWishlistAsync(steamId);

            //var gameDtos = await _dtoConvertService.ConvertToNewDtoAsync(ownedGames, wishlistGames);
            var gameDtos = await _dtoConvertService.ConvertToNewDtoSndAsync(wishlistGames);

            var games = gameDtos.Select(dto => new Game{
                Appid = dto.Appid,
                PlaytimeForever = dto.PlaytimeForever,
                LastPlayedTime = dto.LastPlayedTime,
                IsWishlisted = dto.IsWishlisted,
                GameName = dto.GameName,
                ThumbnailURL = dto.ThumbnailURL,
                GameTags = dto.GameTags
            });
            
            _context.games.AddRange(games);
            await _context.SaveChangesAsync(); 
        }
        // public async Task SaveGamesAsync(List<GameDto> gameDtos)
        // {
        //     var games = gameDtos.Select(dto => new Game{
        //         Appid = dto.Appid,
        //         PlaytimeForever = dto.PlaytimeForever,
        //         LastPlayedTime = dto.LastPlayedTime,
        //         IsWishlisted = dto.IsWishlisted,
        //         GameName = dto.GameName,
        //         ThumbnailURL = dto.ThumbnailURL,
        //         GameTags = dto.GameTags
        //     });

        //     _context.games.AddRange(games);
        //     await _context.SaveChangesAsync();
        // }
    }
}