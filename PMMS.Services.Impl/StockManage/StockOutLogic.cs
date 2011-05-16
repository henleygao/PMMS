using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Services.StockManage;
using NHibernate;
using NHibernate.Linq;
using PMMS.Services.Impl.Utils;
using PMMS.Entities;
using PMMS.Enum;

namespace PMMS.Services.Impl.StockManage
{
    [UnitOfWork]
    public class StockOutLogic : IStockOutLogic
    {
        ISession session;

        public StockOutLogic(ISession session)
        {
            this.session = session;
        }

        public void AddStockOut(StockOutAddView view)
        {
            var stockOut = new StockOut()
            {
                CreateDateTime = DateTime.Now,
                Creater = LogicUtils.NotNull(session.Get<User>(view.CreateUserId)),
                No = view.No,
                Remark = view.Remark,
            };
            session.Save(stockOut);
            foreach (var item in view.StockOutDetails)
            {
                var detail = new StockOutDetail()
                {
                    Count = item.Count,
                    PlusMaterial = LogicUtils.NotNull(session.Get<PlusMaterial>(item.PlusMaterialId)),
                    Price = item.Price,
                    StockOut = stockOut
                };
                session.Save(detail);
            }
        }


        public StockOutDetailView GetStockOutDetail(string plusNo)
        {
            var plus = LogicUtils.NotNull((from p in session.Query<PlusMaterial>()
                                           where p.No == plusNo
                                           select p).FirstOrDefault());

            return new StockOutDetailView()
            {
                Count = plus.StockCount,
                PlusMaterialId = plus.Id,
                PlusMaterialName = plus.Name,
                PlusMaterialNo = plus.No,
                PlusMateriaRemark = plus.Remark,
                Price = plus.Price
            };
        }


        public IList<StockOutListView> ListStockOut()
        {
            var query = from s in session.Query<StockOut>()
                        select new StockOutListView()
                        {
                            Id = s.Id,
                            No = s.No,
                            Remark = s.Remark,
                            Status = s.Status == StockOutStatus.Normal ? "草稿" : "已检货",
                            //  Amount = s.StockInDetails.Sum(item => item.Price * item.Count),
                            Approver = s.Approver == null ? "" : s.Approver.Name,
                            CreateDateTime = s.CreateDateTime,
                            Creater = s.Creater.Name,
                            ApproveDateTime = s.ApprovalDateTime
                        };
            return query.ToList();
        }


        public void Approve(int currentId, IList<int> ids)
        {
            foreach (var id in ids)
            {
                var stockOut = session.Get<StockOut>(id);
                if (stockOut.Status == StockOutStatus.Normal)
                {
                    var details = from d in session.Query<StockOutDetail>()
                                  where d.StockOut.Id == id
                                  select d;
                    foreach (var item in details)
                    {
                        var plus = session.Get<PlusMaterial>(item.PlusMaterial.Id);
                        plus.StockCount -= item.Count;
                        session.Update(plus);
                    }
                    stockOut.Status = StockOutStatus.Approve;
                    var currentUser = session.Get<User>(currentId);
                    stockOut.Approver = currentUser;
                    session.Update(stockOut);
                }
            }
        }
    }
}
