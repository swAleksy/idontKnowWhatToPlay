using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesTracker.Models
{
    public class Game
    {
        public int Id {get; set;}
        public int Appid {get; set;}
        public int? PlaytimeForever	{get; set;}
        public int? LastPlayedTime {get; set;}
        public bool IsWishlisted {get; set;}
        public string GameName {get; set;} = string.Empty;
        public string ThumbnailURL {get; set;} = string.Empty;
        public ICollection<GameTag>? GameTags { get; set; } = new List<GameTag>();
    }
}