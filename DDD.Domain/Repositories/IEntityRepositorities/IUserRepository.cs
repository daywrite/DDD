using DDD.Domain.Models;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>, IDependency
    {
        #region 方法

        #endregion
    }
}
