using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Domain;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();

            for (int i = 0; i < 5; i++)
            {
                _users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    GivenName = $"User Name {i}",
                    Surname = "sdfdf",
                    EmailAddress = "abc@xyz.com"
                });

            }
        }

        public User GetUserById(Guid userId)
        {
            return _users.SingleOrDefault(x => x.Id == userId);
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public bool UpdateUser(User user)
        {
            var userExists = GetUserById(user.Id) != null;
            if (!userExists) return false;

            var indexOfUser = _users.FindIndex(x => x.Id == user.Id);
            _users[indexOfUser] = user;
            return true;

        }

        public bool DeleteUser(Guid userId)
        {
            var user = GetUserById(userId);
            if (user == null) return false;

            _users.Remove(user);
            return true;

        }
    }
}
