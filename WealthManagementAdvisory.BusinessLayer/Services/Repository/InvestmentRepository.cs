using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthManagementAdvisory.DataLayer;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services.Repository
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly WealthManagementDbContext _dbContext;
        public InvestmentRepository(WealthManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Investment> AddInvestmentAsync(Investment addInvestmentRequest)
        {
            try
            {
                var userExists = await _dbContext.Users
                    .AnyAsync(u => u.UserId == addInvestmentRequest.UserId);

                _dbContext.Investments.Add(addInvestmentRequest);
                await _dbContext.SaveChangesAsync();

                return addInvestmentRequest; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Investment>> GetInvestmentsAsync(int userId)
        {
            try
            {
                var investments = await _dbContext.Investments
                    .Where(i => i.UserId == userId)
                    .ToListAsync();

                return investments; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
