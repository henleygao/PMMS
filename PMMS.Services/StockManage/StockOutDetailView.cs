using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.StockManage
{
    public class StockOutDetailView
    {
        /// <summary>
        /// 面料ID
        /// </summary>
        public int PlusMaterialId { get; set; }

        /// <summary>
        /// 面料编号
        /// </summary>
        public string PlusMaterialNo { get; set; }

        /// <summary>
        /// 面料名称
        /// </summary>
        public string PlusMaterialName { get; set; }

        /// <summary>
        /// 面料备注
        /// </summary>
        public string PlusMateriaRemark { get; set; }

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
