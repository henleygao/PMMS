using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using NHibernate.Cfg;
using PMMS.Entities.Mapping;
using NHibernate;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using PMMS.Services.System;
using PMMS.Services.Impl.Utils;

namespace PMMS.Forms.Utils
{
    class UnityControllerFactory
    {
        public static IUnityContainer Container
        {
            get;
            set;
        }

        public static void Configure()
        {
            Container = new UnityContainer();
            //container
            //    .RegisterType<SomeService, SomeService>().
            //    Configure<InjectedMembers>().ConfigureInjectionFor
            //    <SomeService>(new InjectionConstructor("IoC Container: Unity."));
            //  container.RegisterType<HomeController, HomeController>();

            RegisterNhConfig(Container);
            RegisterServices(Container);
            //container.Configure<Interception>()
            //    .SetInterceptorFor(new InterfaceInterceptor());

            //  DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterNhConfig(IUnityContainer container)
        {
            //注册NHibernate 配置对象
            var nhConfig = new Configuration().Configure();
            container.RegisterInstance<Configuration>(nhConfig);

            //配置NHibernate 映射
            var mappingFactory = new MappingFactory();
            var mapping = mappingFactory.CreateMapping();

            nhConfig.AddDeserializedMapping(mapping, null);

            var sessionFactory = nhConfig.BuildSessionFactory();
            container.RegisterInstance<ISessionFactory>(sessionFactory);

            //注册ISession注入工厂
            //ExternallyControlledLifetimeManager
            //PerThreadLifetimeManager
            //ContainerControlledLifetimeManager
            //HierarchicalLifetimeManager
            container.RegisterType<ISession>(
                new ExternallyControlledLifetimeManager(),
                           new InjectionFactory((c) =>
                              c.Resolve<ISessionFactory>().OpenSession()));
        }

        //注册Services
        private static void RegisterServices(IUnityContainer container)
        {
            container.AddNewExtension<Interception>();

            var repoInterfaces = Assembly.Load("PMMS.Services").GetTypes()
                                         .Where(t => t.Name.EndsWith("Logic") && t.IsInterface);

            var repoTypes = Assembly.Load("PMMS.Services.Impl").GetTypes();
            var interception = container.Configure<Interception>();

            foreach (var repoInterface in repoInterfaces)
            {
                foreach (var repoType in repoTypes.Where(t => repoInterface.IsAssignableFrom(t)))
                {
                    container.RegisterType(repoInterface, repoType);
                    interception.SetDefaultInterceptorFor(repoInterface, new InterfaceInterceptor());
                }
            }
        }
    }
}
