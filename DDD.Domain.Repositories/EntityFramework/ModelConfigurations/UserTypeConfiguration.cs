using DDD.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        #region 构造函数
        public UserTypeConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.UserName).IsRequired().HasMaxLength(20);
            Property(c => c.Password).IsRequired().HasMaxLength(20);

            ToTable("Users");

        }
        #endregion
    }
}
