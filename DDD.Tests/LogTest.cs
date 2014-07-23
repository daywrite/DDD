using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Reflection;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DDD.Tests
{
    [TestFixture]
    public class LogTest
    {
        [Test]
        public void Test()
        {
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error("error", new Exception("发生了一个异常"));
            log.Fatal("fatal", new Exception("发生了一个致命错误"));
            log.Info("info");
            log.Debug("debug");
            log.Warn("warn");
            //Console.WriteLine("日志记录完毕。");
        }
    }
}
