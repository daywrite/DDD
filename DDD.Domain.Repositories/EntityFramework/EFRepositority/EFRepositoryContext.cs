using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Repositories.EntityFramework;
using DDD.Infrastructure;
namespace DDD.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// 数据单元操作接口
    /// </summary>
    public class EFRepositoryContext : RepositoryContext, IEFRepositoryContext
    {
        private readonly DddDbContext _localCtx = new DddDbContext();
        public EFRepositoryContext() { }

        /// <summary>
        /// 注册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public override void RegisterNew<TEntity, TKey>(TEntity entity)
        {
            EntityState state = Context.Entry(entity).State;
            Committed = false;
        }

        /// <summary>
        /// 注册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public override void RegisterModified<TEntity, TKey>(TEntity entity)
        {
            Context.Update<TEntity, TKey>(entity);
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
            Context.Entry(entity).State = EntityState.Deleted;
            Committed = false;
        }


        #region IEFRepositoryContext Members
        public DbContext Context
        {
            get { return _localCtx; }
        }
        #endregion
        public override bool DistributedTransactionSupported
        {
            get { return true; }
        }

        public override void Rollback()
        {
            Committed = false;
        }

        protected override void DoCommit()
        {
            if (!Committed)
            {
                int result = Context.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!Committed)
                {
                    Commit();
                }

                Context.Dispose();
            }
        }
    }
}

