using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using PMMS.Services.System;
using PMMS.Services.StockManage;
using PMMS.Forms.Utils;
using Microsoft.Practices.Unity;

namespace PMMS.Forms
{
    public partial class FormMain : MasterForm
    {
        IUserLogic userLogic;
        IPlusMaterialLogic plusMaterialLogic;
        IStockInLogic stockInLogic;
        IStockOutLogic stockOutLogic;

        private DateFilter dfStockIn = new DateFilter(new Point(438, 5));
        private DateFilter dfApprove = new DateFilter(new Point(438, 33));

        public FormMain()
        {
            InitializeComponent();
            this.userLogic = UnityControllerFactory.Container.Resolve<IUserLogic>();
            this.plusMaterialLogic = UnityControllerFactory.Container.Resolve<IPlusMaterialLogic>();
            this.stockInLogic = UnityControllerFactory.Container.Resolve<IStockInLogic>();
            this.stockOutLogic = UnityControllerFactory.Container.Resolve<IStockOutLogic>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tsslUserInfo.Text = string.Format("当前登录用户:{0}", CurrentUser.Name);
            dgvStockIn.RowHeadersWidth = 50;
            dgvStockIn.TopLeftHeaderCell.Value = "序号";
            dgvStockOut.RowHeadersWidth = 50;
            dgvStockOut.TopLeftHeaderCell.Value = "序号";
            BindStockInTable();

            panelStockInSearch.Controls.Add(dfStockIn);
            panelStockInSearch.Controls.Add(dfApprove);

            cbStockInStatus.SelectedIndex = 0;
            cbStokcInType.SelectedIndex = 0;

        }

        //用户管理
        private void tsmiUser_Click(object sender, EventArgs e)
        {
            new FormUser(userLogic).Show();
        }

        //款式管理
        private void tsmiStyle_Click(object sender, EventArgs e)
        {
            new FormPlusMaterial(plusMaterialLogic).Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnStockInSearch_Click(object sender, EventArgs e)
        {
            BindStockInTable();
        }

        public void BindStockInTable()
        {
            dgvStockIn.DataSource = stockInLogic.ListStockIn(null);
        }

        private void dgvStockIn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvStockIn.Columns["Id"].Visible = false;

            for (int i = 0; i < dgvStockIn.Rows.Count; i++)
            {
                dgvStockIn.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }



        /// <summary>
        /// 检货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiApprove_Click(object sender, EventArgs e)
        {
            var ids = new List<int>();
            foreach (DataGridViewRow row in dgvStockIn.SelectedRows)
            {
                ids.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }
            if (ids.Count > 0)
            {
                stockInLogic.Approve(CurrentUser.Id, ids);
                BindStockInTable();
            }
        }

        private void btnStockAdd_Click(object sender, EventArgs e)
        {
            new FormStockInCreate(this).ShowDialog();
        }


        #region 出库管理

        private void dgvStockOut_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvStockOut.Columns["StockOutId"].Visible = false;

            for (int i = 0; i < dgvStockOut.Rows.Count; i++)
            {
                dgvStockOut.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void btnStockOutAdd_Click(object sender, EventArgs e)
        {
            new FormStockOutCreate().ShowDialog();
        }

        /// <summary>
        /// 查询出库列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockOutSearch_Click(object sender, EventArgs e)
        {
            this.dgvStockOut.DataSource = stockOutLogic.ListStockOut();
        }

        private void tsmiStockOutApprove_Click(object sender, EventArgs e)
        {
            var ids = new List<int>();
            foreach (DataGridViewRow row in dgvStockOut.SelectedRows)
            {
                ids.Add(Convert.ToInt32(row.Cells["StockOutId"].Value));
            }
            if (ids.Count > 0)
            {
                stockOutLogic.Approve(CurrentUser.Id, ids);
                BindStockOutTable();
            }
        }

        public void BindStockOutTable()
        {
            dgvStockOut.DataSource = stockOutLogic.ListStockOut();
        }
        #endregion

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Text == tabPageStockOut.Text)
                BindStockOutTable();
        }



    }
}
