using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Domain;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(Guid userId);
        bool UpdateUser(User user);
        bool DeleteUser(Guid userId);
    }
}
