using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMMS.Services.StockManage;
using Microsoft.Practices.Unity;
using PMMS.Forms.Utils;
using PMMS.Exceptions;
namespace PMMS.Forms
{
    public partial class FormStockOutCreate : MasterForm
    {
        IStockOutLogic stockOutLogic;
        List<StockOutDetailView> details = new List<StockOutDetailView>();
        FormMain formMain;

        public FormStockOutCreate(FormMain formMain)
        {
            InitializeComponent();
            this.stockOutLogic = UnityControllerFactory.Container.Resolve<IStockOutLogic>();
            this.formMain = formMain;
        }

        private void FormStockOutCreate_Load(object sender, EventArgs e)
        {
            dgvPlus.RowHeadersWidth = 50;
            dgvPlus.TopLeftHeaderCell.Value = "序号";
            dgvPlus.AutoGenerateColumns = false; //取消自动生成列
            dgvPlus.DataSource = details;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPlusToTable();
        }

        private void AddPlusToTable()
        {
            string plusNo = txtPlusNo.Text.Trim();
            try
            {
                if (!string.IsNullOrEmpty(plusNo))
                {
                    if (!details.Select(item => item.PlusMaterialNo).Contains(plusNo))
                    {
                        var detail = stockOutLogic.GetStockOutDetail(plusNo);
                        details.Add(detail);
                        var ds = new List<StockOutDetailView>();
                        foreach (var item in details)
                            ds.Add(item);
                        ds.Reverse();
                        dgvPlus.DataSource = ds;
                        dgvPlus.Rows[0].Cells[0].Selected = false;
                        dgvPlus.Rows[0].Cells["Count"].Selected = true;
                        dgvPlus.CurrentCell = dgvPlus.Rows[0].Cells["Count"];
                        dgvPlus.BeginEdit(true);
                    }
                }
            }
            catch (NotExistException)
            {
                MessageBox.Show("该面料没有找到.");
                txtPlusNo.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string no = txtNo.Text.Trim();
            if (string.IsNullOrEmpty(no))
            {
                MessageBox.Show("业务单号不能为空！");
                return;
            }

            if (dgvPlus.Rows.Count == 0)
            {
                MessageBox.Show("面料不能为空！");
                return;
            }

            var stockOutDetails = new List<StockOutDetailAddView>();
            foreach (DataGridViewRow row in dgvPlus.Rows)
            {
                stockOutDetails.Add(new StockOutDetailAddView()
                {
                    PlusMaterialId = Convert.ToInt32(row.Cells["PlusMaterialId"].Value),
                    Count = Convert.ToSingle(row.Cells["Count"].Value),
                    Price = Convert.ToSingle(row.Cells["Price"].Value),
                });
            }
            try
            {
                stockOutLogic.AddStockOut(new StockOutAddView()
                {
                    CreateUserId = CurrentUser.Id,
                    No = no,
                    Remark = txtRemark.Text,
                    StockOutDateTime = dtpStockOutDate.Value,
                    StockOutDetails = stockOutDetails
                });
                formMain.BindStockOutTable();
                this.Close();
            }
            catch (RepeatException)
            {
                MessageBox.Show("该单号已经存在，请重新输入.");
                txtNo.Focus();
            }
            catch (StockOutCountMoreThanStockCountException se)
            {
                var msg = se.Stocks.Select(item => string.Format("{0} 的数量不能大于{1}", item.Key, item.Value)).ToArray();
                MessageBox.Show(string.Join("\n", msg));
            }
        }

        private void dgvPlus_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPlus.Columns["PlusMaterialId"].Visible = false;
            dgvPlus.RowHeadersWidth = 50;
            dgvPlus.TopLeftHeaderCell.Value = "序号";
            for (int i = 0; i < dgvPlus.Rows.Count; i++)
            {
                dgvPlus.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void dgvPlus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvPlus.CurrentCell.ColumnIndex == dgvPlus.Rows[0].Cells["Count"].ColumnIndex)
                {
                    dgvPlus.CurrentCell = dgvPlus.Rows[0].Cells["Price"];
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new FormPlusMaterialSearch(txtPlusNo).ShowDialog();
        }

        private void dgvPlus_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var countColumnIndex = dgvPlus.Rows[e.RowIndex].Cells["Count"].ColumnIndex;

            string countStr = dgvPlus.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();

            if (e.ColumnIndex == countColumnIndex)
            {
                if (string.IsNullOrEmpty(countStr))
                {
                    MessageBox.Show("请输入入库数量.");
                    return;
                }
                try
                {
                    float countOut = Convert.ToSingle(countStr);
                    if (countOut <= 0)
                    {
                        MessageBox.Show("出库数量必须是大于0.");
                        return;
                    }
                    var plusMaterialId = Convert.ToInt32(dgvPlus.Rows[e.RowIndex].Cells["PlusMaterialId"].Value);
                    var plus = stockOutLogic.GetStockOutDetail(plusMaterialId);
                    if (countOut > plus.Count)
                    {
                        MessageBox.Show(string.Format("{0}的出库数量不能大于{1}.", plus.PlusMaterialNo, plus.Count));
                        return;
                    }
                    float price = Convert.ToSingle(dgvPlus.Rows[e.RowIndex].Cells["Price"].Value);
                    dgvPlus.Rows[e.RowIndex].Cells["Amount"].Value = countOut * price;
                    dgvPlus.Refresh();
                    txtRemark.Focus();
                }
                catch (Exception)
                {
                    MessageBox.Show("出库数量必须是数值.");
                    return;
                }

            }
        }

        private void dgvPlus_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show("请输入数值.");
            }
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPlusNo.Focus();
        }

        private void txtPlusNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                AddPlusToTable();
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.btnSave.Focus();
        }

    }
}
