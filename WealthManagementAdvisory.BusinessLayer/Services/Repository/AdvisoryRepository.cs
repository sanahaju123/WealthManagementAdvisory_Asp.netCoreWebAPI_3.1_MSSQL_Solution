using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WealthManagementAdvisory.DataLayer;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services.Repository
{
    public class AdvisoryRepository : IAdvisoryRepository
    {
        private readonly WealthManagementDbContext _dbContext;
        public AdvisoryRepository(WealthManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Advisory> GetAdvisoryDetailsAsync(int advisoryId)
        {
            try
            {
                var advisory = await _dbContext.Advisories
                    .FirstOrDefaultAsync(a => a.AdvisoryId == advisoryId);

                return advisory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Advisory> GetInvestmentRecommendationsAsync(int userId)
        {
            try
            {
                var userProfile = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                var advisory = new Advisory
                {
                    UserId = userId,
                    RecommendationDescription = $"Based on your risk appetite ({userProfile.RiskAppetite}) and goals, we suggest the following investments.",
                    AdvisoryDate = DateTime.Now
                };

                _dbContext.Advisories.Add(advisory);
                await _dbContext.SaveChangesAsync();

                return advisory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Advisory> ScheduleAdvisorySessionAsync(int userId, DateTime preferredDate, string sessionType)
        {
            try
            {
                var userProfile = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                var advisorySession = new Advisory
                {
                    UserId = userId,
                    AdvisoryDate = preferredDate,
                    RecommendationDescription = "Scheduled a session with an advisor.",
                };

                _dbContext.Advisories.Add(advisorySession);
                await _dbContext.SaveChangesAsync();

                return advisorySession;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}