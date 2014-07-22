using DDD.Domain.Models;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.Imple
{
    public interface IUserService : IDependency
    {
        User GetByKey(Guid id);
    }
}
