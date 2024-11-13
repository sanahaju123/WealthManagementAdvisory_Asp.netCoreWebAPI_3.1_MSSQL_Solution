using System.Threading.Tasks;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Interfaces
{
    public interface IPortfolioService
    {
        Task<Portfolio> AddPortfolioAsync(Portfolio portfolio);
        Task<Portfolio> ViewPortfolioAsync(int userId);
        Task<Portfolio> RebalancePortfolioAsync(int userId, Portfolio targetAllocation);
    }
}
