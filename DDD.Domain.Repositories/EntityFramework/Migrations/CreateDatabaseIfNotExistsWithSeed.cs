using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.EntityFramework.Migrations
{
    /// <summary>
    /// 在数据库不存在时使用种子数据创建数据库
    /// </summary>
    public class CreateDatabaseIfNotExistsWithSeed : CreateDatabaseIfNotExists<DddDbContext>
    {
        static CreateDatabaseIfNotExistsWithSeed()
        {

        }

        protected override void Seed(DddDbContext context)
        {

        }
    }
}
