using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.StockManage
{
    public class StockOutAddView
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 入库单明细
        /// </summary>
        public virtual IList<StockOutDetailAddView> StockOutDetails { get; set; }

    }
}
