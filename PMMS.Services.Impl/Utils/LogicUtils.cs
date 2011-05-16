using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PMMS.Exceptions;

namespace PMMS.Services.Impl.Utils
{

    /// <summary>
    /// 逻辑工具类
    /// </summary>
    public static class LogicUtils
    {
        /// <summary>
        /// 判断对象实例是否为空,是则抛出异常
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象</returns>
        public static T NotNull<T>(T obj) where T : class
        {
            if (obj == null)
                throw new NotExistException();
            return obj;
        }

        /// <summary>
        /// 判断对象实例是否为空,是则抛出异常
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象</returns>
        public static T NotNull<T>(T obj, string message) where T : class
        {
            if (obj == null)
                throw new NotExistException(message);
            return obj;
        }

        /// <summary>
        /// 将数据流写入到文件
        /// </summary>
        /// <param name="stream">文件数据流</param>
        /// <param name="fs">写入文件的数据流</param>
        public static void CopyStream(Stream stream, Stream fs)
        {
            int b;
            while ((b = stream.ReadByte()) != -1)
            {
                fs.WriteByte((byte)b);
            }
            //fs.Close();
            //stream.Close();
        }

        /// <summary>
        /// 获取指定日期所在星期的第一天
        /// </summary>
        /// <param name="date">日期对象</param>
        /// <returns>日期</returns>
        public static DateTime GetWeekFirstDate(DateTime date)
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    date = date.AddDays(-6);
                    break;
                case DayOfWeek.Saturday:
                    date = date.AddDays(-5);
                    break;
                case DayOfWeek.Friday:
                    date = date.AddDays(-4);
                    break;
                case DayOfWeek.Thursday:
                    date = date.AddDays(-3);
                    break;
                case DayOfWeek.Wednesday:
                    date = date.AddDays(-2);
                    break;
                case DayOfWeek.Tuesday:
                    date = date.AddDays(-1);
                    break;
                case DayOfWeek.Monday:
                    break;
            }
            return date;
        }

        /// <summary>
        /// 获取指定日期是所在月份的第几周
        /// </summary>
        /// <returns>周数（1表示第1周，以似类推）</returns>
        public static int GetMonthOfWeek(DateTime date)
        {
            //获取日期所在月分的的几天   
            int days = date.Day;
            int weeks = 0;
            for (int i = 1; i <= days; i++)
            {
                //返回日期   
                var dayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);

                //如果是星期一就算一周   
                if (Convert.ToInt32(dayDate.DayOfWeek) == 1)
                {
                    weeks++;
                }
            }

            return weeks;
        }
    }
}

