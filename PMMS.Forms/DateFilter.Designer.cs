using System;
using System.Collections.Generic;
namespace PMMS.Forms
{
    partial class DateFilter
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDtp = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.cbDateFilterType = new System.Windows.Forms.ComboBox();
            this.panelMonth = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbToMonth = new System.Windows.Forms.ComboBox();
            this.cbFromMonth = new System.Windows.Forms.ComboBox();
            this.cbToYear = new System.Windows.Forms.ComboBox();
            this.cbFromYear = new System.Windows.Forms.ComboBox();
            this.panelDtp.SuspendLayout();
            this.panelMonth.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDtp
            // 
            this.panelDtp.Controls.Add(this.dtpFrom);
            this.panelDtp.Controls.Add(this.label21);
            this.panelDtp.Controls.Add(this.dtpTo);
            this.panelDtp.Location = new System.Drawing.Point(78, 0);
            this.panelDtp.Name = "panelDtp";
            this.panelDtp.Size = new System.Drawing.Size(245, 27);
            this.panelDtp.TabIndex = 10;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(5, 3);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(102, 21);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(113, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 12);
            this.label21.TabIndex = 4;
            this.label21.Text = "至";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(136, 3);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(102, 21);
            this.dtpTo.TabIndex = 5;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // cbDateFilterType
            // 
            this.cbDateFilterType.CausesValidation = false;
            this.cbDateFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateFilterType.FormattingEnabled = true;
            this.cbDateFilterType.Items.AddRange(new object[] {
            "所有",
            "今天",
            "昨天",
            "本周",
            "上周",
            "本月",
            "上月",
            "今年",
            "日期段",
            "月份范围"});
            this.cbDateFilterType.Location = new System.Drawing.Point(3, 5);
            this.cbDateFilterType.Name = "cbDateFilterType";
            this.cbDateFilterType.Size = new System.Drawing.Size(71, 20);
            this.cbDateFilterType.TabIndex = 9;
            this.cbDateFilterType.SelectedIndexChanged += new System.EventHandler(this.cbDateFilterType_SelectedIndexChanged);
            // 
            // panelMonth
            // 
            this.panelMonth.Controls.Add(this.label2);
            this.panelMonth.Controls.Add(this.label5);
            this.panelMonth.Controls.Add(this.label4);
            this.panelMonth.Controls.Add(this.label3);
            this.panelMonth.Controls.Add(this.label1);
            this.panelMonth.Controls.Add(this.cbToMonth);
            this.panelMonth.Controls.Add(this.cbFromMonth);
            this.panelMonth.Controls.Add(this.cbToYear);
            this.panelMonth.Controls.Add(this.cbFromYear);
            this.panelMonth.Location = new System.Drawing.Point(78, 1);
            this.panelMonth.Name = "panelMonth";
            this.panelMonth.Size = new System.Drawing.Size(309, 27);
            this.panelMonth.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "年";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "月";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(146, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "年";
            // 
            // cbToMonth
            // 
            this.cbToMonth.FormattingEnabled = true;
            this.cbToMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbToMonth.Location = new System.Drawing.Point(244, 4);
            this.cbToMonth.Name = "cbToMonth";
            this.cbToMonth.Size = new System.Drawing.Size(40, 20);
            this.cbToMonth.TabIndex = 0;
        
            // 
            // cbFromMonth
            // 
            this.cbFromMonth.FormattingEnabled = true;
            this.cbFromMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbFromMonth.Location = new System.Drawing.Point(86, 4);
            this.cbFromMonth.Name = "cbFromMonth";
            this.cbFromMonth.Size = new System.Drawing.Size(40, 20);
            this.cbFromMonth.TabIndex = 0;
           
            // 
            // cbToYear
            // 
            this.cbToYear.FormattingEnabled = true;
            this.cbToYear.Location = new System.Drawing.Point(166, 4);
            this.cbToYear.Name = "cbToYear";
            this.cbToYear.Size = new System.Drawing.Size(53, 20);
            this.cbToYear.TabIndex = 0;
            
            // 
            // cbFromYear
            // 
            this.cbFromYear.FormattingEnabled = true;
            this.cbFromYear.Location = new System.Drawing.Point(3, 4);
            this.cbFromYear.Name = "cbFromYear";
            this.cbFromYear.Size = new System.Drawing.Size(55, 20);
            this.cbFromYear.TabIndex = 0;
        
            // 
            // DateFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMonth);
            this.Controls.Add(this.panelDtp);
            this.Controls.Add(this.cbDateFilterType);
            this.Name = "DateFilter";
            this.Size = new System.Drawing.Size(391, 30);
            this.Load += new System.EventHandler(this.DateFilter_Load);
            this.panelDtp.ResumeLayout(false);
            this.panelDtp.PerformLayout();
            this.panelMonth.ResumeLayout(false);
            this.panelMonth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDtp;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ComboBox cbDateFilterType;
        private System.Windows.Forms.Panel panelMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFromYear;
        private System.Windows.Forms.ComboBox cbFromMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbToMonth;
        private System.Windows.Forms.ComboBox cbToYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
