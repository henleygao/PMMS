﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMMS.Services.System;
using NHibernate;
using PMMS.Services.Impl.System;
using PMMS.Enum;
using PMMS.Exceptions;

namespace PMMS.Forms
{
    public partial class FormUser : Form
    {
        IUserLogic userLogic;

        public FormUser(IUserLogic userLogic)
        {
            InitializeComponent();
            this.userLogic = userLogic;
        }

        private void FormUserList_Load(object sender, EventArgs e)
        {
            dgUsers.DataSource = userLogic.ListUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(account))
            {
                MessageBox.Show("帐号不能为空!");
                txtAccount.Focus();
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("姓名不能为空!");
                txtName.Focus();
                return;
            }
            try
            {
                userLogic.AddUser(new UserAddView()
                {
                    Account = account,
                    Name = name
                });
                dgUsers.DataSource = userLogic.ListUser();
                txtAccount.Clear();
                txtName.Clear();
            }
            catch (RepeatException)
            {
                MessageBox.Show("该帐号已经存在！");
                txtAccount.Focus();
            }
        }

        private void dgUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //绑定完成
        private void dgUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgUsers.Columns["Id"].Visible = false;
            dgUsers.RowHeadersWidth = 50;
            dgUsers.TopLeftHeaderCell.Value = "序号";
            for (int i = 0; i < dgUsers.Rows.Count; i++)
            {
                var cell = dgUsers.Rows[i].Cells["Status"];
                if (cell.Value.ToString() == "禁用")
                {
                    var style = new DataGridViewCellStyle();
                    style.ForeColor = Color.Red;
                    cell.Style = style;
                }
                dgUsers.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

        }

        private void dgUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgUsers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var uid = Convert.ToInt32(dgUsers.Rows[e.RowIndex].Cells["Id"].Value);
            var account = dgUsers.Rows[e.RowIndex].Cells["Account"].Value.ToString();
            var name = dgUsers.Rows[e.RowIndex].Cells["UserName"].Value.ToString();

            if (string.IsNullOrEmpty(account.Trim()))
            {
                MessageBox.Show("帐号不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(name.Trim()))
            {
                MessageBox.Show("姓名不能为空!");
                return;
            }
            try
            {
                userLogic.UpdateUser(new UserUpdateView()
                {
                    Account = account,
                    Name = name,
                    Id = uid
                });
            }
            catch (RepeatException)
            {
                MessageBox.Show("该帐号已经存在！");
            }
        }

        private void dgUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    this.contextMenuStrip.Show(MousePosition);
            //    // MessageBox.Show(this.QuerydataGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());  
            //}
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslmiDisenable_Click(object sender, EventArgs e)
        {
            var ids = new List<int>();
            foreach (DataGridViewRow row in dgUsers.SelectedRows)
            {
                ids.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }
            if (ids.Count > 0)
            {
                userLogic.Disable(ids);
                dgUsers.DataSource = userLogic.ListUser();
            }
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiEnable_Click(object sender, EventArgs e)
        {
            var ids = new List<int>();
            foreach (DataGridViewRow row in dgUsers.SelectedRows)
            {
                ids.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }
            if (ids.Count > 0)
            {
                userLogic.Enable(ids);
                dgUsers.DataSource = userLogic.ListUser();
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiResetPwd_Click(object sender, EventArgs e)
        {
            var ids = new List<int>();
            foreach (DataGridViewRow row in dgUsers.SelectedRows)
            {
                ids.Add(Convert.ToInt32(row.Cells["Id"].Value));
            }
            if (ids.Count > 0)
            {
                userLogic.ResetPassword(ids);
                dgUsers.DataSource = userLogic.ListUser();
            }
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtName.Focus();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnAdd.Focus();
        }


    }
}

