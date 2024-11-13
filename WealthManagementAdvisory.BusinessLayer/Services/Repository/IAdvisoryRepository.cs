using System;
using System.Threading.Tasks;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services.Repository
{
    public interface IAdvisoryRepository
    {
        Task<Advisory> GetInvestmentRecommendationsAsync(int userId);

        Task<Advisory> ScheduleAdvisorySessionAsync(int userId, DateTime preferredDate, string sessionType);
        Task<Advisory> GetAdvisoryDetailsAsync(int advisoryId);
    }
}
