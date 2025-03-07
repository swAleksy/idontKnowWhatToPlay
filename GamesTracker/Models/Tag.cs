using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesTracker.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public ICollection<GameTag>? GameTags { get; set; }
    }
}