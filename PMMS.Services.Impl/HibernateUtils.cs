using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using System.IO;
using PMMS.Entities.Mapping;

namespace PMMS.Services.Impl
{
    public static class HibernateUtils
    {
        private static readonly ISessionFactory _sessionFactory;

        static HibernateUtils()
        {
            var configuration = new Configuration();
            var mapping = new MappingFactory().CreateMapping();
            configuration.AddDeserializedMapping(mapping, null);
            _sessionFactory = configuration.Configure().BuildSessionFactory();
        }

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }

}
