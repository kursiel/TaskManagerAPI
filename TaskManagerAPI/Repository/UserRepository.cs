using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Context;
using TaskManagerAPI.Model;
using MongoDB.Driver;


namespace TaskManagerAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUser _context;

        public UserRepository(IUser userContext)
        {
            _context = userContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context
                .Users
                .Find(_ => true)
                .ToListAsync();
        }

        public Task<User> GetUser(string username)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.Username, username);

            return _context
                .Users
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task Create(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            ReplaceOneResult updateResult =
                await _context
                .Users
                .ReplaceOneAsync
                (
                    filter: g => g.Id == user.Id,
                    replacement: user
                );

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteUser(string username)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.Username, username);

            DeleteResult deleteResult = await _context
                .Users
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }
    }
}
