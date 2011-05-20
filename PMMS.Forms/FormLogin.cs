using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using PMMS.Services.System;
using PMMS.Services.Impl.System;
using PMMS.Exceptions;
using PMMS.Enum;
using PMMS.Services.StockManage;
using PMMS.Forms.Utils;
using Microsoft.Practices.Unity;
using System.IO;

namespace PMMS.Forms
{
    public partial class FormLogin : MasterForm
    {
        IUserLogic userLogic;

        public FormLogin()
        {
            InitializeComponent();
            this.userLogic = UnityControllerFactory.Container.Resolve<IUserLogic>();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var view = cbUsers.SelectedItem as LoginUserListView;
            try
            {
                CurrentUser = userLogic.Login(new LoginView()
                {
                    Id = view.Id,
                    Password = txtPassword.Text.Trim()
                });
                var f = new FormMain();
                this.Hide();
                f.Show();
            }
            catch (LoginException ex)
            {
                if (ex.LoginFailType == LoginFailType.AccountOrPasswordWrong)
                {
                    MessageBox.Show("帐号密码错误!");
                }
                if (ex.LoginFailType == LoginFailType.UserIsDisabled)
                {
                    MessageBox.Show("该用户已经被禁用!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            skinEngine.SkinFile = Application.StartupPath + @"\Skin\MP10\MP10.ssk";
            userLogic.InitUser();//初始化管理员用户
            var users = userLogic.ListLoginUser();
            cbUsers.DataSource = users;
            cbUsers.DisplayMember = "AccountAndName";
            cbUsers.ValueMember = "Id";
            txtPassword.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
