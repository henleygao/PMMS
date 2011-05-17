using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMMS.Forms
{
    public partial class DateFilter : UserControl
    {
        public DateTime? DateFrom { get; private set; }

        public DateTime? DateTo { get; private set; }

        public DateFilter(Point point)
        {
            InitializeComponent();
            this.Location = point;
            panelDtp.Visible = false;
            panelMonth.Visible = false;

            cbFromYear.SelectedIndex = 0;
            cbFromMonth.SelectedIndex = 0;
            cbToYear.SelectedIndex = 0;
            cbToMonth.SelectedIndex = 0;

            for (int i = DateTime.Now.Year - 5; i < DateTime.Now.Year + 5; i++)
            {
                cbFromYear.Items.Add(i);
                cbToYear.Items.Add(i);
            }

        }

        private void DateFilter_Load(object sender, EventArgs e)
        {

        }

        private void cbDateFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDateFilterType.Text == "日期段")
            {
                panelDtp.Visible = true;
                panelMonth.Visible = false;
            }
            else if (cbDateFilterType.Text == "月份范围")
            {
                panelDtp.Visible = false;
                panelMonth.Visible = true;
            }
            else
            {
                panelDtp.Visible = false;
                panelMonth.Visible = false;
            }
            var today = DateTime.Today;

            var selectText = cbDateFilterType.Text;
            if (selectText == "今天")
            {
                DateFrom = today;
                DateTo = today.AddDays(1);
            }
            else if (selectText == "昨天")
            {
                DateFrom = today.AddDays(-1);
                DateTo = today;
            }
            else if (selectText == "本周")
            {
                DateFrom = GetWeekFirstDate(DateTime.Today);
                DateTo = DateFrom.Value.AddDays(7);
            }
            else if (selectText == "本月")
            {
                DateFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTo = DateFrom.Value.AddMonths(1);
            }
            else if (selectText == "上月")
            {
                DateFrom = new DateTime(today.AddMonths(-1).Year, today.AddMonths(-1).Month, 1);
                DateTo = DateFrom.Value.AddMonths(1);
            }
            else if (selectText == "今年")
            {
                DateFrom = new DateTime(today.Year, 1, 1);
                DateTo = DateFrom.Value.AddYears(1);
            }
            else if (selectText == "日期段")
            {
                SetValueByDaySelect();
            }
            else if (selectText == "月份范围")
            {
                //   SetValueByMonthSelect();
            }
            else
            {
                DateFrom = null;
                DateTo = null;
            }
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

        private void SetValueByDaySelect()
        {
            DateFrom = dtpFrom.Value;
            DateTo = dtpTo.Value;
        }

        private void SetValueByMonthSelect()
        {
            DateFrom = new DateTime(Convert.ToInt32(cbFromYear.Text), Convert.ToInt32(cbFromMonth.Text), 1);
            DateTo = new DateTime(Convert.ToInt32(cbToYear.Text), Convert.ToInt32(cbToMonth.Text), 1);
        }

        private void cbFromYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValueByMonthSelect();
        }

        private void cbFromMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValueByMonthSelect();
        }

        private void cbToYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValueByMonthSelect();
        }

        private void cbToMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValueByMonthSelect();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            SetValueByDaySelect();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            SetValueByDaySelect();
        }
    }
}
