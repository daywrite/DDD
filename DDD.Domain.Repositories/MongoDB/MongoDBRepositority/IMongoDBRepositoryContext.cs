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

        /// <summary>
        /// Gets the <see cref="MongoCollection"/> instance by the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> object.</param>
        /// <returns>The <see cref="MongoCollection"/> instance.</returns>
        MongoCollection GetCollectionForType<TEntity>(Type type);
    }
}
