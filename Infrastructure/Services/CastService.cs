using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        public readonly ICastRepository _CastRepository;

        public CastService(ICastRepository castRepository)
        {
            _CastRepository = castRepository;
        }
        public async Task<CastDetailsModel> GetCastDetails(int id)
        {   
            var cast = await _CastRepository.GetById(id);
            var castDetails = new CastDetailsModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath
            };

            
            foreach(var movieCast in cast.MoviesOfCast)
            {
                //var movie = new MovieModel();
                //movie.MovieId = movieCast.Movie.Id;
                //movie.Character = movieCast.Character;
                //movie.Title = movieCast.Movie.Title;


                //castDetails.StarringMovieList.Add(new MovieModel { Title = "1", Character = "1", MovieId = 1});
                //castDetails.StarringMovieList.Add(movie);

                castDetails.StarringMovieList.Add(new MovieModel()
                {
                    MovieId = movieCast.Movie.Id,
                    Title = movieCast.Movie.Title,
                    Character = movieCast.Character
                });
                // var test = castDetails.StarringMovieList[castDetails.StarringMovieList.Count() - 1];
            }
            return castDetails;
           
        }
    }
}
