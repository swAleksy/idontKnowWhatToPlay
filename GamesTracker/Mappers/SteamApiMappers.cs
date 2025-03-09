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
        public static IEnumerable<OwnedGame> MapOwnedGamesToModels(SteamOwnedGamesResponse response)
        {
            var games = new List<OwnedGame>();

            if (response == null || response.Response == null || response.Response.Games == null)
                return games;
            
            foreach(var game in response.Response.Games)
            {
                games.Add(new OwnedGame 
                {
                    appid = game.appid,
                    playtime_forever = game.playtime_forever,
                    playtime_windows_forever = game.playtime_windows_forever,
                    playtime_mac_forever = game.playtime_mac_forever,
                    playtime_linux_forever = game.playtime_linux_forever,
                    playtime_deck_forever = game.playtime_deck_forever,
                    rtime_last_played = game.rtime_last_played,
                    playtime_disconnected = game.playtime_disconnected
                });
            }

            return games;
        }

        public static IEnumerable<WishlistItem> MapWishlistToModels(SteamWishlistResponse response){
            var games = new List<WishlistItem>();

            if (response == null || response.Response == null || response.Response.Items == null)
                return games;
        
            foreach(var game in response.Response.Items)
            {
                games.Add(new WishlistItem 
                {
                    appid = game.appid,
                    priority = game.priority,
                    date_added = game.date_added
                });
            }

            return games;
        }

    }
}