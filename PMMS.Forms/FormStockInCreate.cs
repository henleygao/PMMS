using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMMS.Services.StockManage;
using PMMS.Enum;
using Microsoft.Practices.Unity;
using PMMS.Forms.Utils;
using PMMS.Exceptions;
namespace PMMS.Forms
{
    public partial class FormStockInCreate : MasterForm
    {
        IStockInLogic stockInLogic;
        List<StockInDetailView> details = new List<StockInDetailView>();

        FormMain formmain;

        public FormStockInCreate(FormMain formmain)
        {
            InitializeComponent();
            this.stockInLogic = UnityControllerFactory.Container.Resolve<IStockInLogic>();
            dgvPlus.DataSource = details;
            this.formmain = formmain;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string plusNo = txtPlusNo.Text.Trim();
            if (!string.IsNullOrEmpty(plusNo))
            {
                if (!details.Select(item => item.PlusMaterialNo).Contains(plusNo))
                {
                    var detail = stockInLogic.GetStockInDetail(plusNo);
                    details.Add(detail);
                    var ds = new List<StockInDetailView>();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string no = txtNo.Text.Trim();
            if (string.IsNullOrEmpty(no))
            {
                MessageBox.Show("入库单号不能为空！");
                return;
            }

            if (dgvPlus.Rows.Count == 0)
            {
                MessageBox.Show("面料不能为空！");
                return;
            }

            var stockInDetails = new List<StockInDetailAddView>();
            foreach (DataGridViewRow row in dgvPlus.Rows)
            {
                stockInDetails.Add(new StockInDetailAddView()
                {
                    PlusMaterialId = Convert.ToInt32(row.Cells["PlusMaterialId"].Value),
                    Count = Convert.ToSingle(row.Cells["Count"].Value),
                    Price = Convert.ToSingle(row.Cells["Price"].Value),
                });
            }
            try
            {
                stockInLogic.AddStockIn(new StockInAddView()
                {
                    CreateUserId = CurrentUser.Id,
                    No = no,
                    Remark = txtRemark.Text,
                    StockInType = this.rbPurchase.Checked ? StockInType.Purchase : StockInType.Returned,
                    StockInDetails = stockInDetails
                });
                formmain.BindStockInTable();
                this.Close();
            }
            catch (RepeatException)
            {
                MessageBox.Show("该单号已经存在，请重新输入.");
                txtNo.Focus();
            }
        }

        private void FormStockIn_Load(object sender, EventArgs e)
        {
            dgvPlus.RowHeadersWidth = 50;
            dgvPlus.TopLeftHeaderCell.Value = "序号";
        }

        private void dgvPlus_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPlus.Columns["PlusMaterialId"].Visible = false;

            for (int i = 0; i < dgvPlus.Rows.Count; i++)
            {
                dgvPlus.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void dgvPlus_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dgvPlus_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var CountColumnIndex = dgvPlus.Rows[e.RowIndex].Cells["Count"].ColumnIndex;
            string countStr = dgvPlus.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();

            if (e.ColumnIndex == CountColumnIndex)
            {
                if (string.IsNullOrEmpty(countStr))
                {
                    MessageBox.Show("请输入入库数量.");
                    return;
                }
                try
                {
                    float count = Convert.ToSingle(countStr);
                    if (count <= 0)
                    {
                        MessageBox.Show("入库数量必须是大于0.");
                        return;
                    }
                    float price = Convert.ToSingle(dgvPlus.Rows[e.RowIndex].Cells["Price"].Value);
                    dgvPlus.Rows[e.RowIndex].Cells["Amount"].Value = count * price;
                    dgvPlus.Refresh();
                }
                catch (Exception)
                {
                    MessageBox.Show("入库数量必须是数值.");
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

    }
}
