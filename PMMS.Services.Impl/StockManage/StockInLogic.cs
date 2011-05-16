using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Services.StockManage;
using PMMS.Entities;
using PMMS.Services.Impl.Utils;
using NHibernate;
using NHibernate.Linq;
using PMMS.Enum;
using PMMS.Exceptions;


namespace PMMS.Services.Impl.StockManage
{
    [UnitOfWork]
    public class StockInLogic : IStockInLogic
    {
        ISession session;

        public StockInLogic(ISession session)
        {
            this.session = session;
        }

        public void AddStockIn(StockInAddView view)
        {
            var plus = (from s in session.Query<StockIn>()
                        where s.No == view.No
                        select s).FirstOrDefault();

            if (plus != null)
                throw new RepeatException();

            var stockIn = new StockIn()
            {
                CreateDateTime = DateTime.Now,
                Creater = LogicUtils.NotNull(session.Get<User>(view.CreateUserId)),
                No = view.No,
                Remark = view.Remark,
                Type = view.StockInType,

            };
            session.Save(stockIn);
            foreach (var item in view.StockInDetails)
            {
                var detail = new StockInDetail()
                {
                    Count = item.Count,
                    PlusMaterial = LogicUtils.NotNull(session.Get<PlusMaterial>(item.PlusMaterialId)),
                    Price = item.Price,
                    StockIn = stockIn
                };
                session.Save(detail);
            }
        }

        public IList<StockInListView> ListStockIn(ListStockInParmeters parmeters)
        {
            var query = from s in session.Query<StockIn>()
                        select new StockInListView()
                        {
                            Id = s.Id,
                            No = s.No,
                            Remark = s.Remark,
                            Type = s.Type == StockInType.Purchase ? "采购入库" : "退货入库",
                            Status = s.Status == StockInStatus.Normal ? "草稿" : "已检货",
                            //  Amount = s.StockInDetails.Sum(item => item.Price * item.Count),
                            Approver = s.Approver == null ? "" : s.Approver.Name,
                            CreateDateTime = s.CreateDateTime,
                            Creater = s.Creater.Name,
                            ApproveDateTime = s.ApprovalDateTime
                        };
            return query.ToList();
        }

        public StockInDetailView GetStockInDetail(string plusNo)
        {
            var plus = LogicUtils.NotNull((from p in session.Query<PlusMaterial>()
                                           where p.No == plusNo
                                           select p).FirstOrDefault());
            return new StockInDetailView()
            {
                PlusMaterialId = plus.Id,
                PlusMaterialName = plus.Name,
                PlusMaterialNo = plus.No,
                PlusMaterialRemark = plus.Remark,
                Price = plus.Price
            };
        }

        public void Approve(int currentId, IList<int> ids)
        {
            foreach (var id in ids)
            {
                var stockIn = session.Get<StockIn>(id);
                if (stockIn.Status == StockInStatus.Normal)
                {
                    var details = from d in session.Query<StockInDetail>()
                                  where d.StockIn.Id == id
                                  select d;
                    foreach (var item in details)
                    {
                        var plus = session.Get<PlusMaterial>(item.PlusMaterial.Id);
                        plus.StockCount += item.Count;
                        session.Update(plus);
                    }
                    stockIn.Status = StockInStatus.Approve;
                    var currentUser = session.Get<User>(currentId);
                    stockIn.Approver = currentUser;
                    session.Update(stockIn);
                }
            }
        }
    }
}
