using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Exceptions
{
    /// <summary>
    /// 出库数量大于库存数量时抛出
    /// </summary>
    public class StockOutCountMoreThanStockCountException : Exception
    {
        /// <summary>
        /// string为面料的No
        /// float为面料的库存数量
        /// </summary>
        public Dictionary<string, float> Stocks { get; set; }
    }
}
