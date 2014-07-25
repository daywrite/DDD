
using DDD.Domain.Models;
using DDD.Domain.Repositories;
using DDD.Domain.Repositories.EntityFramework;
using MongoDB.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Tests.EFSqlToMongoDB
{
    [TestFixture]
    public class EFToDB
    {
        [Test]
        public void A()
        {          
            IEFRepositoryContext _repositoryContext = new EFRepositoryContext();
            IUserRepository _userRepository = new UserRepository(_repositoryContext);

            IEnumerable<User> IEUser = _userRepository.GetAll();

            string connection = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connection);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("DddDbContext");

            foreach (User u in IEUser)
            {
                database.GetCollection<User>(typeof(User).Name).Insert(u);
            }        
        }
    }
}
