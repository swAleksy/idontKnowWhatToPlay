using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamesTracker.Models
{
    public class GameTag
    {
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game? Game { get; set; }


        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag? Tag { get; set; } 
    }
}