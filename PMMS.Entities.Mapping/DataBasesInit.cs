using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using PMMS.Entities.Mapping;
using PMMS.Entities;
using NHibernate.Cfg.MappingSchema;
using NHibernate;
using PMMS.Enum;
using NHibernate.Tool.hbm2ddl;

namespace PMMS
{
    public class DataBasesInit
    {
        private ISession _session { get; set; }
        private Configuration _nhConfig { get; set; }
        private HbmMapping _mapping { get; set; }


        public DataBasesInit()
        {
            _nhConfig = new Configuration().Configure();
            _mapping = new MappingFactory().CreateMapping();
            _nhConfig.AddDeserializedMapping(_mapping, null);

            var sessionFactory = _nhConfig.BuildSessionFactory();
            _session = sessionFactory.OpenSession();
        }

        public void Init()
        {
            //导出数据库
            SchemaMetadataUpdater.QuoteTableAndColumns(_nhConfig);
            var export = new SchemaExport(_nhConfig);
            export.Drop(false, true);
            export.Create(false, true);

            DBDataInit();
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
                        Account = "001",
                        Name = "管理员",
                        Password = "8888",
                        Status = UserStatus.Enable
                    };
                    _session.Save(admin);

                    User zs = new User()
                    {
                        Account = "002",
                        Name = "张三",
                        Password = "8888",
                        Status = UserStatus.Enable
                    };
                    _session.Save(zs);

                    User ls = new User()
                    {
                        Account = "003",
                        Name = "李四",
                        Password = "8888",
                        Status = UserStatus.Enable
                    };
                    _session.Save(ls);

                    for (int i = 0; i < 100; i++)
                    {
                        var pm = new PlusMaterial()
                        {
                            No = "P00" + i,
                            Price = 10 + i,
                            Remark = "Remark" + i,
                            StockCount = i + 1,
                            Supplier = "supplier" + i,
                            FabricWidth = (i + 1) / 10,
                            CreateDate = DateTime.Now,
                            Color = "红色" + i,
                            Name = "上衣" + i
                        };
                        _session.Save(pm);
                    }



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
