using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Enum;

namespace PMMS.Services.StockManage
{
    public class ListStockOutParmeters
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public StockOutStatus? Status { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateRange CreateDateRange { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        public DateRange ApproveDateRange { get; set; }

    }
}
