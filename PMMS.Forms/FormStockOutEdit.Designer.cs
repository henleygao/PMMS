namespace PMMS.Forms
{
    partial class FormStockOutEdit
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
            this.dgvPlus = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMaterialRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMaterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpStockInDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPlusNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlus
            // 
            this.dgvPlus.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.PlusMaterialName,
            this.Count,
            this.Price,
            this.Column5,
            this.PlusMaterialRemark,
            this.PlusMaterialId});
            this.dgvPlus.Location = new System.Drawing.Point(6, 71);
            this.dgvPlus.Name = "dgvPlus";
            this.dgvPlus.RowTemplate.Height = 23;
            this.dgvPlus.Size = new System.Drawing.Size(745, 138);
            this.dgvPlus.TabIndex = 66;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PlusMaterialNo";
            this.Column1.HeaderText = "面料编码";
            this.Column1.Name = "Column1";
            // 
            // PlusMaterialName
            // 
            this.PlusMaterialName.DataPropertyName = "PlusMaterialName";
            this.PlusMaterialName.HeaderText = "面料名称";
            this.PlusMaterialName.Name = "PlusMaterialName";
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "入库数量";
            this.Count.Name = "Count";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "入库单价";
            this.Price.Name = "Price";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "入库金额";
            this.Column5.Name = "Column5";
            // 
            // PlusMaterialRemark
            // 
            this.PlusMaterialRemark.DataPropertyName = "PlusMaterialRemark";
            this.PlusMaterialRemark.HeaderText = "备注";
            this.PlusMaterialRemark.Name = "PlusMaterialRemark";
            // 
            // PlusMaterialId
            // 
            this.PlusMaterialId.DataPropertyName = "PlusMaterialId";
            this.PlusMaterialId.HeaderText = "ID";
            this.PlusMaterialId.Name = "PlusMaterialId";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(264, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 23);
            this.btnAdd.TabIndex = 63;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(230, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(29, 23);
            this.btnSearch.TabIndex = 62;
            this.btnSearch.Text = "?";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(347, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(229, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dtpStockInDate
            // 
            this.dtpStockInDate.Location = new System.Drawing.Point(404, 33);
            this.dtpStockInDate.Name = "dtpStockInDate";
            this.dtpStockInDate.Size = new System.Drawing.Size(145, 21);
            this.dtpStockInDate.TabIndex = 64;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(155, 215);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(394, 55);
            this.txtRemark.TabIndex = 65;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(120, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 69;
            this.label11.Text = "备注";
            // 
            // txtPlusNo
            // 
            this.txtPlusNo.Location = new System.Drawing.Point(159, 35);
            this.txtPlusNo.Name = "txtPlusNo";
            this.txtPlusNo.Size = new System.Drawing.Size(69, 21);
            this.txtPlusNo.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "面料编号";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(159, 8);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(145, 21);
            this.txtNo.TabIndex = 60;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(100, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 70;
            this.label12.Text = "业务单号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(369, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 72;
            this.label10.Text = "日期";
            // 
            // FormStockOutEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 323);
            this.Controls.Add(this.dgvPlus);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpStockInDate);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPlusNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Name = "FormStockOutEdit";
            this.ShowIcon = false;
            this.Text = "FormStockOutEdit";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMaterialRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMaterialId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpStockInDate;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPlusNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
    }
}