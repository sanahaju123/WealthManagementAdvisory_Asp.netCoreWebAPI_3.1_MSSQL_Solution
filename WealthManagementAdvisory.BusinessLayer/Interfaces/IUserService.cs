using System.Collections.Generic;
using System.Threading.Tasks;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserProfileAsync(User userProfile);

        Task<User> GetUserProfileAsync(int userId);
        Task<List<User>> GetAllUserProfileAsync();

        Task<User> UpdateUserProfileAsync(int userId, User updatedDetails);

        Task<User> DeleteUserProfileAsync(int userId);
    }
}

