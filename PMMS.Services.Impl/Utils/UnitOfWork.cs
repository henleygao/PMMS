using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace PMMS.Services.Impl.Utils
{
    public class UnitOfWork
    {
        private ISession session;

        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// 开始这个Unit
        /// </summary>
        public void Start()
        {
            session.Transaction.Begin();
        }

        /// <summary>
        /// 保存Unit中所有状态
        /// </summary>
        public void SaveAll()
        {
            var tran = session.Transaction;
            if (tran != null && tran.IsActive)
            {
                tran.Commit();
            }
        }

        /// <summary>
        /// 取消Unit中所有的状态
        /// </summary>
        public void CancelAll()
        {
            var tran = session.Transaction;
            if (tran != null && tran.IsActive)
            {
                tran.Rollback();
            }
        }
    }
}
