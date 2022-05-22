using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetTop30GrossingMovies();

        // totalcount, pagesize, pageNumber,Total Pages
        // what should we return ?
        // method 1: create new class pagemodel
        //Task<(IEnumerable<Movie>, int totalCount, int totalPages)> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1);
        // method 2: return tuple 

        Task<> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1);
    }
}
