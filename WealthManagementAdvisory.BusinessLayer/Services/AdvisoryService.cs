using System;
using System.Threading.Tasks;
using WealthManagementAdvisory.BusinessLayer.Interfaces;
using WealthManagementAdvisory.BusinessLayer.Services.Repository;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services
{
    public class AdvisoryService : IAdvisoryService
    {
        private readonly IAdvisoryRepository _advisoryRepository;

        public AdvisoryService(IAdvisoryRepository advisoryRepository)
        {
            _advisoryRepository = advisoryRepository;
        }

        public async Task<Advisory> GetAdvisoryDetailsAsync(int advisoryId)
        {
            return await _advisoryRepository.GetAdvisoryDetailsAsync(advisoryId);
        }

        public async Task<Advisory> GetInvestmentRecommendationsAsync(int userId)
        {
            return await _advisoryRepository.GetInvestmentRecommendationsAsync(userId);
        }

        public async Task<Advisory> ScheduleAdvisorySessionAsync(int userId, DateTime preferredDate, string sessionType)
        {
            return await _advisoryRepository.ScheduleAdvisorySessionAsync(userId,preferredDate,sessionType);
        }
    }
}
