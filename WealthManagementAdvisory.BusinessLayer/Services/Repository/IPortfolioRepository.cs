using System.Threading.Tasks;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services.Repository
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> AddPortfolioAsync(Portfolio portfolio);
        Task<Portfolio> ViewPortfolioAsync(int userId);
        Task<Portfolio> RebalancePortfolioAsync(int userId, Portfolio targetAllocation);
    }
}
