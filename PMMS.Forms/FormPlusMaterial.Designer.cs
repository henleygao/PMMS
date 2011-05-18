namespace PMMS.Forms
{
    partial class FormPlusMaterial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearchSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchColor = new System.Windows.Forms.TextBox();
            this.txtSearchNo = new System.Windows.Forms.TextBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagList = new System.Windows.Forms.TabPage();
            this.dgvPlus = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FabricWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabPageManager = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtFabricWidth = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlus)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.tabPageManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchSupplier
            // 
            this.txtSearchSupplier.Location = new System.Drawing.Point(55, 42);
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(145, 21);
            this.txtSearchSupplier.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "供应商";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 67;
            this.label4.Text = "颜色";
            // 
            // txtSearchColor
            // 
            this.txtSearchColor.Location = new System.Drawing.Point(303, 42);
            this.txtSearchColor.Name = "txtSearchColor";
            this.txtSearchColor.Size = new System.Drawing.Size(145, 21);
            this.txtSearchColor.TabIndex = 4;
            // 
            // txtSearchNo
            // 
            this.txtSearchNo.Location = new System.Drawing.Point(54, 15);
            this.txtSearchNo.Name = "txtSearchNo";
            this.txtSearchNo.Size = new System.Drawing.Size(145, 21);
            this.txtSearchNo.TabIndex = 1;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(303, 14);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(145, 21);
            this.txtSearchName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 71;
            this.label9.Text = "编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "名称";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(560, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(903, 514);
            this.panelMain.TabIndex = 85;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagList);
            this.tabControl.Controls.Add(this.tabPageManager);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(903, 514);
            this.tabControl.TabIndex = 1;
            // 
            // tabPagList
            // 
            this.tabPagList.Controls.Add(this.dgvPlus);
            this.tabPagList.Controls.Add(this.panelHeader);
            this.tabPagList.Location = new System.Drawing.Point(4, 21);
            this.tabPagList.Name = "tabPagList";
            this.tabPagList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagList.Size = new System.Drawing.Size(895, 489);
            this.tabPagList.TabIndex = 0;
            this.tabPagList.Text = "面料列表";
            this.tabPagList.UseVisualStyleBackColor = true;
            this.tabPagList.Click += new System.EventHandler(this.tabPagList_Click);
            // 
            // dgvPlus
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvPlus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlus.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.PlusName,
            this.Supplier,
            this.Color,
            this.FabricWidth,
            this.Price,
            this.StockCount,
            this.Remark,
            this.Id});
            this.dgvPlus.ContextMenuStrip = this.contextMenuStrip;
            this.dgvPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlus.Location = new System.Drawing.Point(3, 87);
            this.dgvPlus.Name = "dgvPlus";
            this.dgvPlus.RowTemplate.Height = 23;
            this.dgvPlus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlus.Size = new System.Drawing.Size(889, 399);
            this.dgvPlus.TabIndex = 1;
            this.dgvPlus.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPlus_CellEndEdit);
            this.dgvPlus.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgPlus_DataBindingComplete);
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "编号";
            this.No.Name = "No";
            // 
            // PlusName
            // 
            this.PlusName.DataPropertyName = "Name";
            this.PlusName.HeaderText = "名称";
            this.PlusName.Name = "PlusName";
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "Supplier";
            this.Supplier.HeaderText = "供应商";
            this.Supplier.Name = "Supplier";
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "颜色";
            this.Color.Name = "Color";
            // 
            // FabricWidth
            // 
            this.FabricWidth.DataPropertyName = "FabricWidth";
            this.FabricWidth.HeaderText = "布封";
            this.FabricWidth.Name = "FabricWidth";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            // 
            // StockCount
            // 
            this.StockCount.DataPropertyName = "StockCount";
            this.StockCount.HeaderText = "库存数量";
            this.StockCount.Name = "StockCount";
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tsmiDel});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(95, 48);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(94, 22);
            this.tsmiUpdate.Text = "修改";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(94, 22);
            this.tsmiDel.Text = "删除";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnExport);
            this.panelHeader.Controls.Add(this.txtSearchNo);
            this.panelHeader.Controls.Add(this.btnSearch);
            this.panelHeader.Controls.Add(this.label3);
            this.panelHeader.Controls.Add(this.txtSearchSupplier);
            this.panelHeader.Controls.Add(this.label9);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Controls.Add(this.txtSearchName);
            this.panelHeader.Controls.Add(this.txtSearchColor);
            this.panelHeader.Controls.Add(this.label4);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(889, 84);
            this.panelHeader.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(641, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 31);
            this.btnExport.TabIndex = 73;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabPageManager
            // 
            this.tabPageManager.Controls.Add(this.btnCancel);
            this.tabPageManager.Controls.Add(this.btnSave);
            this.tabPageManager.Controls.Add(this.txtNo);
            this.tabPageManager.Controls.Add(this.label1);
            this.tabPageManager.Controls.Add(this.txtSupplier);
            this.tabPageManager.Controls.Add(this.label5);
            this.tabPageManager.Controls.Add(this.label8);
            this.tabPageManager.Controls.Add(this.label16);
            this.tabPageManager.Controls.Add(this.label15);
            this.tabPageManager.Controls.Add(this.label10);
            this.tabPageManager.Controls.Add(this.txtPrice);
            this.tabPageManager.Controls.Add(this.txtName);
            this.tabPageManager.Controls.Add(this.label11);
            this.tabPageManager.Controls.Add(this.txtColor);
            this.tabPageManager.Controls.Add(this.label12);
            this.tabPageManager.Controls.Add(this.txtRemark);
            this.tabPageManager.Controls.Add(this.txtFabricWidth);
            this.tabPageManager.Controls.Add(this.txtCount);
            this.tabPageManager.Controls.Add(this.label13);
            this.tabPageManager.Location = new System.Drawing.Point(4, 21);
            this.tabPageManager.Name = "tabPageManager";
            this.tabPageManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManager.Size = new System.Drawing.Size(895, 489);
            this.tabPageManager.TabIndex = 1;
            this.tabPageManager.Text = "增加";
            this.tabPageManager.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(291, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(145, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(75, 23);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(145, 21);
            this.txtNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 88;
            this.label1.Text = "名称";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(76, 50);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(145, 21);
            this.txtSupplier.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 87;
            this.label5.Text = "编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 86;
            this.label8.Text = "供应商";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(40, 140);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 82;
            this.label16.Text = "备注";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 82;
            this.label15.Text = "布封";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "数量";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(75, 77);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(122, 21);
            this.txtPrice.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(324, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 21);
            this.txtName.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(204, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 83;
            this.label11.Text = "元";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(324, 50);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(145, 21);
            this.txtColor.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 85;
            this.label12.Text = "单价";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(75, 140);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(394, 48);
            this.txtRemark.TabIndex = 8;
            // 
            // txtFabricWidth
            // 
            this.txtFabricWidth.Location = new System.Drawing.Point(75, 107);
            this.txtFabricWidth.Name = "txtFabricWidth";
            this.txtFabricWidth.Size = new System.Drawing.Size(145, 21);
            this.txtFabricWidth.TabIndex = 7;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(324, 77);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(145, 21);
            this.txtCount.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(289, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 84;
            this.label13.Text = "颜色";
            // 
            // FormPlusMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 514);
            this.Controls.Add(this.panelMain);
            this.Name = "FormPlusMaterial";
            this.Text = "面料管理";
            this.Load += new System.EventHandler(this.FormPlusMaterialList_Load);
            this.panelMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlus)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabPageManager.ResumeLayout(false);
            this.tabPageManager.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchColor;
        private System.Windows.Forms.TextBox txtSearchNo;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagList;
        private System.Windows.Forms.DataGridView dgvPlus;
        private System.Windows.Forms.TabPage tabPageManager;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFabricWidth;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn FabricWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Button btnExport;

    }
}