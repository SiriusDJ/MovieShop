using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {

        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Trailer> Trailers { get; set; } 

        public DbSet<MovieGenre> MoviesGenres { get; set; }

        public DbSet<Crew> Crew { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }

        public DbSet<Cast> Cast { get; set; }

        public DbSet<MovieCast> MovieCast { get; set; }

        public DbSet<Review> Review { get; set; }
        public DbSet<User> Users { get; set; }  

        public DbSet<Purchase> Purchase { get; set; }

        public DbSet<Favorite> Favorite { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }



        // to use Fluent API you need to override OnModelCreating 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // you can specify the rules for Entity

            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCrew>(ConfigureCrew);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);

        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            //specify the fluent API way rules for Genre Table
            builder.ToTable("Genre");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();

        }
        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            // have MovieId and GenreId as PK
            // Table name to be MovieGenre
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new {mg.MovieId, mg.GenreId});
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Gender);
            builder.Property(x => x.TmdbUrl);
            builder.Property(x => x.ProfilePath).HasMaxLength(2048);
        }

        private void ConfigureCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(x => new { x.MovieId, x.CrewId });
            builder.Property(x => x.Department).HasMaxLength(128);
            builder.Property(x => x.Job).HasMaxLength(128);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Gender);
            builder.Property(x => x.TmdbUrl);
            builder.Property(x => x.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(x => new { x.MovieId, x.CastId });
            builder.Property(x => x.Character).HasMaxLength(450).IsRequired();
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(x => new { x.MovieId, x.UserId});
            builder.Property(x => x.Rating).HasPrecision(3, 2).IsRequired();
            builder.Property(x => x.ReviewText);

        }
        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
        }

    }

}
