using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Enum;

namespace PMMS.Services.StockManage
{
    public class StockInAddView
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 入库类型
        /// </summary>
        public StockInType StockInType { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime StockInDateTime { get; set; }

        /// <summary>
        /// 入库单明细
        /// </summary>
        public virtual IList<StockInDetailAddView> StockInDetails { get; set; }
    }
}
