﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NMDB_DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("NMDB_Common.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("biography");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthdate");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("actors");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("director");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int")
                        .HasColumnName("episode_number");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int")
                        .HasColumnName("season_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("backdrop_url");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("director");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("genre");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("poster_url");

                    b.Property<double>("Rating")
                        .HasColumnType("double")
                        .HasColumnName("rating");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.Property<int>("Runtime")
                        .HasColumnType("int")
                        .HasColumnName("runtime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("movie");
                });

            modelBuilder.Entity("NMDB_Common.Entities.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("movie_id");

                    b.Property<int>("ActorId")
                        .HasColumnType("int")
                        .HasColumnName("actor_id");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("role_name");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("movie_actors");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<int>("EpisodeCount")
                        .HasColumnType("int")
                        .HasColumnName("episode_count");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("poster_url");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.Property<string>("SeasonName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("season_name");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int")
                        .HasColumnName("season_number");

                    b.Property<int>("ShowId")
                        .HasColumnType("int")
                        .HasColumnName("show_id");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("backdrop_url");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("genre");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("poster_url");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Episode", b =>
                {
                    b.HasOne("NMDB_Common.Entities.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("NMDB_Common.Entities.MovieActor", b =>
                {
                    b.HasOne("NMDB_Common.Entities.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_movie_actors_Actors");

                    b.HasOne("NMDB_Common.Entities.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_movie_actors_Movies");

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Season", b =>
                {
                    b.HasOne("NMDB_Common.Entities.Show", "Show")
                        .WithMany("Seasons")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Actor", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Movie", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Season", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("NMDB_Common.Entities.Show", b =>
                {
                    b.Navigation("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}
