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
using PMMS.Exceptions;

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
            var exists = (from s in session.Query<StockOut>()
                          where s.No == view.No
                          select s).FirstOrDefault();

            if (exists != null)
                throw new RepeatException();

            var ids = view.StockOutDetails.Select(item => new
            {
                item.PlusMaterialId,
                item.Count
            });

            var stocks = new Dictionary<string, float>();
            foreach (var item in ids)
            {
                var plus = session.Get<PlusMaterial>(item.PlusMaterialId);
                if (plus.StockCount < item.Count)
                    stocks.Add(plus.No, plus.StockCount);
            }
            if (stocks.Count > 0)
            {
                throw new StockOutCountMoreThanStockCountException()
                {
                    Stocks = stocks
                };
            }

            var stockOut = new StockOut()
            {
                StockOutDateTime = view.StockOutDateTime,
                Creater = LogicUtils.NotNull(session.Get<User>(view.CreateUserId)),
                No = view.No,
                Remark = view.Remark,
                CreateDateTime = DateTime.Now,
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


        public IList<StockOutListView> ListStockOut(ListStockOutParmeters parmeters)
        {
            var query = from s in session.Query<StockOut>()
                        select s;

            if (!string.IsNullOrEmpty(parmeters.No))
            {
                query = query.Where(item => item.No.Contains(parmeters.No));
            }
            if (!string.IsNullOrEmpty(parmeters.Remark))
            {
                query = query.Where(item => item.Remark.Contains(parmeters.Remark));
            }
            if (parmeters.Status.HasValue)
            {
                query = query.Where(item => item.Status == parmeters.Status.Value);
            }

            if (parmeters.CreateDateRange.DateFrom.HasValue)
            {
                query = query.Where(item => item.StockOutDateTime >= parmeters.CreateDateRange.DateFrom.Value);
            }
            if (parmeters.CreateDateRange.DateTo.HasValue)
            {
                query = query.Where(item => item.StockOutDateTime < parmeters.CreateDateRange.DateTo.Value);
            }
            if (parmeters.ApproveDateRange.DateFrom.HasValue)
            {
                query = query.Where(item => item.ApprovalDateTime >= parmeters.ApproveDateRange.DateFrom.Value);

            }
            if (parmeters.ApproveDateRange.DateTo.HasValue)
            {
                query = query.Where(item => item.ApprovalDateTime < parmeters.ApproveDateRange.DateTo.Value);
            }

            return query.OrderByDescending(item => item.CreateDateTime).Select(s => new StockOutListView()
            {
                Id = s.Id,
                No = s.No,
                Remark = s.Remark,
                Status = s.Status == StockOutStatus.Normal ? "草稿" : "已检货",
                //  Amount = s.StockInDetails.Sum(item => item.Price * item.Count),
                Approver = s.Approver == null ? "" : s.Approver.Name,
                StockOutDateTime = s.StockOutDateTime,
                Creater = s.Creater.Name,
                ApproveDateTime = s.ApprovalDateTime
            }).ToArray();
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
                    stockOut.ApprovalDateTime = DateTime.Now;
                    session.Update(stockOut);
                }
            }
        }

        public StockOutDetailView GetStockOutDetail(int plusId)
        {
            var plus = LogicUtils.NotNull(session.Get<PlusMaterial>(plusId));
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

    }
}
