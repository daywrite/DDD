using DDD.Domain.Models;
using DDD.Domain.Repositories;
using DDD.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// EntityFramework仓储操作基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// <typeparam name="TKey">实体主键类型</typeparam>
    public class EFRepository<TEntity, TKey> : Repository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        #region 属性
        /// <summary>
        /// EntityFramework的数据仓储上下文
        /// </summary>
        private readonly IEFRepositoryContext _efContext;
        #endregion

        #region 构造函数
        /// <summary>
        /// 获取 EntityFramework的数据仓储上下文
        /// </summary>
        public EFRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IEFRepositoryContext)
            {
                this._efContext = context as IEFRepositoryContext;
            }
        }
        #endregion

        /// <summary>
        /// EntityFramework的数据仓储上下文
        /// </summary>
        protected IEFRepositoryContext EFContext
        {
            get { return this._efContext; }
        }

        /// <summary>
        /// 查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        protected override TEntity DoGetByKey(TKey key)
        {
            return _efContext.Context.Set<TEntity>().Find(key);
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
            _efContext.RegisterNew<TEntity, TKey>(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        protected override void DoUpdate(TEntity entity)
        {
            _efContext.RegisterModified<TEntity, TKey>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        protected override void DoRemove(TEntity entity)
        {
            _efContext.RegisterDeleted<TEntity, TKey>(entity);
        }
 
    }
}
