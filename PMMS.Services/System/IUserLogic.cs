using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.System
{
    public interface IUserLogic
    {
        /// <summary>
        /// 初始化用户
        /// </summary>
        void InitUser();

        /// <summary>
        /// 获取登录下拉用户列表
        /// </summary>
        /// <returns></returns>
        List<LoginUserListView> ListLoginUser();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        UserView Login(LoginView view);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="view"></param>
        void AddUser(UserAddView view);

        IList<UserListView> ListUser();

        void UpdateUser(UserUpdateView view);

        void Disable(IList<int> uIds);

        void Enable(IList<int> uIds);

        void ResetPassword(IList<int> uIds);
    }
}
