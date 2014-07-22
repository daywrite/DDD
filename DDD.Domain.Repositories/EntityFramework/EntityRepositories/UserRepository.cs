using DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.EntityFramework
{
    public class UserRepository : EFRepository<User, Guid>, IUserRepository
    {
        public UserRepository(IRepositoryContext context) : base(context) { }
    }
}
