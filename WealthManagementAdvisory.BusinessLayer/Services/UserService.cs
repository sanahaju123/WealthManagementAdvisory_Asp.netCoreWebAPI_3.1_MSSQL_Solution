using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WealthManagementAdvisory.BusinessLayer.Interfaces;
using WealthManagementAdvisory.BusinessLayer.Services.Repository;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserProfileAsync(User userProfile)
        {
            return await _userRepository.CreateUserProfileAsync(userProfile);
        }

        public async Task<User> DeleteUserProfileAsync(int userId)
        {
            return await _userRepository.DeleteUserProfileAsync(userId);
        }

        public async Task<List<User>> GetAllUserProfileAsync()
        {
            return await _userRepository.GetAllUserProfileAsync();
        }

        public async Task<User> GetUserProfileAsync(int userId)
        {
            return await _userRepository.GetUserProfileAsync(userId);
        }

        public async Task<User> UpdateUserProfileAsync(int userId, User updatedDetails)
        {
            return await _userRepository.UpdateUserProfileAsync(userId, updatedDetails);
        }
    }
}
