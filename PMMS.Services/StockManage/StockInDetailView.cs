using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.StockManage
{
    public class StockInDetailView
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
        public string PlusMaterialRemark { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public float Count { get; set; }

        public float Amount
        {
            get
            {
                return Price * Count;
            }
        }

    }
}
