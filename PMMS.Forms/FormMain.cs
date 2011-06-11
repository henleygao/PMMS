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
using PMMS.Enum;
using System.IO;

namespace PMMS.Forms
{
    public partial class FormMain : MasterForm
    {
        private static string DatabaeseName = "PMMS.db";
        public static string DatabasesFile = Path.Combine(Application.StartupPath, string.Format("DB\\{0}", DatabaeseName));

        IUserLogic userLogic;
        IPlusMaterialLogic plusMaterialLogic;
        IStockInLogic stockInLogic;
        IStockOutLogic stockOutLogic;

        DateFilter dfStockIn = new DateFilter(new Point(438, 5));
        DateFilter dfStockInApprove = new DateFilter(new Point(438, 33));

        DateFilter dfStockOut = new DateFilter(new Point(254, 4));
        DateFilter dfStockOutApprove = new DateFilter(new Point(254, 32));

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
            panelStockInSearch.Controls.Add(dfStockInApprove);

            PanelStockOut.Controls.Add(dfStockOut);
            PanelStockOut.Controls.Add(dfStockOutApprove);

            cbStockInStatus.SelectedIndex = 0;
            cbStokcInType.SelectedIndex = 0;
        }

        //用户管理
        private void tsmiUser_Click(object sender, EventArgs e)
        {
            new FormUser(userLogic).ShowDialog();
        }

        //款式管理
        private void tsmiStyle_Click(object sender, EventArgs e)
        {
            new FormPlusMaterial().ShowDialog();
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
            var stockInDateRange = dfStockIn.DateRange;
            var approveDateRange = dfStockInApprove.DateRange;

            StockInStatus? stockInStatus = null;
            if (cbStockInStatus.Text == "草稿")
                stockInStatus = StockInStatus.Normal;
            if (cbStockInStatus.Text == "已检货")
                stockInStatus = StockInStatus.Approve;

            StockInType? stockType = null;
            if (cbStokcInType.Text == "采购入库")
                stockType = StockInType.Purchase;
            if (cbStokcInType.Text == "退货入库")
                stockType = StockInType.Returned;

            dgvStockIn.DataSource = stockInLogic.ListStockIn(new ListStockInParmeters()
            {
                No = txtStockInNo.Text,
                ApproveDateRange = approveDateRange,
                CreateDateRange = stockInDateRange,
                Status = stockInStatus,
                Type = stockType,
                Remark = txtRemark.Text
            });
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
        /// 入库检货
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
            new FormStockOutCreate(this).ShowDialog();
        }

        /// <summary>
        /// 查询出库列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockOutSearch_Click(object sender, EventArgs e)
        {
            BindStockOutTable();
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
            StockOutStatus? stockOutStatus = null;
            if (cbStockOutStatus.Text == "草稿")
                stockOutStatus = PMMS.Enum.StockOutStatus.Normal;
            if (cbStockOutStatus.Text == "已检货")
                stockOutStatus = PMMS.Enum.StockOutStatus.Approve;

            dgvStockOut.DataSource = stockOutLogic.ListStockOut(new ListStockOutParmeters()
            {
                No = txtStockOutNo.Text,
                CreateDateRange = dfStockOut.DateRange,
                ApproveDateRange = dfStockOutApprove.DateRange,
                Status = stockOutStatus
            });
        }
        #endregion

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Text == tabPageStockOut.Text)
                BindStockOutTable();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }

        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDatabasesBackup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultDialog = folderBrowserDialog.ShowDialog();
                if (resultDialog == DialogResult.OK)
                {
                    var file = string.Format("{0}\\PMMS_{1}.db", folderBrowserDialog.SelectedPath, DateTime.Now.ToString("yyyyMMddHHmmss"));
                    DataBasesUtils.Backup(DatabasesFile, file);
                    MessageBox.Show("数据库成功备份到" + file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 数据库还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDatabasesRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultDialog = this.openFileDialog.ShowDialog();
                if (resultDialog == DialogResult.OK)
                {
                    if (!File.Exists(openFileDialog.FileName))
                    {
                        MessageBox.Show("数据库文件不存在!");
                        return;
                    }

                    FileStream fs = (FileStream)openFileDialog.OpenFile();
                    if (fs != null)
                    {
                        fs.Close();
                    }
                    DialogResult res = MessageBox.Show(" 是否确认恢复数据库？", "恢复数据库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        DataBasesUtils.Restore(DatabasesFile, openFileDialog.FileName);
                        MessageBox.Show("数据库已经还原成功!");
                    }

                }
                saveFileDialog.FileName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
