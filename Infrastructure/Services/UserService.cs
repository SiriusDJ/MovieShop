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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAllPurchasesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            int movieId = purchaseRequest.MovieId;
            var purchase = await _userRepository.GetPurchaseByUserAndMovie(userId, movieId);
            if(purchase == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ReviewRequestModel> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            if (await IsMoviePurchased(purchaseRequest, userId))
            {
                var reviewRequest = new ReviewRequestModel()
                {
                    UserId = userId,

                };
                return reviewRequest;
            }
            else
            {
                throw new Exception("You already purchased the movie!");
            }
        }

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }
    }
}
