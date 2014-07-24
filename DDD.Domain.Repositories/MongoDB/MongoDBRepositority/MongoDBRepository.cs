using DDD.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.MongoDB
{
    // ReSharper disable once InconsistentNaming
    public class MongoDBRepository<TEntity, TKey> : Repository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IMongoDBRepositoryContext _mongoDBRepositoryContext;
        public MongoDBRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IMongoDBRepositoryContext)
                _mongoDBRepositoryContext = context as MongoDBRepositoryContext;
            else
                throw new InvalidOperationException("Invalid repository context type.");
        }

        internal IMongoDBRepositoryContext MongoDBRepositoryContext
        {
            get { return _mongoDBRepositoryContext; }
        }

        /// <summary>
        /// 查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        protected override TEntity DoGetByKey(TKey key)
        {
            MongoCollection collection = _mongoDBRepositoryContext.GetCollectionForType<TEntity>("User");
            //return collection.AsQueryable<TAggregateRoot>().Where(p => p.ID == id).First();
            long count = collection.Count();
            return null;
        }

        protected override IEnumerable<TEntity> DoGetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        protected override void DoAdd(TEntity entity)
        {
            _mongoDBRepositoryContext.RegisterNew<TEntity, TKey>(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        protected override void DoUpdate(TEntity entity)
        {
            _mongoDBRepositoryContext.RegisterModified<TEntity, TKey>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        protected override void DoRemove(TEntity entity)
        {
            _mongoDBRepositoryContext.RegisterDeleted<TEntity, TKey>(entity);
        }
    }
}
