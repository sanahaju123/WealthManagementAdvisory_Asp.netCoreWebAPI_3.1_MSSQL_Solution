using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WealthManagementAdvisory.BusinessLayer.Interfaces;
using WealthManagementAdvisory.BusinessLayer.Services.Repository;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<Portfolio> AddPortfolioAsync(Portfolio portfolio)
        {
           return await _portfolioRepository.AddPortfolioAsync(portfolio);
        }

        public async Task<Portfolio> RebalancePortfolioAsync(int userId, Portfolio targetAllocation)
        {
            return await _portfolioRepository.RebalancePortfolioAsync(userId,targetAllocation);
        }

        public async Task<Portfolio> ViewPortfolioAsync(int userId)
        {
            return await _portfolioRepository.ViewPortfolioAsync(userId);
        }
    }
}
