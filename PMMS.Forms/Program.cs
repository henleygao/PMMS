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
using MySql.Data.MySqlClient;

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
            Application.ThreadException += ApplicationThreadException;
            try
            {
                UnityControllerFactory.Configure();
                Application.Run(new FormLogin());
            }
            catch (MySqlException e)
            {
                if (e.Message == "Unknown database \'pmms\'")
                {
                   // new DataBasesInit().Init();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }


    }
}
