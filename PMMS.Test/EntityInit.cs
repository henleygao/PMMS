using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Cfg.MappingSchema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using NHibernate;
using log4net.Config;
using NHibernate.ByteCode.Castle;
using NHibernate.Dialect;
using NHibernate.Cfg.Loquacious;
using PMMS.Entities.Mapping;
using PMMS.Entities;
using PMMS.Enum;

namespace PMMS.Test
{
    /// <summary>
    /// UnitTest1 的摘要说明
    /// </summary>
    [TestClass]
    public class EntityInit
    {
        private ISession _session { get; set; }

        private Configuration _nhConfig { get; set; }

        private HbmMapping _mapping { get; set; }

        public EntityInit()
        {
            try
            {
                //_nhConfig.SessionFactory()
                //        .Named("Demo")
                //        .Proxy.Through<ProxyFactoryFactory>()
                //        .Integrate
                //            .Using<MySQL5Dialect>()
                //            .Connected
                //               .Using("ConnectionString");
                //XmlConfigurator.Configure(new FileInfo("log4net.xml"));
                //  HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();

                _nhConfig = new Configuration().Configure();
                _mapping = new MappingFactory().CreateMapping();
                _nhConfig.AddDeserializedMapping(_mapping, null);

                var sessionFactory = _nhConfig.BuildSessionFactory();
                _session = sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                throw ex;
            }

        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试属性
        //
        // 编写测试时，还可使用以下附加属性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }

        #endregion

        /// <summary>
        /// 初始化数据库测试
        /// </summary>
        [TestMethod]
        public void DBInit()
        {
            //导出数据库
            SchemaMetadataUpdater.QuoteTableAndColumns(_nhConfig);
            var export = new SchemaExport(_nhConfig);
            export.Drop(false, true);
            export.Create(false, true);

            //var export = new SchemaUpdate(_nhConfig);
            //export.Execute(true, true);

            DBDataInit();
        }

        /// <summary>
        /// 初始化数据测试
        /// </summary>
        [TestMethod]
        public void DataInit()
        {
            DBDataInit();
        }

        /// <summary>
        /// 输出Xml
        /// </summary>
        [TestMethod]
        public void ExportXml()
        {
            var xmlStr = Serialize(_mapping);

            string path = "c:\\abc.xml";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var fs = new FileStream(path, FileMode.CreateNew))
            {
                var streamWriter = new StreamWriter(fs);
                streamWriter.WriteLine(xmlStr);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private static string Serialize(HbmMapping hbmElement)
        {
            var setting = new XmlWriterSettings { Indent = true };
            var serializer = new XmlSerializer(typeof(HbmMapping));
            using (var memStream = new MemoryStream(2048))
            using (var xmlWriter = XmlWriter.Create(memStream, setting))
            {
                serializer.Serialize(xmlWriter, hbmElement);
                memStream.Flush();
                memStream.Position = 0;
                var sr = new StreamReader(memStream);
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void DBDataInit()
        {
            using (_session)
            {
                _session.Transaction.Begin();
                try
                {

                    User admin = new User()
                    {
                        Account = "admin",
                        Name = "管理员",
                        Password = "8888",
                        Status = UserStatus.Enable
                    };
                    _session.Save(admin);

                    //User zs = new User()
                    //{
                    //    Account = "002",
                    //    Name = "张三",
                    //    Password = "8888",
                    //    Status = UserStatus.Enable
                    //};
                    //_session.Save(zs);

                    //User ls = new User()
                    //{
                    //    Account = "003",
                    //    Name = "李四",
                    //    Password = "8888",
                    //    Status = UserStatus.Enable
                    //};
                    //_session.Save(ls);

                    //for (int i = 0; i < 100; i++)
                    //{
                    //    var pm = new PlusMaterial()
                    //    {
                    //        No = "P00" + i,
                    //        Price = 10 + i,
                    //        Remark = "Remark" + i,
                    //        StockCount = i + 1,
                    //        Supplier = "supplier" + i,
                    //        FabricWidth = (i + 1) / 10,
                    //        CreateDate = DateTime.Now,
                    //        Color = "红色" + i,
                    //        Name = "上衣" + i
                    //    };
                    //    _session.Save(pm);
                    // }



                }
                catch (Exception ex)
                {
                    _session.Transaction.Rollback();
                }

                _session.Transaction.Commit();
            }
        }
    }
}
