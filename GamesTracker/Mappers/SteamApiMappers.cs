using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.DTOs.Steam;
using GamesTracker.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GamesTracker.Mappers
{
    public static class SteamApiMappers
    {
        public static IEnumerable<Game> MapOwnedGamesToModels(SteamOwnedGamesResponse response)
        {
            var games = new List<Game>();

            if (response == null || response.Response == null || response.Response.Games == null)
                return games;
            
            foreach(var game in response.Response.Games)
            {
                games.Add(new Game 
                {
                    Appid = game.AppId,
                    PlaytimeForever = game.PlaytimeForever,
                    LastPlayedTime = game.RtimeLastPlayed,
                    IsWishlisted = false,
                    GameTags = new List<GameTag>()
                });
            }

            return games;
        }

        public static IEnumerable<Game> MapWishlistToModels(SteamWishlistResponse response){
            var games = new List<Game>();

            if (response == null || response.Response == null || response.Response.Items == null)
                return games;
        
            foreach(var game in response.Response.Items)
            {
                games.Add(new Game 
                {
                    Appid = game.AppId,
                    IsWishlisted = true,
                    GameTags = new List<GameTag>()
                });
            }

            return games;
        }

    }
}