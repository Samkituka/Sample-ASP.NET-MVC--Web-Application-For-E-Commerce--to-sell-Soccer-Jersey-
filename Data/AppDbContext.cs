using Microsoft.EntityFrameworkCore;
using SoccerJerseyPass.Models;
using System.Net;

namespace SoccerJerseyPass.Data
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Player_Jersey>().HasKey(pj => new
            {
                pj.PlayerId,
                pj.Soccer_JerseyId
            });

            modelBuilder.Entity<Player_Jersey>().HasOne(s => s.soccerjersey).WithMany(pj => pj.PlayerJersey).HasForeignKey(
                s => s.Soccer_JerseyId);

            modelBuilder.Entity<Player_Jersey>().HasOne(s => s.player).WithMany(pj => pj.player_Jersey).HasForeignKey(
                s => s.PlayerId);

            base.OnModelCreating (modelBuilder);
        
        }

        public DbSet<Soccer_Jersey> Soccer_Jerseys  { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Player_Jersey> Player_Jerseys { get; set; }


    }
}
