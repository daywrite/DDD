using DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories
{
    /// <summary>
    /// 表示实现该接口的类型是应用于某种实体的仓储类型。
    /// </summary>
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        #region 属性

        /// <summary>
        /// 获取当前仓储所使用的仓储上下文实例。
        /// </summary>
        IRepositoryContext Context { get; }

        #endregion

        #region 方法

        /// <summary>
        /// 根据主键，从仓储中读取实体信息。
        /// </summary>
        /// <param name="key">主键标识。</param>
        /// <returns>实体信息。</returns>
        TEntity GetByKey(TKey key);

        /// <summary>
        /// 从仓储中读取所有实体信息。
        /// </summary>
        /// <returns>所有的实体信息。</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        #endregion
    }
}
