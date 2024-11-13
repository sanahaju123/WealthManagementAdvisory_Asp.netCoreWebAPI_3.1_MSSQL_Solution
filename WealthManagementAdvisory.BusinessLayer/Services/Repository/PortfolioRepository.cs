using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WealthManagementAdvisory.DataLayer;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly WealthManagementDbContext _dbContext;
        public PortfolioRepository(WealthManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Portfolio> AddPortfolioAsync(Portfolio portfolio)
        {
            try
            {
                var existingPortfolio = await _dbContext.Portfolios
                    .FirstOrDefaultAsync(p => p.UserId == portfolio.UserId);

                _dbContext.Portfolios.Add(portfolio);
                await _dbContext.SaveChangesAsync();

                return portfolio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Portfolio> RebalancePortfolioAsync(int userId, Portfolio targetAllocation)
        {
            try
            {
                var portfolio = await _dbContext.Portfolios
                    .FirstOrDefaultAsync(p => p.UserId == userId);

                portfolio.AssetAllocation = targetAllocation.AssetAllocation;
                portfolio.TotalInvestmentValue = targetAllocation.TotalInvestmentValue;

                await _dbContext.SaveChangesAsync();

                return portfolio; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Portfolio> ViewPortfolioAsync(int userId)
        {
            try
            {
                var portfolio = await _dbContext.Portfolios
                    .FirstOrDefaultAsync(p => p.UserId == userId);

                return portfolio; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
