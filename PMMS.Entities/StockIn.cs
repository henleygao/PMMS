using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Enum;

namespace PMMS.Entities
{
    /// <summary>
    /// 入库单
    /// </summary>
    public class StockIn
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual string No { get; set; }

        /// <summary>
        /// 入库类型
        /// </summary>
        public virtual StockInType Type { get; set; }

        /// <summary>
        /// 入库单状态
        /// </summary>
        public virtual StockInStatus Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public virtual User Creater { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public virtual DateTime? ApprovalDateTime { get; set; }

        /// <summary>
        /// 审批者
        /// </summary>
        public virtual User Approver { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 入库单明细
        /// </summary>
        public virtual IList<StockInDetail> StockInDetails { get; set; }
    }
}
