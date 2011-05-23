using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using PMMS.Services.System;
using PMMS.Forms.Utils;

namespace PMMS.Forms
{
    public partial class FormPlusMaterialSearch : Form
    {
        TextBox txtBox;
        IPlusMaterialLogic plusMaterialLogic;

        public FormPlusMaterialSearch(TextBox txtBox)
        {
            InitializeComponent();
            this.txtBox = txtBox;
            this.plusMaterialLogic = UnityControllerFactory.Container.Resolve<IPlusMaterialLogic>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindIntoTable();
        }

        private void BindIntoTable()
        {
            lvPlus.Items.Clear();
            var list = plusMaterialLogic.ListPlusMaterial(new ListPlusMaterialParmeters()
               {
                   No = txtNo.Text.Trim(),
                   Name = txtName.Text.Trim(),
                   Color = txtColor.Text.Trim(),
                   Supplier = txtSupplier.Text.Trim()
               });
            foreach (var item in list)
            {
                var listItem = new ListViewItem(new string[]
                {
                    item.No,
                    item.Name,
                    item.StockCount.ToString(),
                    item.Color,
                    item.Remark,
                });
                listItem.Tag = item;
                this.lvPlus.Items.Add(listItem);
            }

        }

        private void FormPlusMaterialSearch_Load(object sender, EventArgs e)
        {
            BindIntoTable();
        }

        private void dgvPlus_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void lvPlus_DoubleClick(object sender, EventArgs e)
        {
            txtBox.Text = lvPlus.FocusedItem.Text;
            this.Hide();
        }
    }
}
