using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHibernate.Cfg;
using PMMS.Entities.Mapping;
using PMMS.Forms.Utils;
using PMMS.Services.System;
using PMMS.Services.StockManage;
using Microsoft.Practices.Unity;

namespace PMMS.Forms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UnityControllerFactory.Configure();
         
            //var plusMaterialLogic = container.Resolve<IPlusMaterialLogic>();
            //var stockInLogic = container.Resolve<IStockInLogic>();
            //var stockOutLogic = container.Resolve<IStockOutLogic>();
            Application.Run(new FormLogin());
        }
    }
}
