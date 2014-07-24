using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using DDD.Domain.Repositories.MongoDB;
namespace DDD.Domain.Repositories.Tests.MongoDB
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void Test()
        {
            IMongoDBRepositoryContextSettings sss = new MongoDBRepositoryContextSettings();
            IMongoDBRepositoryContext repositoryContext = new MongoDBRepositoryContext(sss);
            IUserRepository _userRepository = new UserRepository(repositoryContext);
            _userRepository.GetByKey(new Guid("be8c6f0a-5b11-e411-b59f-446d57c14a18"));
        }
    }
}
