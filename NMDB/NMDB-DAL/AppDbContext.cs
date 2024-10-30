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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies)
            .UsingEntity<Dictionary<string, object>>(
                "movie_actors",
                j => j
                    .HasOne<Actor>()
                    .WithMany()
                    .HasForeignKey("actor_id")
                    .HasConstraintName("FK_movie_actors_Actors"),
                j => j
                    .HasOne<Movie>()
                    .WithMany()
                    .HasForeignKey("movie_id")
                    .HasConstraintName("FK_movie_actors_Movies"),
                j =>
                {
                    j.Property<int>("movie_id");
                    j.Property<int>("actor_id");
                    j.HasKey("movie_id", "actor_id");
                });

        modelBuilder.Entity<Season>()
            .HasOne(s => s.Show).WithMany(s => s.Seasons).HasForeignKey(s => s.ShowId);
        modelBuilder.Entity<Episode>()
            .HasOne(e => e.Season).WithMany(e => e.Episodes).HasForeignKey(e => e.SeasonId);
    }
}
