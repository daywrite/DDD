using DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.EntityFramework
{
    public class Configuration : DbMigrationsConfiguration<DddDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DddDbContext context)
        {
            context.Users.AddOrUpdate(
                p => p.UserName,
                new User { Id = new Guid(), UserName = "demo", Password = "123456" }
                );
        }
    }
}
