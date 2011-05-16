using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Entities
{
    /// <summary>
    /// 面料
    /// </summary>
    public class PlusMaterial
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual string No { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime CreateDate { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual string Supplier { get; set; }

        /// <summary>
        /// 面料名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public virtual string Color { get; set; }

        /// <summary>
        /// 布封
        /// </summary>
        public virtual float FabricWidth { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual float Price { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public virtual float StockCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

    }
}
