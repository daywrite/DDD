using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.MongoDB
{
    public class MongoDBRepositoryContext : RepositoryContext, IMongoDBRepositoryContext
    {
        private readonly MongoServer _server;
        private readonly MongoDatabase _database;
        private readonly IMongoDBRepositoryContextSettings _settings;

        public MongoDBRepositoryContext(IMongoDBRepositoryContextSettings settings)
        {
            this._settings = settings;
            _server = new MongoServer(settings.ServerSettings);
            _database = _server.GetDatabase(settings.DatabaseName, settings.GetDatabaseSettings(_server));
        }

        #region IMongoDBRepositoryContext Members
        public IMongoDBRepositoryContextSettings Settings
        {
            get { return _settings; }
        }

        /// <summary>
        /// 获取当前集合类型的MongoCollection
        /// </summary>
        /// <typeparam name="TEntity">当前实体类型</typeparam>
        /// <param name="type">类型的Type</param>
        /// <returns>返回~MongoCollection</returns>
        public MongoCollection GetCollectionForType<TEntity>(Type type)
        {
            return this._database.GetCollection<TEntity>(type.Name);
        }

        protected override void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// 注册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public override void RegisterNew<TEntity, TKey>(TEntity entity)
        {
            GetCollectionForType<TEntity>(typeof(TEntity)).Insert(entity);
        }

        /// <summary>
        /// 注册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public override void RegisterModified<TEntity, TKey>(TEntity entity)
        {
            Committed = false;
        }

        /// <summary>
        /// 注册一个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public override void RegisterDeleted<TEntity, TKey>(TEntity entity)
        {
            Committed = false;
        }
        #endregion

        #region IUnitOfWork Members

        public override void Commit()
        {
            this.DoCommit();
        }
        public override void Rollback()
        {
            this.Committed = false;
        }
        protected override void DoCommit()
        {

        }
        public override bool DistributedTransactionSupported
        {
            get { return false; }
        }

        #endregion
    }
}
