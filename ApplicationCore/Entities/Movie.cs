﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }

        public string? Overview { get; set; }

        [MaxLength(512)]
        public string? Tagline { get; set; }


        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }

        [MaxLength(2048)]
        public string? ImdbUrl { get; set; }

        [MaxLength(2048)]
        public string? TmdbUrl { get; set; }

        [MaxLength(2048)]
        public string? PosterUrl { get; set; }

        [MaxLength(2048)]
        public string? BackdropUrl { get; set; }

        [MaxLength(64)]
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(4096)]
        public string? UpdatedBy { get; set; }

        [MaxLength(4096)]
        public string? CreatedBy { get; set; }

        // Navigation Property

        public ICollection<Trailer> Trailers { get; set; }

        public ICollection<MovieGenre> MoviesOfGenre { get; set; }

        public ICollection<MovieCrew> MoviesOfCrew { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
        
        public ICollection<Review> MovieReview  { get; set; }

        public ICollection<Purchase> MoviesOfPurchase{ get; set; }

        public ICollection<Favorite> MoviesOfFavorite { get; set; }

    }
}
