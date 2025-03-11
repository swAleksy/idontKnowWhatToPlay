using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.DTOs.Steam;
using GamesTracker.Models;

namespace GamesTracker.DTOs.Game
{
    public class GameDto
    {
        public int Appid {get; set;}
        public int? PlaytimeForever	{get; set;}
        public int? LastPlayedTime {get; set;}
        public bool IsWishlisted {get; set;}
        public string GameName {get; set;}
        public string ThumbnailURL {get; set;}
        public ICollection<GameTag>? GameTags { get; set; }


        public GameDto (OwnedGame ownedGame, string gameName, string ThumbURL) {
            Appid = ownedGame.appid;
            PlaytimeForever = ownedGame.playtime_forever;
            LastPlayedTime = ownedGame.rtime_last_played;
            IsWishlisted = false;
            GameName = gameName;
            ThumbnailURL = ThumbURL;
        }
        public GameDto (WishlistItem wishlistItem, string gameName, string ThumbURL) {
            Appid = wishlistItem.appid;
            IsWishlisted = true;
            GameName = gameName;
            ThumbnailURL = ThumbURL;
        }
    }
}