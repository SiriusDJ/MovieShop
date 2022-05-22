using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Movie>> GetTop30GrossingMovies()
        {
            // SQL database
            // data access logic
            // 1. ADO.NET (Microsoft) SQLConnection, SQLCommand
            // 2. Dapper (ORM) -> StackOverflow
            // 3. Entity Framework Core => LINQ
            // Select top 30 * from Movie order by Revenue
            // movies.orderbydescending(m=> m.Revenue).Take(30)

            // EF Core or Dapper
            // they provide both sync and async methods in those libraries

            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;


        }

        public override async Task<Movie> GetById(int id)
        {
            // we need to join Navigation properties
            // Include method in EF will enalb us to join with related navigation 
            var movie = await _dbContext.Movies.Include(m=> m.MoviesOfGenre).ThenInclude(m => m.Genre).
                Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            // FirstOrDefault safest one
            // First throws ex when 0 records
            // SingleOrDefault good for 0 or 1
            // Single throw ex when no records found or when more than 1 record is found
            return movie;
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            // get total movies count for that genre
            var totalMoviesCount = await _dbContext.MoviesGenres.Where(m => m.GenreId == genreId).CountAsync();

            // get the actual movies fro Movie Genre and Movie Table
            if (totalMoviesCountByGenre == 0)
            {
                throw new Exception("No Movies Found for that genre");

            }

            var movies = await _dbContext.MoviesGenres.Where(g => g.GenreId == genreId).Include(m => m.Movie)
                .OrderBy(m => m.MovieId)
                // list<moviegenre> to list<movie>
                .Select(m => new Movie
                {
                    Id = m.MovieId, 
                    PosterUrl = m.Movie.PosterUrl,
                    Title = m.Movie.Title
                })
                .Skip((pageNumber-1) * pageSize).Take(pageSize).ToListAsync();

            var pagedMovies = new PagedResultSet<Movie>(movies, pageNumber, pageSize, totalMoviesCountByGenre);
    }
}
