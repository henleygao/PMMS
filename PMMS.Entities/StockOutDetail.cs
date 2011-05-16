using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Entities
{

    /// <summary>
    /// 出库单明细
    /// </summary>
    public class StockOutDetail
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public virtual float Count { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual float Price { get; set; }

        /// <summary>
        /// 出库单
        /// </summary>
        public virtual StockOut StockOut { get; set; }

        /// <summary>
        /// 面料
        /// </summary>
        public virtual PlusMaterial PlusMaterial { get; set; }
    }
}
