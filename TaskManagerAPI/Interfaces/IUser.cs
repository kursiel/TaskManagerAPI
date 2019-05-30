using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Interfaces
{
    public interface IUser
    {
        IMongoCollection<User> Users { get; }
    }
}
