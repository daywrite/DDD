using DDD.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.BaseRepositority
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        #region 私有字段

        /// <summary>
        /// 获取仓储上下文的实例
        /// </summary>
        private readonly IRepositoryContext _context;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个IRepositoryContext类型的实例。
        /// </summary>
        /// <param name="context">用来初始化IRepositoryContext类型的仓储上下文实例。</param>
        protected Repository(IRepositoryContext context)
        {
            _context = context;
        }

        #endregion

        #region 受保护方法

        /// <summary>
        /// 通过主键获取实体类信息
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        protected abstract TEntity DoGetByKey(TKey key);

        /// <summary>
        /// 从仓储中读取所有实体信息。
        /// </summary>
        /// <returns>所有的实体信息。</returns>
        protected abstract IEnumerable<TEntity> DoGetAll();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void DoAdd(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void DoUpdate(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void DoRemove(TEntity entity);

        #endregion

        #region 实现的方法

        public IRepositoryContext Context
        {
            get { return this._context; }
        }

        /// <summary>
        /// 通过主键获取实体类信息
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public TEntity GetByKey(TKey key)
        {
            return this.DoGetByKey(key);
        }

        /// <summary>
        /// 从仓储中读取所有实体信息。
        /// </summary>
        /// <returns>所有的实体信息。</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return this.DoGetAll();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            this.DoAdd(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            this.DoUpdate(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            this.DoRemove(entity);
        }

        #endregion
    }
}
