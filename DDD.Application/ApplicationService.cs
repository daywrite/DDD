using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application
{
    public abstract class ApplicationService
    {
        #region Private Fields
        private readonly IRepositoryContext _context;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>ApplicationService</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>ApplicationService</c>类型的仓储上下文实例。</param>
        protected ApplicationService(IRepositoryContext context)
        {
            this._context = context;
        }
        #endregion

        #region Protected Properties
        /// <summary>
        /// 获取当前应用层服务所使用的仓储上下文实例。
        /// </summary>
        protected IRepositoryContext Context
        {
            get { return this._context; }
        }
        #endregion
    }
}
