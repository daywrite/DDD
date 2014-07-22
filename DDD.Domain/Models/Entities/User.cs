﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Models
{
    public class User : EntityBase<Guid>
    {
        /// <summary>
        /// 用户名。
        /// </summary>
        public string UserName { get; set; }

        ///<summary>
        /// 密码。
        /// </summary>
        public string Password { get; set; }

    }
}
