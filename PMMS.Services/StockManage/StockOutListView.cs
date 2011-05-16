using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.StockManage
{
    public class StockOutListView
    {
        public int Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creater { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 审批者
        /// </summary>
        public string Approver { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? ApproveDateTime { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
