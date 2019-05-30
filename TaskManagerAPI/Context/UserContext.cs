using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Interfaces;
using MongoDB.Driver;
using TaskManagerAPI.Model;
using Microsoft.Extensions.Options;

namespace TaskManagerAPI.Context
{
    public class UserContext : IUser
    {
        private readonly IMongoDatabase _db;

        public UserContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    }
}
