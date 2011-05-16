using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMMS.Services.System;

namespace PMMS.Forms
{
    public class MasterForm : Form
    {
        public static UserView CurrentUser { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MasterForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "MasterForm";
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.ResumeLayout(false);

        }

        private void MasterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
