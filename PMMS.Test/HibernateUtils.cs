using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using log4net.Config;
using System.IO;
using PMMS.Entities.Mapping;

namespace PMMS.Test
{
    public static class HibernateUtils
    {
        private static readonly ISessionFactory _sessionFactory;

        static HibernateUtils()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.xml"));
            var configuration = new Configuration();
            var mapping = new MappingFactory().CreateMapping();

            configuration.AddDeserializedMapping(mapping, null);

            _sessionFactory = configuration.Configure().BuildSessionFactory();
        }

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }
    }

}
