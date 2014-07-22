using DDD.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.EntityFramework.Migrations
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
                p => p.Id,
                new User { UserName = "demo", Password = "123456" },
                new User { UserName = "admin", Password = "654321" }
                );
        }
    }
}
