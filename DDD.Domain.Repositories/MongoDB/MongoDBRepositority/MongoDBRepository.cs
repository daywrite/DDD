using DDD.Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.MongoDB
{
    public class MongoDBRepository<TEntity, TKey> : Repository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        /// <summary>
        /// 通过Autofac注入IMongoDBRepositoryContext上下文
        /// </summary>
        private readonly IMongoDBRepositoryContext _mongoDBRepositoryContext;

        /// <summary>
        /// 通过Autofac注入IMongoDBRepositoryContext上下文
        /// </summary>
        /// <param name="context"></param>
        public MongoDBRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IMongoDBRepositoryContext)
            {
                _mongoDBRepositoryContext = context as MongoDBRepositoryContext;
            }
            else
            {
                throw new InvalidOperationException("当前Context类型不一致");
            }
        }

        /// <summary>
        /// 获取IMongoDBRepositoryContext当前上下文
        /// </summary>
        internal IMongoDBRepositoryContext MongoDBRepositoryContext
        {
            get { return _mongoDBRepositoryContext; }
        }


        /// <summary>
        /// 获取TEntity类型的集合
        /// </summary>
        /// <returns>返回~MongoCollection</returns>
        private MongoCollection GetMongoCollection()
        {
            return _mongoDBRepositoryContext.GetCollectionForType<TEntity>(typeof(TEntity));
        }

        /// <summary>
        /// 获取TEntity类型的集合
        /// </summary>
        /// <returns>返回~IEnumerable</returns>
        protected override IEnumerable<TEntity> DoGetAll()
        {
            return GetMongoCollection().FindAllAs<TEntity>();
        }

        /// <summary>
        /// 查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        protected override TEntity DoGetByKey(TKey key)
        {
            try
            {
                return DoGetAll().Single(p => p.Id.Equals(key));
            }
            catch
            {
                return null;
            }
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
