using DDD.Domain.Models;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories
{
    /// <summary>
    /// 单元操作实现基类
    /// </summary>
    public abstract class RepositoryContext : DisposableObject, IRepositoryContext
    {
        #region 受保护的方法

        protected abstract void DoCommit();

        #endregion

        #region IRepositoryContext

        /// <summary>
        /// 注册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public virtual void RegisterNew<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>
        {
            Committed = false;
        }

        /// <summary>
        /// 注册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public virtual void RegisterModified<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>
        {
            Committed = false;
        }

        /// <summary>
        /// 注册一个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public virtual void RegisterDeleted<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>
        {
            Committed = false;
        }

        #endregion

        #region IUnitOfWork Members

        /// <summary>
        /// 获得一个Boolean值，该值表示当前的Unit Of Work是否支持Microsoft分布式事务处理机制。
        /// </summary>
        public abstract bool DistributedTransactionSupported { get; }

        /// <summary>
        /// 获取当前上下文对象的提交状态
        /// </summary>
        public bool Committed { get; protected set; }

        /// <summary>
        /// 提交上下文
        /// </summary>
        public virtual void Commit()
        {
            this.DoCommit();
        }
        /// <summary>
        /// 回滚
        /// </summary>
        public abstract void Rollback();

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {               
            }
        }

        #endregion
    }
}
