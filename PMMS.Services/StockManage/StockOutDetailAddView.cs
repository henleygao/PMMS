using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.StockManage
{
    public class StockOutDetailAddView
    {
        /// <summary>
        /// 面料ID
        /// </summary>
        public int PlusMaterialId { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public float Count { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public float Price { get; set; }
    }
}
