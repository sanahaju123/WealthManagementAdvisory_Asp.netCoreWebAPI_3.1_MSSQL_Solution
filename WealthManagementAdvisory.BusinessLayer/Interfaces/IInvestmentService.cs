using System.Collections.Generic;
using System.Threading.Tasks;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Interfaces
{
    public interface IInvestmentService
    {
        Task<Investment> AddInvestmentAsync(Investment addInvestmentRequest);

        Task<List<Investment>> GetInvestmentsAsync(int userId);
    }
}
