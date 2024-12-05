using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NMDB_Common.Entities;

public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> movie { get; set; }
    public DbSet<Actor> actors { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId }); // Composite Key

        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Movie)
            .WithMany(m => m.MovieActors)
            .HasForeignKey(ma => ma.MovieId)
            .HasConstraintName("FK_movie_actors_Movies");

        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Actor)
            .WithMany(a => a.MovieActors)
            .HasForeignKey(ma => ma.ActorId)
            .HasConstraintName("FK_movie_actors_Actors");

        modelBuilder.Entity<MovieActor>()
            .Property(ma => ma.Role).HasMaxLength(100);

        modelBuilder.Entity<Season>()
            .HasOne(s => s.Show).WithMany(s => s.Seasons).HasForeignKey(s => s.ShowId);
        modelBuilder.Entity<Episode>()
            .HasOne(e => e.Season).WithMany(e => e.Episodes).HasForeignKey(e => e.SeasonId);
    }
}
