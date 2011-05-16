using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.StockManage
{
    public interface IStockInLogic
    {
        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="view"></param>
        void AddStockIn(StockInAddView view);

        /// <summary>
        /// 入库单列表
        /// </summary>
        /// <returns></returns>
        IList<StockInListView> ListStockIn(ListStockInParmeters parmeters);

        /// <summary>
        /// 根据面料ID，获取入库详细信息
        /// </summary>
        /// <param name="plusId">面料ID</param>
        /// <returns></returns>
        StockInDetailView GetStockInDetail(string plusNo);

        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="ids"></param>
        void Approve(int currentId, IList<int> ids);

    }
}
