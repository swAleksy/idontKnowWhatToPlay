using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesTracker.DTOs.Steam
{
    public class WishlistItem
    {
        public int appid { get; set; }
        public int priority { get; set; }
        public long date_added { get; set; }        
    }
}