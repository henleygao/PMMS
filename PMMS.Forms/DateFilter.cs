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
        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public DateFilter()
        {
            InitializeComponent();
        }

        private void DateFilter_Load(object sender, EventArgs e)
        {
            panelDtp.Visible = false;
            panelMonth.Visible = false;
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
        }
    }
}
