using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async override Task<User> Get(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<Purchase> GetPurchaseByUserAndMovie(int userId, int movieId)
        {
            var purchase = await _dbContext.Purchase.FirstOrDefaultAsync(u => u.MovieId == movieId && u.UserId == userId);
            return purchase;
        }

    }
}
