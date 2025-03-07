using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesTracker.DTOs.Steam
{
    public class OwnedGame
    {
        public int AppId { get; set; }
        public int PlaytimeForever { get; set; }
        public int PlaytimeWindowsForever { get; set; }
        public int PlaytimeMacForever { get; set; }
        public int PlaytimeLinuxForever { get; set; }
        public int PlaytimeDeckForever { get; set; }
        public int RtimeLastPlayed { get; set; }
        public int PlaytimeDisconnected { get; set; }
    }
}