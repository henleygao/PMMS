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
namespace PMMS.Forms
{
    public partial class FormStockOutCreate : MasterForm
    {
        IStockOutLogic stockOutLogic;
        List<StockOutDetailView> details = new List<StockOutDetailView>();

        public FormStockOutCreate()
        {
            InitializeComponent();
            this.stockOutLogic = UnityControllerFactory.Container.Resolve<IStockOutLogic>(); ;
        }

        private void FormStockOutCreate_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string plusNo = txtPlusNo.Text.Trim();
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
                }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string no = txtNo.Text.Trim();
            if (string.IsNullOrEmpty(no))
            {
                MessageBox.Show("出库单号不能为空！");
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

            stockOutLogic.AddStockOut(new StockOutAddView()
            {
                CreateUserId = CurrentUser.Id,
                No = no,
                Remark = txtRemark.Text,
                StockOutDetails = stockOutDetails
            });
        }
    }
}
