using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WealthManagementAdvisory.DataLayer;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WealthManagementDbContext _dbContext;
        public UserRepository(WealthManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUserProfileAsync(User userProfile)
        {
            try
            {   
                _dbContext.Users.Add(userProfile);
                await _dbContext.SaveChangesAsync();

                return userProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<User> DeleteUserProfileAsync(int userId)
        {
            try
            {
                var userProfile = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                _dbContext.Users.Remove(userProfile);
                await _dbContext.SaveChangesAsync();

                return userProfile; 
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        public async Task<List<User>> GetAllUserProfileAsync()
        {
            try
            {
                var userProfiles = await _dbContext.Users.ToListAsync();
                return userProfiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserProfileAsync(int userId)
        {
            try
            {
                var userProfile = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == userId);


                return userProfile; 
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<User> UpdateUserProfileAsync(int userId, User updatedDetails)
        {
            try
            {
                var userProfile = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                userProfile.Income = updatedDetails.Income;
                userProfile.RiskAppetite = updatedDetails.RiskAppetite;
                userProfile.FinancialGoals = updatedDetails.FinancialGoals;

                await _dbContext.SaveChangesAsync();

                return userProfile; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
