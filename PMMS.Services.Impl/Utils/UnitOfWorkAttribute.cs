using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;
using NHibernate;

namespace PMMS.Services.Impl.Utils
{
    public class UnitOfWorkAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            var session = container.Resolve<ISession>();
            return new UnitOfWorkHandler(session);
        }
    }
}
