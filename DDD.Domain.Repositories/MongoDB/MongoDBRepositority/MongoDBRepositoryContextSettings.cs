using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories.MongoDB
{
    /// <summary>
    /// 表示基于MongoDB实现的仓储上下文的配置信息。
    /// </summary>
    /// <remarks>
    /// 如果您的MongoDB配置不是默认的，您可以在此处修改MongoDB的配置信息，比如
    /// 可以在ServerSettings里指定MongoDB的端口号等。
    /// </remarks>
    // ReSharper disable once InconsistentNaming
    public class MongoDBRepositoryContextSettings : IMongoDBRepositoryContextSettings
    {
        #region IMongoDBRepositoryContextSettings Members
        /// <summary>
        /// 获取数据库名称。
        /// </summary>
        public string DatabaseName
        {
            get { return "DddDbContext"; }
        }
        /// <summary>
        /// 获取MongoDB的服务器配置信息。
        /// </summary>
        public MongoServerSettings ServerSettings
        {
            get
            {
                var settings = new MongoServerSettings();
                settings.Server = new MongoServerAddress("localhost");
                settings.WriteConcern = WriteConcern.Acknowledged;
                return settings;
            }
        }
        /// <summary>
        /// 获取数据库配置信息。
        /// </summary>
        /// <param name="server">需要配置的数据库实例。</param>
        /// <returns>数据库配置信息。</returns>
        public MongoDatabaseSettings GetDatabaseSettings(MongoServer server)
        {
            // 您无需做过多的更改：此处仅返回新建的MongoDatabaseSettings实例即可。
            return new MongoDatabaseSettings();
        }
        #endregion
    }
}
