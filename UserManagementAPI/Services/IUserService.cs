using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Domain;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<List<User>> GetUsersAsync();
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<bool> CreateUserAsync(User user);
    }
}
