using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.Models;

namespace GamesTracker.DTOs.Game
{
    public class GameDto
    {
        public int AppId { get; set; }
        public string Name { get; set; }
        public string ThumbnailURL { get; set; }
        public ICollection<GameTag> GameTags { get; set; }
    }
}