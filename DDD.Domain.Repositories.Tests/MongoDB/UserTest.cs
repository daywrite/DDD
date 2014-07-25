using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using DDD.Domain.Repositories.MongoDB;
using DDD.Domain.Models;
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
            _userRepository.GetAll();
            _userRepository.GetByKey(new Guid("8d95bae4-7176-415c-8f72-de61815fc231"));
        }
        [Test]
        public void Add()
        {
            IMongoDBRepositoryContextSettings sss = new MongoDBRepositoryContextSettings();
            IMongoDBRepositoryContext repositoryContext = new MongoDBRepositoryContext(sss);
            IUserRepository _userRepository = new UserRepository(repositoryContext);

            User u = new User { Id = new Guid(), UserName = "demo", Password = "123456" };

            _userRepository.Add(u);
        }
    }
}
