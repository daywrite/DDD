using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure
{
    /// <summary>
    /// 用于实现<see cref="IDisposable"/>接口，表示当前类型是可释放的
    /// </summary>
    public abstract class DisposableObject : IDisposable
    {
        ~DisposableObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// 释放对象，用于外部调用
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 实现释放对象的逻辑
        /// </summary>
        /// <param name="disposing">是否要释放对象</param>
        protected abstract void Dispose(bool disposing);
    }
}
