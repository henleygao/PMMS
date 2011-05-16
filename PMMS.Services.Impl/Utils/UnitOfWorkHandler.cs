using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using NHibernate;

namespace PMMS.Services.Impl.Utils
{
    public class UnitOfWorkHandler : ICallHandler
    {
        ISession session;
        public UnitOfWorkHandler(ISession session)
        {
            this.session = session;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var obj = input.Target;
            var unitOfWork = new UnitOfWork(session);
            try
            {
                unitOfWork.Start();
                var retvalue = getNext()(input, getNext);//在这里执行方法
                unitOfWork.SaveAll();
                return retvalue;
            }
            catch (Exception ex)
            {
                unitOfWork.CancelAll();
                throw ex;
            }
        }
        public int Order
        {
            get;
            set;
        }

    }
}
