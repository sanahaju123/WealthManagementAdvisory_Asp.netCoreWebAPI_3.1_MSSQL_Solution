using System.Collections.Generic;
using System.Threading.Tasks;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services.Repository
{
    public interface IInvestmentRepository
    {
        Task<Investment> AddInvestmentAsync(Investment addInvestmentRequest);

        Task<List<Investment>> GetInvestmentsAsync(int userId);
    }
}
