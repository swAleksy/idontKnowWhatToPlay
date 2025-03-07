using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesTracker.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions){}


        public DbSet<Game> games { get; set; }
        public DbSet<GameTag> gameTags {get; set;}
        public DbSet<Tag> tags {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameTag>()
                .HasKey(gt => new { gt.GameId, gt.TagId });

            modelBuilder.Entity<GameTag>()
                .HasOne(gt => gt.Game)
                .WithMany(g => g.GameTags)
                .HasForeignKey(gt => gt.GameId);  

            modelBuilder.Entity<GameTag>()
                .HasOne(gt => gt.Tag)
                .WithMany(t => t.GameTags)
                .HasForeignKey(gt => gt.TagId);
        }
        
    }
}