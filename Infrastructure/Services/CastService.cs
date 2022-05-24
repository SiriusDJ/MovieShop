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
                castDetails.MoviesOfCast.Add(new MovieModel() { Id = movieCast.Movie.Id, character = movieCast.Character});
            }
            return castDetails;
           
        }
    }
}
