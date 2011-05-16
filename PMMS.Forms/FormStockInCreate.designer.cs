namespace PMMS.Forms
{
    partial class FormStockInCreate
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
            this.rbReturned = new System.Windows.Forms.RadioButton();
            this.rbPurchase = new System.Windows.Forms.RadioButton();
            this.dtpStockInDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlusNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvPlus = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMaterialRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMaterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlus)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbReturned
            // 
            this.rbReturned.AutoSize = true;
            this.rbReturned.Location = new System.Drawing.Point(452, 3);
            this.rbReturned.Name = "rbReturned";
            this.rbReturned.Size = new System.Drawing.Size(47, 16);
            this.rbReturned.TabIndex = 3;
            this.rbReturned.Text = "退料";
            this.rbReturned.UseVisualStyleBackColor = true;
            // 
            // rbPurchase
            // 
            this.rbPurchase.AutoSize = true;
            this.rbPurchase.Checked = true;
            this.rbPurchase.Location = new System.Drawing.Point(399, 3);
            this.rbPurchase.Name = "rbPurchase";
            this.rbPurchase.Size = new System.Drawing.Size(47, 16);
            this.rbPurchase.TabIndex = 2;
            this.rbPurchase.TabStop = true;
            this.rbPurchase.Text = "入库";
            this.rbPurchase.UseVisualStyleBackColor = true;
            // 
            // dtpStockInDate
            // 
            this.dtpStockInDate.Location = new System.Drawing.Point(399, 32);
            this.dtpStockInDate.Name = "dtpStockInDate";
            this.dtpStockInDate.Size = new System.Drawing.Size(145, 21);
            this.dtpStockInDate.TabIndex = 7;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(166, 12);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(394, 55);
            this.txtRemark.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "备注";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(154, 7);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(145, 21);
            this.txtNo.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(95, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 42;
            this.label12.Text = "业务单号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(364, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "入库类型";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(240, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(358, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "面料编号";
            // 
            // txtPlusNo
            // 
            this.txtPlusNo.Location = new System.Drawing.Point(154, 34);
            this.txtPlusNo.Name = "txtPlusNo";
            this.txtPlusNo.Size = new System.Drawing.Size(69, 21);
            this.txtPlusNo.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(225, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(29, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "?";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(259, 33);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvPlus
            // 
            this.dgvPlus.AllowUserToOrderColumns = true;
            this.dgvPlus.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.PlusMaterialName,
            this.Count,
            this.Price,
            this.Amount,
            this.PlusMaterialRemark,
            this.PlusMaterialId});
            this.dgvPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlus.Location = new System.Drawing.Point(0, 0);
            this.dgvPlus.Name = "dgvPlus";
            this.dgvPlus.RowTemplate.Height = 23;
            this.dgvPlus.Size = new System.Drawing.Size(694, 227);
            this.dgvPlus.TabIndex = 8;
            this.dgvPlus.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlus_CellValueChanged);
            this.dgvPlus.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlus_CellEndEdit);
            this.dgvPlus.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPlus_DataError);
            this.dgvPlus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPlus_KeyDown);
            this.dgvPlus.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPlus_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PlusMaterialNo";
            this.Column1.HeaderText = "面料编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // PlusMaterialName
            // 
            this.PlusMaterialName.DataPropertyName = "PlusMaterialName";
            this.PlusMaterialName.HeaderText = "面料名称";
            this.PlusMaterialName.Name = "PlusMaterialName";
            this.PlusMaterialName.ReadOnly = true;
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
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "入库金额";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
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
            this.PlusMaterialId.HeaderText = "面料ID";
            this.PlusMaterialId.Name = "PlusMaterialId";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 125);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbReturned);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rbPurchase);
            this.panel2.Controls.Add(this.txtPlusNo);
            this.panel2.Controls.Add(this.dtpStockInDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 73);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvPlus);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 227);
            this.panel3.TabIndex = 2;
            // 
            // FormStockInCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 425);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormStockInCreate";
            this.Text = "添加入库/退料单";
            this.Load += new System.EventHandler(this.FormStockIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbReturned;
        private System.Windows.Forms.RadioButton rbPurchase;
        private System.Windows.Forms.DateTimePicker dtpStockInDate;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlusNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvPlus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMaterialRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMaterialId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;



    }
}