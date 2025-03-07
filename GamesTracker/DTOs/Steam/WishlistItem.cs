using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesTracker.DTOs.Steam
{
    public class WishlistItem
    {
        public int AppId { get; set; }
        public int Priority { get; set; }
        public int DateAdded { get; set; }        
    }
}