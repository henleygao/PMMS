using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.StockManage
{
    public interface IStockOutLogic
    {
        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <param name="view"></param>
        void AddStockOut(StockOutAddView view);

        /// <summary>
        /// 出库单列表
        /// </summary>
        /// <returns></returns>
        IList<StockOutListView> ListStockOut();

        /// <summary>
        /// 根据面料ID，获取入库详细信息
        /// </summary>
        /// <param name="plusId">面料ID</param>
        /// <returns></returns>
        StockOutDetailView GetStockOutDetail(string plusNo);

        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="ids"></param>
        void Approve(int currentId, IList<int> ids);

    }
}
