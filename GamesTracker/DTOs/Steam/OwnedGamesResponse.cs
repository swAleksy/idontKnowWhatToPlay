using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesTracker.DTOs.Steam
{
    public class OwnedGamesResponse
    {
        public int GameCount { get; set; }
        public List<OwnedGame> Games { get; set; } 
    }
}