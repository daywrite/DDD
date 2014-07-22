using DDD.Domain.Models;
using DDD.Domain.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// EntityFramework-CodeFirst数据上下文
    /// </summary>
    public sealed class DddDbContext : DbContext
    {
        #region 构造函数

        public DddDbContext() : base("Ddd") { }

        #endregion

        #region 公共属性

        public DbSet<User> Users { get; set; }
       
        #endregion

        #region 受保护的方法

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
