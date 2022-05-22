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

        public List<Movie> GetTop30GrossingMovies()
        {
            // SQL database
            // data access logic
            // 1. ADO.NET (Microsoft) SQLConnection, SQLCommand
            // 2. Dapper (ORM) -> StackOverflow
            // 3. Entity Framework Core => LINQ
            // Select top 30 * from Movie order by Revenue
            // movies.orderbydescending(m=> m.Revenue).Take(30)

            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;


        }

        public override Movie GetById(int id)
        {
            // we need to join Navigation properties
            // Include method in EF will enalb us to join with related navigation 
            var movie = _dbContext.Movies.Include(m=> m.MoviesOfGenre).ThenInclude(m => m.Genre).
                Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefault(m => m.Id == id);
            // FirstOrDefault safest one
            // First throws ex when 0 records
            // SingleOrDefault good for 0 or 1
            // Single throw ex when no records found or when more than 1 record is found
            return movie;
        }

    }
}
