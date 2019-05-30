using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskManagerAPI.Model
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Username")]
        public string Username { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("Name")]
        public string  Name { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("Cedula")]
        public string Cedula { get; set; }
        [BsonElement("Team")]
        public string Team { get; set; }
        [BsonElement("EmployeeID")]
        public string EmployeeId { get; set; }
        [BsonElement("BornDate")]
        public string BornDate { get; set; }
    }
}
