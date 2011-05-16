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

        }
    }
}
