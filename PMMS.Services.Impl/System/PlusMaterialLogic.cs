using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Services.System;
using PMMS.Entities;
using NHibernate.Linq;
using NHibernate;
using PMMS.Services.Impl.Utils;
using PMMS.Exceptions;
namespace PMMS.Services.Impl.System
{
    [UnitOfWork]
    public class PlusMaterialLogic : IPlusMaterialLogic
    {
        ISession session;

        public PlusMaterialLogic(ISession session)
        {
            this.session = session;
        }

        public void AddPlusMaterial(PlusMaterialAddView addView)
        {
            var plus = (from p in session.Query<PlusMaterial>()
                        where p.No == addView.No
                        select p).FirstOrDefault();
            if (plus != null)
                throw new RepeatException();

            PlusMaterial pm = new PlusMaterial()
            {
                Color = addView.Color,
                CreateDate = DateTime.Now,
                FabricWidth = addView.FabricWidth,
                Name = addView.Name,
                No = addView.No,
                Price = addView.Price,
                Remark = addView.Remark,
                StockCount = addView.StockCount,
                Supplier = addView.Supplier
            };
            session.Save(pm);
        }


        public IList<PlusMaterialListView> ListPlusMaterial(ListPlusMaterialParmeters parmeters)
        {
            var query = from pm in session.Query<PlusMaterial>()
                        select pm;

            if (!string.IsNullOrEmpty(parmeters.No))
                query = query.Where(item => item.No.Contains(parmeters.No));
            if (!string.IsNullOrEmpty(parmeters.Name))
                query = query.Where(item => item.Name.Contains(parmeters.Name));
            if (!string.IsNullOrEmpty(parmeters.Color))
                query = query.Where(item => item.Color.Contains(parmeters.Color));
            if (!string.IsNullOrEmpty(parmeters.Supplier))
                query = query.Where(item => item.Supplier.Contains(parmeters.Supplier));
            query = query.OrderByDescending(item => item.CreateDate);
            return query.Select(pm => new PlusMaterialListView()
                 {
                     Id = pm.Id,
                     Color = pm.Color,
                     FabricWidth = pm.FabricWidth,
                     Name = pm.Name,
                     No = pm.No,
                     Price = pm.Price,
                     Remark = pm.Remark,
                     StockCount = pm.StockCount,
                     Supplier = pm.Supplier,
                 }).ToList();
        }

        public void UpdatePlusMaterial(PlusMaterialUpdateView view)
        {
            var plus = (from p in session.Query<PlusMaterial>()
                        where p.No == view.No && p.Id != view.Id
                        select p).FirstOrDefault();
            if (plus != null)
                throw new RepeatException();

            plus = session.Get<PlusMaterial>(view.Id);
            plus.Color = view.Color;
            plus.FabricWidth = view.FabricWidth;
            plus.Name = view.Name;
            plus.No = view.No;
            plus.Price = view.Price;
            plus.Remark = view.Remark;
            plus.StockCount = view.StockCount;
            plus.Supplier = view.Supplier;
            session.Update(plus);
        }
    }



}
