using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMMS.Services.System;
using PMMS.Services.Impl.System;
using PMMS.Exceptions;
using System.IO;
using PMMS.Forms.Reports;
using PMMS.Forms.Utils;
using Microsoft.Practices.Unity;

namespace PMMS.Forms
{
    public partial class FormPlusMaterial : Form
    {
        IPlusMaterialLogic plusMaterialLogic;

        public FormPlusMaterial()
        {
            this.plusMaterialLogic = UnityControllerFactory.Container.Resolve<IPlusMaterialLogic>();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 编号
            string no = txtNo.Text.Trim();
            if (string.IsNullOrEmpty(no))
            {
                MessageBox.Show("编号是必填的.");
                txtNo.Focus();
                return;
            }
            #endregion

            #region 名称
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("名称是必填的.");
                txtName.Focus();
                return;
            }
            #endregion

            #region 单价
            string priceStr = txtPrice.Text.Trim();
            if (string.IsNullOrEmpty(priceStr))
            {
                MessageBox.Show("单价是必填的.");
                txtPrice.Focus();
                return;
            }
            float price = 0;
            try
            {
                price = Convert.ToSingle(priceStr);
            }
            catch (Exception)
            {
                MessageBox.Show("单价必须是数值.");
                txtPrice.Focus();
                return;
            }
            #endregion

            #region 数量
            string countStr = txtCount.Text.Trim();
            if (string.IsNullOrEmpty(countStr))
            {
                MessageBox.Show("数量是必填的.");
                txtCount.Focus();
                return;
            }
            float count = 0;
            try
            {
                count = Convert.ToSingle(countStr);
            }
            catch (Exception)
            {
                MessageBox.Show("数量必须是数值.");
                txtCount.Focus();
                return;
            }
            #endregion

            #region 布封
            string fabricWidthStr = txtFabricWidth.Text.Trim();
            if (string.IsNullOrEmpty(fabricWidthStr))
            {
                MessageBox.Show("布封是必填的.");
                txtFabricWidth.Focus();
                return;
            }
            float fabricWidth = 0;
            try
            {
                fabricWidth = Convert.ToSingle(fabricWidthStr);
            }
            catch (Exception)
            {
                MessageBox.Show("布封必须是数值.");
                txtFabricWidth.Focus();
                return;
            }
            #endregion

            try
            {
                plusMaterialLogic.AddPlusMaterial(new PlusMaterialAddView()
                {
                    No = no,
                    Color = txtColor.Text.Trim(),
                    FabricWidth = fabricWidth,
                    Name = name,
                    Price = price,
                    Remark = txtRemark.Text.Trim(),
                    StockCount = count,
                    Supplier = txtSupplier.Text.Trim()
                });
                tabControl.SelectedIndex = 0;
                BindTable();
                ClearAfterAddSucess();//添加成功后清除
            }
            catch (RepeatException)
            {
                MessageBox.Show("该编号已经存在!");
            }
        }

        private void ClearAfterAddSucess()
        {
            txtNo.Clear();
            txtName.Clear();
            txtSupplier.Clear();
            txtColor.Clear();
            txtPrice.Clear();
            txtCount.Clear();
            txtFabricWidth.Clear();
            txtRemark.Clear();
        }

        private void BindTable()
        {
            dgvPlus.DataSource = plusMaterialLogic.ListPlusMaterial(new ListPlusMaterialParmeters()
            {
                No = txtSearchNo.Text.Trim(),
                Name = txtSearchName.Text.Trim(),
                Color = txtSearchColor.Text.Trim(),
                Supplier = txtSearchSupplier.Text.Trim()
            });
        }

        private void FormPlusMaterialList_Load(object sender, EventArgs e)
        {
            BindTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindTable();
        }

        private void tabPagList_Click(object sender, EventArgs e)
        {
            BindTable();
        }

        private void dgPlus_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPlus.Columns["Id"].Visible = false;
            dgvPlus.RowHeadersWidth = 50;
            dgvPlus.TopLeftHeaderCell.Value = "序号";
            for (int i = 0; i < dgvPlus.Rows.Count; i++)
            {
                dgvPlus.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void dgPlus_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var pid = Convert.ToInt32(dgvPlus.Rows[e.RowIndex].Cells["Id"].Value);
            var no = dgvPlus.Rows[e.RowIndex].Cells["No"].Value.ToString();
            var name = dgvPlus.Rows[e.RowIndex].Cells["PlusName"].Value.ToString();
            var color = dgvPlus.Rows[e.RowIndex].Cells["Color"].Value.ToString();
            var supplier = dgvPlus.Rows[e.RowIndex].Cells["Supplier"].Value.ToString();
            var fabricWidth = Convert.ToSingle(dgvPlus.Rows[e.RowIndex].Cells["FabricWidth"].Value.ToString());
            var price = Convert.ToSingle(dgvPlus.Rows[e.RowIndex].Cells["Price"].Value.ToString());
            var stockCount = Convert.ToSingle(dgvPlus.Rows[e.RowIndex].Cells["StockCount"].Value.ToString());
            var remark = dgvPlus.Rows[e.RowIndex].Cells["Remark"].Value.ToString();

            if (string.IsNullOrEmpty(no.Trim()))
            {
                MessageBox.Show("编号不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(name.Trim()))
            {
                MessageBox.Show("面料名称不能为空!");
                return;
            }
            try
            {
                plusMaterialLogic.UpdatePlusMaterial(new PlusMaterialUpdateView()
                {
                    Id = pid,
                    Color = color,
                    FabricWidth = fabricWidth,
                    Name = name,
                    No = no,
                    Price = price,
                    Remark = remark,
                    StockCount = stockCount,
                    Supplier = supplier
                });
            }
            catch (RepeatException)
            {
                MessageBox.Show("该编号已经存在!");
                dgvPlus.CurrentCell = dgvPlus.Rows[e.RowIndex].Cells["No"];
            }
        }


        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            var list = plusMaterialLogic.ListPlusMaterial(new ListPlusMaterialParmeters()
                {
                    No = txtSearchNo.Text.Trim(),
                    Name = txtSearchName.Text.Trim(),
                    Color = txtSearchColor.Text.Trim(),
                    Supplier = txtSearchSupplier.Text.Trim()
                });

            var tempFileName = Path.GetTempFileName().Replace(".tmp", ".xls");
            var templateFile = Path.Combine(Application.StartupPath, "Templates\\面料.xls");
            new PlusMaterialReport().GetReport(list, templateFile, tempFileName);
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtName.Focus();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtCount.Focus();
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPrice.Focus();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.txtFabricWidth.Focus();
        }

        private void txtFabricWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.txtColor.Focus();
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.txtSupplier.Focus();
        }

        private void txtSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.txtRemark.Focus();
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSave.Focus();
        }

        private void dgvPlus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.KeyChar = (char)9;
            }
        }
    }
}
