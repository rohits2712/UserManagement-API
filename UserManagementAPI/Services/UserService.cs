using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Data;
using UserManagementAPI.Domain;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dataContext;

        public UserService(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _dataContext.Users.SingleOrDefaultAsync(x => x.Id.Equals(userId));
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            await _dataContext.Users.AddAsync(user);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            //var userExists = GetUserById(user.Id) != null;
            //if (!userExists) return false;

            _dataContext.Users.Update(user);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;

        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null) return false;

            _dataContext.Users.Remove(user);
            var deleted = await _dataContext.SaveChangesAsync();
            return true;

        }
    }
}
