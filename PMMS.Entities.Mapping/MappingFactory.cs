using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ConfOrm;
using ConfOrm.NH;
using NHibernate.Cfg.MappingSchema;
using ConfOrm.Shop.CoolNaming;
using ConfOrm.Mappers;
using ConfOrm.Patterns;
using NHibernate.Type;

namespace PMMS.Entities.Mapping
{
    public class MappingFactory
    {
        public HbmMapping CreateMapping()
        {
            var orm = new ObjectRelationalMapper();

            //主键生成策略(自增)
            orm.Patterns.PoidStrategies.Add(new NativePoidPattern());

            var entities = new[] 
            { 
                typeof(User),
                typeof(PlusMaterial),
                typeof(StockIn),
                typeof(StockInDetail),
                typeof(StockOut),
                typeof(StockOutDetail),
            };
            orm.TablePerClass(entities);

            //关系映射
            orm.ManyToOne<StockInDetail, StockIn>();
            orm.ManyToOne<StockOutDetail, StockOut>();

            //数据库命名规则
            var mapper = new Mapper(orm, new CoolPatternsAppliersHolder(orm));
            orm.TablePerClass(entities);
            var hc = mapper.CompileMappingFor(Assembly.Load("PMMS.Entities").GetTypes());
            return hc;
        }

        private void PropertyMapper(ref Mapper mapper)
        {
            //mapper.Class<User>(cm =>
            //{
            //    cm.Property(q => q.ReportDutyDate, pm => pm.NotNullable(true));
            //    cm.Property(q => q.IDCard, pm => pm.Length(50));
            //});
        }
    }
}
