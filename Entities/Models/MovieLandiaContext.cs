using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class MovieLandiaContext : DbContext
    {
        public MovieLandiaContext()
        {
        }

        public MovieLandiaContext(DbContextOptions<MovieLandiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Episode> Episodes { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieGenre> MovieGenres { get; set; } = null!;
        public virtual DbSet<Serie> Series { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OU311RG;Database=MovieLandia;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("TRIAL");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasComment("TRIAL");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk__User_0");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.ToTable("Episode");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasComment("TRIAL");

                entity.Property(e => e.PhotoSrc)
                    .HasColumnType("text")
                    .HasColumnName("photoSrc")
                    .HasComment("TRIAL");

                entity.Property(e => e.SerieId)
                    .HasColumnName("serieId")
                    .HasComment("TRIAL");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title")
                    .HasComment("TRIAL");

                entity.Property(e => e.VideoSrc)
                    .HasColumnType("text")
                    .HasColumnName("videoSrc")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.SerieId)
                    .HasConstraintName("fk_Comment_Serie_0");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movieId")
                    .HasComment("TRIAL");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_Episode_Movie_0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_Episode_User_1");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .HasColumnType("text")
                    .HasColumnName("name")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasComment("TRIAL");

                entity.Property(e => e.Duration)
                    .HasColumnType("text")
                    .HasColumnName("duration")
                    .HasComment("TRIAL");

                entity.Property(e => e.PhotoSrc)
                    .HasColumnType("text")
                    .HasColumnName("photoSrc")
                    .HasComment("TRIAL");

                entity.Property(e => e.RatingImdb)
                    .HasColumnName("ratingImdb")
                    .HasDefaultValueSql("((5.0))")
                    .HasComment("TRIAL");

                entity.Property(e => e.ReleaseYear)
                    .HasColumnName("releaseYear")
                    .HasDefaultValueSql("((2020))")
                    .HasComment("TRIAL");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title")
                    .HasComment("TRIAL");

                entity.Property(e => e.TrailerSrc)
                    .HasColumnType("text")
                    .HasColumnName("trailerSrc")
                    .HasComment("TRIAL");

                entity.Property(e => e.VideoSrc)
                    .HasColumnType("text")
                    .HasColumnName("videoSrc")
                    .HasComment("TRIAL");

                entity.Property(e => e.Views)
                    .HasColumnName("views")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.ToTable("MovieGenre");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genreId")
                    .HasComment("TRIAL");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movieId")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("fk_Movie_Genre_0");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_Movie_Movie_1");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("Serie");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.PhotoSrc)
                    .HasColumnType("text")
                    .HasColumnName("photoSrc")
                    .HasComment("TRIAL");

                entity.Property(e => e.RatingImdb)
                    .HasColumnName("ratingImdb")
                    .HasDefaultValueSql("((5.0))")
                    .HasComment("TRIAL");

                entity.Property(e => e.ReleaseYear)
                    .HasColumnName("releaseYear")
                    .HasDefaultValueSql("((2020))")
                    .HasComment("TRIAL");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email")
                    .HasComment("TRIAL");

                entity.Property(e => e.Password)
                    .HasColumnType("text")
                    .HasColumnName("password")
                    .HasComment("TRIAL");

                entity.Property(e => e.UserName)
                    .HasColumnType("text")
                    .HasColumnName("userName")
                    .HasComment("TRIAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
