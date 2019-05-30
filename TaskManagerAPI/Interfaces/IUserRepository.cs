using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(string username);
        Task Create(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(string username);
    }
}
