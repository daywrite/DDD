using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
//此外，你将频繁的用到下面这些 using 语句中的一条或多条:
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
namespace MongoDB.Tests
{
    class Program
    {
        public class Entity
        {
            public ObjectId Id { get; set; }
            public string Name { get; set; }
            public string password { get; set; }
        }
        static void Main(string[] args)
        {
            var connection = "mongodb://localhost:27017";
            var client = new MongoClient(connection);
            var server = client.GetServer();
            var database = server.GetDatabase("DddDbContext");

            var collection = database.GetCollection<Entity>("User");
            long count = collection.Count();
        }
    }
}
