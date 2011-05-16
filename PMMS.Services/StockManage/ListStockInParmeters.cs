using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Enum;

namespace PMMS.Services.StockManage
{
    public class ListStockInParmeters
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 入库类型
        /// </summary>
        public StockInType Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public StockInStatus Status { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? FromCreateDateTime { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? ToCreateDateTime { get; set; }

        /// <summary>
        /// 审批者
        /// </summary>
        public string Approver { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        public DateTime? FromApproveDateTime { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        public DateTime? ToApproveDateTime { get; set; }

    }
}
