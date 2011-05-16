using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.System
{
    public class PlusMaterialAddView
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }

        /// <summary>
        /// 面料名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 布封
        /// </summary>
        public float FabricWidth { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public float StockCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
