using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.System
{
    public interface IUserLogic
    {
        List<LoginUserListView> ListLoginUser();

        UserView Login(LoginView view);

        void AddUser(UserAddView view);

        IList<UserListView> ListUser();

        void UpdateUser(UserUpdateView view);

        void Disable(IList<int> uIds);

        void Enable(IList<int> uIds);

        void ResetPassword(IList<int> uIds);
    }
}
