using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.MongoDB
{
    // ReSharper disable once InconsistentNaming
    public interface IMongoDBRepositoryContext : IRepositoryContext
    {
        IMongoDBRepositoryContextSettings Settings { get; }

        MongoCollection GetCollectionForType<TEntity>(string collection);
    }
}
