using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.DTOs.Game;
using GamesTracker.DTOs.Steam;
using GamesTracker.Models;

namespace GamesTracker.Services
{
    public interface IDtoConvertService
    {
        Task<IEnumerable<GameDto>> ConvertToNewDtoAsync(IEnumerable<OwnedGame> dto1List, IEnumerable<WishlistItem> dto2List);
        Task<IEnumerable<GameDto>> ConvertToNewDtoSndAsync(IEnumerable<WishlistItem> dto1List);
    }

    public class DtoConvertService : IDtoConvertService
    {
        private readonly ISteamService _steamService;
        public DtoConvertService(ISteamService steamService)
        {
            _steamService = steamService;
        }
        public async Task<IEnumerable<GameDto>> ConvertToNewDtoAsync(IEnumerable<OwnedGame> dto1List, IEnumerable<WishlistItem> dto2List)
        {
            var newDtos = new List<GameDto>();

            foreach(var game in dto1List)
            {
                var gameDetails = await _steamService.GetGameDetailsAsync(game.appid.ToString());
                newDtos.Add(new GameDto(
                    game,
                    gameDetails?.Name ?? "Unknown Game",
                    gameDetails?.HeaderImage ?? "No Image"
                ));
            }
            
            foreach(var game in dto2List)
            {
                var gameDetails = await _steamService.GetGameDetailsAsync(game.appid.ToString());
                newDtos.Add(new GameDto(
                    game,
                    gameDetails?.Name ?? "Unknown Game",
                    gameDetails?.HeaderImage ?? "No Image"
                ));
            }

            return newDtos;
        }
                public async Task<IEnumerable<GameDto>> ConvertToNewDtoSndAsync(IEnumerable<WishlistItem> dto1List)
        {
            var newDtos = new List<GameDto>();

            foreach(var game in dto1List)
            {
                var gameDetails = await _steamService.GetGameDetailsAsync(game.appid.ToString());
                newDtos.Add(new GameDto(
                    game,
                    gameDetails?.Name ?? "Unknown Game",
                    gameDetails?.HeaderImage ?? "No Image"
                ));
            }
            return newDtos;
        }
    }
}