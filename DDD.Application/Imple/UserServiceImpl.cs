using DDD.Domain.Models;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.Imple
{
    public class UserServiceImpl : ApplicationService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServiceImpl(IRepositoryContext context, IUserRepository userRepository)
            : base(context)
        {
            this._userRepository = userRepository;
        }

        public User GetByKey(Guid id)
        {
            return _userRepository.GetByKey(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
