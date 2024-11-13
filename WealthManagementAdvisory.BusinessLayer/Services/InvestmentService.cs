using System.Collections.Generic;
using System.Threading.Tasks;
using WealthManagementAdvisory.BusinessLayer.Interfaces;
using WealthManagementAdvisory.BusinessLayer.Services.Repository;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;

        public InvestmentService(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<Investment> AddInvestmentAsync(Investment addInvestmentRequest)
        {
            return await _investmentRepository.AddInvestmentAsync(addInvestmentRequest);
        }

        public async Task<List<Investment>> GetInvestmentsAsync(int userId)
        {
            return await _investmentRepository.GetInvestmentsAsync(userId);
        }
    }
}
