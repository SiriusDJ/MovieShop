﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserLoginResponseModel> LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(UserRegisterModel model)
        {
            // go todatabase and check if the email exists already
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                //user already exists
                throw new ConflictException("Email already exists");
            }

            // create a random salt
            // create hashed password with the salt created above
            // Never ever create your own hashing algorithms
            // some hashing algorithm: Pdbkf2 (Microsoft), Bcrypt, Aargon2
            // save the user object to User table


        }

        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            Convert.FromBase64String(salt),
            KeyDerivationPrf.HMACSHA512,
            10000,
            256 / 8));
            return hashed;
        }
    }
}